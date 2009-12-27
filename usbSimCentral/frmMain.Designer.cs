namespace usbSimCentral
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAirspeed = new System.Windows.Forms.Label();
            this.tbAirspeed = new System.Windows.Forms.TextBox();
            this.tbPitch = new System.Windows.Forms.TextBox();
            this.lblPitchAngle = new System.Windows.Forms.Label();
            this.tbSlip = new System.Windows.Forms.TextBox();
            this.lblSlip = new System.Windows.Forms.Label();
            this.tbRoll = new System.Windows.Forms.TextBox();
            this.lblRoll = new System.Windows.Forms.Label();
            this.tbAltitude = new System.Windows.Forms.TextBox();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.tbTurn = new System.Windows.Forms.TextBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.tbHeading = new System.Windows.Forms.TextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.tbVS = new System.Windows.Forms.TextBox();
            this.lblVS = new System.Windows.Forms.Label();
            this.GroupBoxFSXValues = new System.Windows.Forms.GroupBox();
            this.cbDisplay = new System.Windows.Forms.CheckBox();
            this.GroupBoxInstrumentAssignments = new System.Windows.Forms.GroupBox();
            this.checkBoxVerticalSpeedIndicator = new System.Windows.Forms.CheckBox();
            this.checkBoxHeadingIndicator = new System.Windows.Forms.CheckBox();
            this.checkBoxTurnSlipIndicator = new System.Windows.Forms.CheckBox();
            this.checkBoxAltimeter = new System.Windows.Forms.CheckBox();
            this.checkBoxArtificialHorizon = new System.Windows.Forms.CheckBox();
            this.checkBoxAirSpeedIndicator = new System.Windows.Forms.CheckBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.RichTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.GroupBoxFSXValues.SuspendLayout();
            this.GroupBoxInstrumentAssignments.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblAirspeed
            // 
            this.lblAirspeed.AutoSize = true;
            this.lblAirspeed.Location = new System.Drawing.Point(29, 46);
            this.lblAirspeed.Name = "lblAirspeed";
            this.lblAirspeed.Size = new System.Drawing.Size(48, 13);
            this.lblAirspeed.TabIndex = 5;
            this.lblAirspeed.Text = "Airspeed";
            // 
            // tbAirspeed
            // 
            this.tbAirspeed.Location = new System.Drawing.Point(83, 43);
            this.tbAirspeed.Name = "tbAirspeed";
            this.tbAirspeed.ReadOnly = true;
            this.tbAirspeed.Size = new System.Drawing.Size(93, 20);
            this.tbAirspeed.TabIndex = 6;
            this.tbAirspeed.Text = "999";
            // 
            // tbPitch
            // 
            this.tbPitch.Location = new System.Drawing.Point(83, 69);
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.ReadOnly = true;
            this.tbPitch.Size = new System.Drawing.Size(93, 20);
            this.tbPitch.TabIndex = 8;
            this.tbPitch.Text = "999";
            // 
            // lblPitchAngle
            // 
            this.lblPitchAngle.AutoSize = true;
            this.lblPitchAngle.Location = new System.Drawing.Point(46, 72);
            this.lblPitchAngle.Name = "lblPitchAngle";
            this.lblPitchAngle.Size = new System.Drawing.Size(31, 13);
            this.lblPitchAngle.TabIndex = 7;
            this.lblPitchAngle.Text = "Pitch";
            // 
            // tbSlip
            // 
            this.tbSlip.Location = new System.Drawing.Point(83, 173);
            this.tbSlip.Name = "tbSlip";
            this.tbSlip.ReadOnly = true;
            this.tbSlip.Size = new System.Drawing.Size(93, 20);
            this.tbSlip.TabIndex = 10;
            this.tbSlip.Text = "999";
            // 
            // lblSlip
            // 
            this.lblSlip.AutoSize = true;
            this.lblSlip.Location = new System.Drawing.Point(53, 176);
            this.lblSlip.Name = "lblSlip";
            this.lblSlip.Size = new System.Drawing.Size(24, 13);
            this.lblSlip.TabIndex = 9;
            this.lblSlip.Text = "Slip";
            // 
            // tbRoll
            // 
            this.tbRoll.Location = new System.Drawing.Point(83, 95);
            this.tbRoll.Name = "tbRoll";
            this.tbRoll.ReadOnly = true;
            this.tbRoll.Size = new System.Drawing.Size(93, 20);
            this.tbRoll.TabIndex = 12;
            this.tbRoll.Text = "999";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(52, 98);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(25, 13);
            this.lblRoll.TabIndex = 11;
            this.lblRoll.Text = "Roll";
            // 
            // tbAltitude
            // 
            this.tbAltitude.Location = new System.Drawing.Point(83, 121);
            this.tbAltitude.Name = "tbAltitude";
            this.tbAltitude.ReadOnly = true;
            this.tbAltitude.Size = new System.Drawing.Size(93, 20);
            this.tbAltitude.TabIndex = 14;
            this.tbAltitude.Text = "99999";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(35, 124);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(42, 13);
            this.lblAltitude.TabIndex = 13;
            this.lblAltitude.Text = "Altitude";
            // 
            // tbTurn
            // 
            this.tbTurn.Location = new System.Drawing.Point(83, 147);
            this.tbTurn.Name = "tbTurn";
            this.tbTurn.ReadOnly = true;
            this.tbTurn.Size = new System.Drawing.Size(93, 20);
            this.tbTurn.TabIndex = 16;
            this.tbTurn.Text = "999";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(48, 150);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(29, 13);
            this.lblTurn.TabIndex = 15;
            this.lblTurn.Text = "Turn";
            // 
            // tbHeading
            // 
            this.tbHeading.Location = new System.Drawing.Point(83, 199);
            this.tbHeading.Name = "tbHeading";
            this.tbHeading.ReadOnly = true;
            this.tbHeading.Size = new System.Drawing.Size(93, 20);
            this.tbHeading.TabIndex = 18;
            this.tbHeading.Text = "999";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Location = new System.Drawing.Point(30, 202);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(47, 13);
            this.lblHeading.TabIndex = 17;
            this.lblHeading.Text = "Heading";
            // 
            // tbVS
            // 
            this.tbVS.Location = new System.Drawing.Point(83, 225);
            this.tbVS.Name = "tbVS";
            this.tbVS.ReadOnly = true;
            this.tbVS.Size = new System.Drawing.Size(93, 20);
            this.tbVS.TabIndex = 20;
            this.tbVS.Text = "9999";
            // 
            // lblVS
            // 
            this.lblVS.AutoSize = true;
            this.lblVS.Location = new System.Drawing.Point(45, 228);
            this.lblVS.Name = "lblVS";
            this.lblVS.Size = new System.Drawing.Size(21, 13);
            this.lblVS.TabIndex = 19;
            this.lblVS.Text = "VS";
            // 
            // GroupBoxFSXValues
            // 
            this.GroupBoxFSXValues.Controls.Add(this.cbDisplay);
            this.GroupBoxFSXValues.Controls.Add(this.tbSlip);
            this.GroupBoxFSXValues.Controls.Add(this.lblAirspeed);
            this.GroupBoxFSXValues.Controls.Add(this.tbAirspeed);
            this.GroupBoxFSXValues.Controls.Add(this.tbVS);
            this.GroupBoxFSXValues.Controls.Add(this.lblPitchAngle);
            this.GroupBoxFSXValues.Controls.Add(this.lblVS);
            this.GroupBoxFSXValues.Controls.Add(this.tbPitch);
            this.GroupBoxFSXValues.Controls.Add(this.tbHeading);
            this.GroupBoxFSXValues.Controls.Add(this.lblSlip);
            this.GroupBoxFSXValues.Controls.Add(this.lblHeading);
            this.GroupBoxFSXValues.Controls.Add(this.lblRoll);
            this.GroupBoxFSXValues.Controls.Add(this.tbTurn);
            this.GroupBoxFSXValues.Controls.Add(this.tbRoll);
            this.GroupBoxFSXValues.Controls.Add(this.lblTurn);
            this.GroupBoxFSXValues.Controls.Add(this.lblAltitude);
            this.GroupBoxFSXValues.Controls.Add(this.tbAltitude);
            this.GroupBoxFSXValues.Location = new System.Drawing.Point(12, 27);
            this.GroupBoxFSXValues.Name = "GroupBoxFSXValues";
            this.GroupBoxFSXValues.Size = new System.Drawing.Size(182, 256);
            this.GroupBoxFSXValues.TabIndex = 23;
            this.GroupBoxFSXValues.TabStop = false;
            this.GroupBoxFSXValues.Text = "FSX Values";
            // 
            // cbDisplay
            // 
            this.cbDisplay.AutoSize = true;
            this.cbDisplay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDisplay.Checked = true;
            this.cbDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplay.Location = new System.Drawing.Point(38, 19);
            this.cbDisplay.Name = "cbDisplay";
            this.cbDisplay.Size = new System.Drawing.Size(60, 17);
            this.cbDisplay.TabIndex = 21;
            this.cbDisplay.Text = "Display";
            this.cbDisplay.UseVisualStyleBackColor = true;
            this.cbDisplay.CheckedChanged += new System.EventHandler(this.cbDisplay_CheckedChanged);
            // 
            // GroupBoxInstrumentAssignments
            // 
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxVerticalSpeedIndicator);
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxHeadingIndicator);
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxTurnSlipIndicator);
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxAltimeter);
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxArtificialHorizon);
            this.GroupBoxInstrumentAssignments.Controls.Add(this.checkBoxAirSpeedIndicator);
            this.GroupBoxInstrumentAssignments.Location = new System.Drawing.Point(200, 27);
            this.GroupBoxInstrumentAssignments.Name = "GroupBoxInstrumentAssignments";
            this.GroupBoxInstrumentAssignments.Size = new System.Drawing.Size(387, 256);
            this.GroupBoxInstrumentAssignments.TabIndex = 21;
            this.GroupBoxInstrumentAssignments.TabStop = false;
            this.GroupBoxInstrumentAssignments.Text = "Instrument Outputs";
            // 
            // checkBoxVerticalSpeedIndicator
            // 
            this.checkBoxVerticalSpeedIndicator.AutoSize = true;
            this.checkBoxVerticalSpeedIndicator.Location = new System.Drawing.Point(240, 42);
            this.checkBoxVerticalSpeedIndicator.Name = "checkBoxVerticalSpeedIndicator";
            this.checkBoxVerticalSpeedIndicator.Size = new System.Drawing.Size(139, 17);
            this.checkBoxVerticalSpeedIndicator.TabIndex = 38;
            this.checkBoxVerticalSpeedIndicator.Text = "Vertical Speed Indicator";
            this.checkBoxVerticalSpeedIndicator.UseVisualStyleBackColor = true;
            // 
            // checkBoxHeadingIndicator
            // 
            this.checkBoxHeadingIndicator.AutoSize = true;
            this.checkBoxHeadingIndicator.Location = new System.Drawing.Point(128, 42);
            this.checkBoxHeadingIndicator.Name = "checkBoxHeadingIndicator";
            this.checkBoxHeadingIndicator.Size = new System.Drawing.Size(110, 17);
            this.checkBoxHeadingIndicator.TabIndex = 37;
            this.checkBoxHeadingIndicator.Text = "Heading Indicator";
            this.checkBoxHeadingIndicator.UseVisualStyleBackColor = true;
            // 
            // checkBoxTurnSlipIndicator
            // 
            this.checkBoxTurnSlipIndicator.AutoSize = true;
            this.checkBoxTurnSlipIndicator.Location = new System.Drawing.Point(6, 42);
            this.checkBoxTurnSlipIndicator.Name = "checkBoxTurnSlipIndicator";
            this.checkBoxTurnSlipIndicator.Size = new System.Drawing.Size(114, 17);
            this.checkBoxTurnSlipIndicator.TabIndex = 36;
            this.checkBoxTurnSlipIndicator.Text = "Turn/Slip Indicator";
            this.checkBoxTurnSlipIndicator.UseVisualStyleBackColor = true;
            // 
            // checkBoxAltimeter
            // 
            this.checkBoxAltimeter.AutoSize = true;
            this.checkBoxAltimeter.Location = new System.Drawing.Point(240, 19);
            this.checkBoxAltimeter.Name = "checkBoxAltimeter";
            this.checkBoxAltimeter.Size = new System.Drawing.Size(66, 17);
            this.checkBoxAltimeter.TabIndex = 35;
            this.checkBoxAltimeter.Text = "Altimeter";
            this.checkBoxAltimeter.UseVisualStyleBackColor = true;
            // 
            // checkBoxArtificialHorizon
            // 
            this.checkBoxArtificialHorizon.AutoSize = true;
            this.checkBoxArtificialHorizon.Location = new System.Drawing.Point(128, 19);
            this.checkBoxArtificialHorizon.Name = "checkBoxArtificialHorizon";
            this.checkBoxArtificialHorizon.Size = new System.Drawing.Size(106, 17);
            this.checkBoxArtificialHorizon.TabIndex = 34;
            this.checkBoxArtificialHorizon.Text = "Attitude Indicator";
            this.checkBoxArtificialHorizon.UseVisualStyleBackColor = true;
            // 
            // checkBoxAirSpeedIndicator
            // 
            this.checkBoxAirSpeedIndicator.AutoSize = true;
            this.checkBoxAirSpeedIndicator.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAirSpeedIndicator.Name = "checkBoxAirSpeedIndicator";
            this.checkBoxAirSpeedIndicator.Size = new System.Drawing.Size(116, 17);
            this.checkBoxAirSpeedIndicator.TabIndex = 33;
            this.checkBoxAirSpeedIndicator.Text = "Air Speed Indicator";
            this.checkBoxAirSpeedIndicator.UseVisualStyleBackColor = true;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(12, 289);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonConnect.TabIndex = 24;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // RichTextBoxMessages
            // 
            this.RichTextBoxMessages.Location = new System.Drawing.Point(95, 291);
            this.RichTextBoxMessages.Name = "RichTextBoxMessages";
            this.RichTextBoxMessages.Size = new System.Drawing.Size(492, 157);
            this.RichTextBoxMessages.TabIndex = 25;
            this.RichTextBoxMessages.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.RichTextBoxMessages);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.GroupBoxInstrumentAssignments);
            this.Controls.Add(this.GroupBoxFSXValues);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "usbSimCentral";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GroupBoxFSXValues.ResumeLayout(false);
            this.GroupBoxFSXValues.PerformLayout();
            this.GroupBoxInstrumentAssignments.ResumeLayout(false);
            this.GroupBoxInstrumentAssignments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblAirspeed;
        private System.Windows.Forms.TextBox tbAirspeed;
        private System.Windows.Forms.TextBox tbPitch;
        private System.Windows.Forms.Label lblPitchAngle;
        private System.Windows.Forms.TextBox tbSlip;
        private System.Windows.Forms.Label lblSlip;
        private System.Windows.Forms.TextBox tbRoll;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.TextBox tbAltitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.TextBox tbTurn;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.TextBox tbHeading;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox tbVS;
        private System.Windows.Forms.Label lblVS;
        private System.Windows.Forms.GroupBox GroupBoxFSXValues;
        private System.Windows.Forms.GroupBox GroupBoxInstrumentAssignments;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.RichTextBox RichTextBoxMessages;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbDisplay;
        private System.Windows.Forms.CheckBox checkBoxVerticalSpeedIndicator;
        private System.Windows.Forms.CheckBox checkBoxHeadingIndicator;
        private System.Windows.Forms.CheckBox checkBoxTurnSlipIndicator;
        private System.Windows.Forms.CheckBox checkBoxAltimeter;
        private System.Windows.Forms.CheckBox checkBoxArtificialHorizon;
        private System.Windows.Forms.CheckBox checkBoxAirSpeedIndicator;
    }
}

