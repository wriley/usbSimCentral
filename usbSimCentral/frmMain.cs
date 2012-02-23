using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;
using usbSimInstrument;
using LibUsbDotNet.DeviceNotify;
using LibUsbDotNet.Main;
using LibUsbDotNet;

namespace usbSimCentral
{
    public partial class frmMain : Form
    {
        private SimConnect simconnect = null;
        private const int WM_USER_SIMCONNECT = 0x0402;
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

        private int airspeedPosition = int.MinValue;

        private Instrument InstrumentASI;
        private Instrument InstrumentAttitude;
        private Instrument InstrumentAltimiter;
        private Instrument InstrumentTurnSlip;
        private Instrument InstrumentGyro;
        private Instrument InstrumentVSI;

        const int VENDOR_ID = 0x16C0;
        const int PRODUCT_ID = 0x05DC;

        public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();

        double[] TableASI = new double[8];
        double[] RawASI = new double[8];
        double[] TableAttitude = new double[8];
        double[] RawAttitude = new double[8];
        double[] TableAltimeter = new double[8];
        double[] RawAltimeter = new double[8];
        double[] TableTurnSlip = new double[8];
        double[] RawTurnSlip = new double[8];
        double[] TableGyro = new double[8];
        double[] RawGyro = new double[8];
        double[] TableVSI = new double[8];
        double[] RawVSI = new double[8];

        Dictionary<double, double> LookupASI = new Dictionary<double,double>();
        Dictionary<double, double> LookupAttitude = new Dictionary<double, double>();
        Dictionary<double, double> LookupAltimeter = new Dictionary<double, double>();
        Dictionary<double, double> LookupTurnSlip = new Dictionary<double, double>();
        Dictionary<double, double> LookupGyro = new Dictionary<double, double>();
        Dictionary<double, double> LookupVSI = new Dictionary<double, double>();

        internal enum USBSIM_INSTRUMENT_ASSIGNMENTS
        {
            ASI = 1,
            ATTITUDE = 2,
            ALTIMETER = 3,
            TURNSLIP = 4,
            GYRO = 5,
            VSI = 6,
        };

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

        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if ((e.Device.IdVendor == VENDOR_ID) && (e.Device.IdProduct == PRODUCT_ID))
            {

                switch (e.EventType)
                {
                    case EventType.DeviceArrival:
                        addDevice(e.Device.SerialNumber);
                        break;
                    case EventType.DeviceRemoveComplete:
                        removeDevice(e.Device.SerialNumber);
                        break;
                }
            }
        }

