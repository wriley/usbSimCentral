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
    public partial class frmOptions : Form
    {
        frmMain parentForm;

        public frmOptions(frmMain frm)
        {
            InitializeComponent();
            parentForm = new frmMain();
            parentForm = frm;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            parentForm.saveOptions();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
