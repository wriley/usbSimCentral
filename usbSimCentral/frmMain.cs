using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace usbSimCentral
{
    public partial class frmMain : Form
    {
        private SimConnect simconnect = null;
        private const int WM_USER_SIMCONNECT = 0x0402;
        private int response = 1;
        private string output = "\n\n\n\n\n\n\n\n\n\n";
        private bool displayValues = true;

        private float altitude;
        private float airspeed;
        private float pitch;
        private float roll;
        private float turn;
        private float slip;
        private float heading;
        private float vs;

        enum DEFINITIONS
        {
            Struct1,
        }

        enum DATA_REQUESTS
        {
            REQUEST_1,
        }; 

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct Struct1
        {
            // this is how you declare a fixed size string
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String title;
            public float altitude;
            public float airspeed;
            public float pitch;
            public float roll;
            public float turn;
            public float slip;
            public float heading;
            public float vs;
        };

        private void connectFSX()
        {
            try
            {
                // the constructor is similar to SimConnect_Open in the native API 
                simconnect = new SimConnect("Managed Data Request", this.Handle, WM_USER_SIMCONNECT, null, 0);
                initDataRequest();
                btnConnect.Text = "Disconnect";
                instrumentSelectionStatus(false);
            }
            catch (COMException ex)
            {
                displayText("Unable to connect to FSX: " + ex.Message.ToString());
            } 
        }

        private void disconnectFSX()
        {
            if (simconnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close() 
                simconnect.Dispose();
                simconnect = null;
                displayText("Connection closed");
                btnConnect.Text = "Connect";
                instrumentSelectionStatus(true);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        // Set up all the SimConnect related data definitions and event handlers 
        private void initDataRequest()
        {
            try
            {
                // listen to connect and quit msgs 
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);

                // listen to exceptions 
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);

                // define a data structure 
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "INDICATED ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Airspeed Indicated", "knots", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "ATTITUDE INDICATOR PITCH DEGREES", "degrees", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "ATTITUDE INDICATOR BANK DEGREES", "degrees", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Delta Heading Rate", "degrees per second", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Turn Coordinator Ball", "number", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Heading Indicator", "degrees", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Vertical Speed", "ft/min", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                // IMPORTANT: register it with the simconnect managed wrapper marshaller 
                // if you skip this step, you will only receive a uint in the .dwData field. 
                simconnect.RegisterDataDefineStruct<Struct1>(DEFINITIONS.Struct1);

                // catch a simobject data request 
                simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_OnRecvSimobjectDataBytype);
            }
            catch (COMException ex)
            {
                displayText(ex.Message);
            }
        }

        private void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            displayText("Connected to FSX");
        }

        // The case where the user closes FSX 
        private void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            displayText("FSX has exited");
            disconnectFSX();
        }

        private void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            displayText("Exception received: " + data.dwException);
        }

        private void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {

            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.REQUEST_1:
                    Struct1 s1 = (Struct1)data.dwData[0];

                    altitude = s1.altitude;
                    airspeed = s1.airspeed;
                    pitch = s1.pitch;
                    roll = s1.roll;
                    turn = s1.turn;
                    slip = s1.slip;
                    heading = s1.heading;
                    vs = s1.vs;

                    break;

                default:
                    displayText("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        private void displayText(string s)
        {
            // remove first string from output 
            output = output.Substring(output.IndexOf("\n") + 1);

            // add the new string 
            output += "\n" + response++ + ": " + s;

            // display it 
            rtbMessages.Text = output;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        public void saveOptions()
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutBox = new frmAbout();
            aboutBox.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions(this);
            frm.ShowDialog(this);
        }

        

        private void instrumentSelectionStatus(bool status)
        {
            cbAltimeter.Enabled = status;
            cbASI.Enabled = status;
            cbAttitudeIndicator.Enabled = status;
            cbGyro.Enabled = status;
            cbTurnSlip.Enabled = status;
            cbVSI.Enabled = status;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (simconnect == null)
            {
                connectFSX();
            }
            else
            {
                disconnectFSX();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (simconnect != null)
            {
                try
                {
                    simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_1, DEFINITIONS.Struct1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                }
                catch (COMException ex)
                {
                    displayText(ex.Message);
                }
            }

            if (displayValues)
            {
                tbAirspeed.Text = airspeed.ToString();
                tbPitch.Text = pitch.ToString();
                tbRoll.Text = roll.ToString();
                tbAltitude.Text = altitude.ToString();
                tbTurn.Text = turn.ToString();
                tbSlip.Text = slip.ToString();
                tbHeading.Text = heading.ToString();
                tbVS.Text = vs.ToString();
            }
        }

        private void cbDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplay.Checked)
            {
                displayValues = true;

                lblAirspeed.Enabled = true;
                lblPitchAngle.Enabled = true;
                lblRoll.Enabled = true;
                lblAltitude.Enabled = true;
                lblTurn.Enabled = true;
                lblSlip.Enabled = true;
                lblHeading.Enabled = true;
                lblVS.Enabled = true;
            }
            else
            {
                displayValues = false;

                tbAirspeed.Text = "";
                tbPitch.Text = "";
                tbRoll.Text = "";
                tbAltitude.Text = "";
                tbTurn.Text = "";
                tbSlip.Text = "";
                tbHeading.Text = "";
                tbVS.Text = "";

                lblAirspeed.Enabled = false;
                lblPitchAngle.Enabled = false;
                lblRoll.Enabled = false;
                lblAltitude.Enabled = false;
                lblTurn.Enabled = false;
                lblSlip.Enabled = false;
                lblHeading.Enabled = false;
                lblVS.Enabled = false;
            }
        }
    }
}