        private void addDevice(String serial)
        {
            displayText("Adding device: " + serial);

            switch (serial)
            {
                case "01":
                    InstrumentASI = new Instrument(serial);
                    TableASI = InstrumentASI.ReadTable();
                    RawASI = InstrumentASI.ReadTableRaw();
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupASI.Add(TableASI[i], RawASI[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
                case "02":
                    InstrumentAttitude = new Instrument(serial);
                    TableAttitude = InstrumentAttitude.ReadTable();
                    RawAttitude = InstrumentAttitude.ReadTableRaw();
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupAttitude.Add(TableAttitude[i], RawAttitude[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
                case "03":
                    InstrumentAltimiter = new Instrument(serial);
                    TableASI = InstrumentAltimiter.ReadTable();
                    RawASI = InstrumentAltimiter.ReadTableRaw();
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupAltimeter.Add(TableAltimeter[i], RawAltimeter[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
                case "04":
                    InstrumentTurnSlip = new Instrument(serial);
                    TableTurnSlip = InstrumentTurnSlip.ReadTable();
                    RawTurnSlip = InstrumentTurnSlip.ReadTableRaw();
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupTurnSlip.Add(TableTurnSlip[i], RawTurnSlip[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
                case "05":
                    InstrumentGyro = new Instrument(serial);
                    TableGyro = InstrumentGyro.ReadTable();
                    RawGyro = InstrumentGyro.ReadTableRaw();
                    
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupGyro.Add(TableGyro[i], RawGyro[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
                case "06":
                    InstrumentVSI = new Instrument(serial);
                    TableVSI = InstrumentVSI.ReadTable();
                    RawVSI = InstrumentVSI.ReadTableRaw();
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            LookupVSI.Add(TableVSI[i], RawVSI[i]);
                        }
                        catch (ArgumentException ex)
                        {
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    break;
            }
        }

        private void removeDevice(String serial)
        {
            displayText("Removing device: " + serial);
            switch (serial)
            {
                case "01":
                    InstrumentASI = null;
                    break;
                case "02":
                    InstrumentAttitude = null;
                    break;
                case "03":
                    InstrumentAltimiter = null;
                    break;
                case "04":
                    InstrumentTurnSlip = null;
                    break;
                case "05":
                    InstrumentGyro = null;
                    break;
                case "06":
                    InstrumentVSI = null;
                    break;
            }
        }

        private void connectFSX()
        {
            try
            {
                // the constructor is similar to SimConnect_Open in the native API 
                simconnect = new SimConnect("Managed Data Request", this.Handle, WM_USER_SIMCONNECT, null, 0);
                initDataRequest();
                ButtonConnect.Text = "Disconnect";
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
                ButtonConnect.Text = "Connect";
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

                    updateInstruments();

                    break;

                default:
                    displayText("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        private void updateInstruments()
        {
            if ((InstrumentASI != null) && checkBoxAirSpeedIndicator.Checked)
            {
                int airspeedTargetPosition = getPosition(USBSIM_INSTRUMENT_ASSIGNMENTS.ASI, (int)airspeed);
                if (
                    (airspeedPosition == int.MinValue) ||
                    (airspeedPosition == airspeedTargetPosition) ||
                    (Math.Abs(airspeedTargetPosition - airspeedPosition) > 20)
                    )
                {
                    airspeedPosition = airspeedTargetPosition;
                }
                else
                {
                    if (airspeedTargetPosition > airspeedPosition)
                    {
                        airspeedPosition++;
                    }
                    else
                    {
                        airspeedPosition--;
                    }
                }
                InstrumentASI.Set1(airspeedPosition);
            }
        }

        private int getPosition(USBSIM_INSTRUMENT_ASSIGNMENTS ins, int x)
        {
            double y, x0, y0, x1, y1;
            int i;

            Dictionary<double, double> lookup = new Dictionary<double, double>();

            switch (ins)
            {
                case USBSIM_INSTRUMENT_ASSIGNMENTS.ASI:
                    lookup = LookupASI;
                    break;
            }

            if(x > lookup.Keys.ElementAt(lookup.Count - 1))
            {
                return int.Parse(lookup.Values.ElementAt(lookup.Count - 1).ToString());
            }

            for (i = 0; i < lookup.Count; i++)
            {
                if (x == lookup.Keys.ElementAt(i))
                {
                    return int.Parse(lookup.Values.ElementAt(i).ToString());
                }

                if (x < lookup.Keys.ElementAt(i))
                {
                    break;
                }
            }

            if (i == (lookup.Count - 1))
            {
                x0 = lookup.Keys.ElementAt(i - 1);
                x1 = lookup.Keys.ElementAt(i);
                y0 = lookup.Values.ElementAt(i - 1);
                y1 = lookup.Values.ElementAt(i);
            }
            else
            {
                x0 = lookup.Keys.ElementAt(i);
                x1 = lookup.Keys.ElementAt(i + 1);
                y0 = lookup.Values.ElementAt(i);
                y1 = lookup.Values.ElementAt(i + 1);
            }

            y = y0 + ((x - x0) * ((y1 - y0) / (x1 - x0)));

            return (int)y ;
        }

        private void displayText(string s)
        {
            // remove first string from output 
            output = output.Substring(output.IndexOf("\n") + 1);

            // add the new string 
            output += "\n" + s;

            // display it 
            RichTextBoxMessages.Text = output;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        public void saveOptions()
        {
        }

        private void FindDevices()
        {
            UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(VENDOR_ID, PRODUCT_ID);
            UsbRegDeviceList MyUsbRegDeviceList = UsbDevice.AllDevices.FindAll(MyUsbFinder);

            if (MyUsbRegDeviceList.Count > 0)
            {
                foreach (UsbRegistry MyUsbRegistry in MyUsbRegDeviceList)
                {
                    displayText(String.Format("Found: {0} - {1}", MyUsbRegistry.Device.Info.SerialString.ToString(), MyUsbRegistry.Name));
                    if ((MyUsbRegistry.Device.Info.Descriptor.VendorID == VENDOR_ID) && (MyUsbRegistry.Device.Info.Descriptor.ProductID == PRODUCT_ID))
                    {
                        addDevice(MyUsbRegistry.Device.Info.SerialString);
                    }
                }
            }
            else
            {
                displayText("No devices found");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
            FindDevices();
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
            checkBoxAirSpeedIndicator.Enabled = status;
            checkBoxAltimeter.Enabled = status;
            checkBoxArtificialHorizon.Enabled = status;
            checkBoxHeadingIndicator.Enabled = status;
            checkBoxTurnSlipIndicator.Enabled = status;
            checkBoxVerticalSpeedIndicator.Enabled = status;
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
