using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usbSimCentral
{
    public partial class frmMain : Form
    {
        bool Connected = false;

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

        private bool connectFSX()
        {
            return true;
        }

        private bool disconnectFSX()
        {
            return true;
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
            if (Connected)
            {
                if (disconnectFSX())
                {
                    instrumentSelectionStatus(true);
                    btnConnect.Text = "Connect";
                    Connected = false;
                }
            }
            else
            {
                if (connectFSX())
                {
                    instrumentSelectionStatus(false);
                    btnConnect.Text = "Disconnect";
                    Connected = true;
                }
            }
        }
    }
}
