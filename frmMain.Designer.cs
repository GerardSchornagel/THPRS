namespace THPRS
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrRefreshToken = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtboxTriggerword = new System.Windows.Forms.TextBox();
            this.lblTriggerword = new System.Windows.Forms.Label();
            this.chklistParticipants = new System.Windows.Forms.CheckedListBox();
            this.btnParticipantsClear = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtboxLog = new System.Windows.Forms.TextBox();
            this.toolDevSend = new System.Windows.Forms.TextBox();
            this.btnKeywordStart = new System.Windows.Forms.Button();
            this.btnKeywordStop = new System.Windows.Forms.Button();
            this.btnIDLE = new System.Windows.Forms.Button();
            this.btnEXIT = new System.Windows.Forms.Button();
            this.tmrStatusbar = new System.Windows.Forms.Timer(this.components);
            this.lblReceivers = new System.Windows.Forms.Label();
            this.nudReceivers = new System.Windows.Forms.NumericUpDown();
            this.statusBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivers)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnection,
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 516);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(666, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Statusbar";
            // 
            // statusConnection
            // 
            this.statusConnection.ForeColor = System.Drawing.Color.Red;
            this.statusConnection.Name = "statusConnection";
            this.statusConnection.Size = new System.Drawing.Size(79, 17);
            this.statusConnection.Text = "Disconnected";
            this.statusConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(12, 17);
            this.statusLabel.Text = "*";
            // 
            // tmrRefreshToken
            // 
            this.tmrRefreshToken.Interval = 1000;
            this.tmrRefreshToken.Tick += new System.EventHandler(this.TmrRefreshToken_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(666, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menustrip";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileConnect,
            this.toolStripSeparator2,
            this.menuFileDefault,
            this.menuFileExport,
            this.menuFileImport,
            this.menuFileSeparator2,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileConnect
            // 
            this.menuFileConnect.Name = "menuFileConnect";
            this.menuFileConnect.Size = new System.Drawing.Size(149, 22);
            this.menuFileConnect.Text = "&Connect";
            this.menuFileConnect.Click += new System.EventHandler(this.MenuFileConnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // menuFileDefault
            // 
            this.menuFileDefault.Name = "menuFileDefault";
            this.menuFileDefault.Size = new System.Drawing.Size(149, 22);
            this.menuFileDefault.Text = "Default Profile";
            this.menuFileDefault.Click += new System.EventHandler(this.MenuFileDefault_Click);
            // 
            // menuFileExport
            // 
            this.menuFileExport.Name = "menuFileExport";
            this.menuFileExport.Size = new System.Drawing.Size(149, 22);
            this.menuFileExport.Text = "Export Profile";
            this.menuFileExport.Click += new System.EventHandler(this.MenuFileExport_Click);
            // 
            // menuFileImport
            // 
            this.menuFileImport.Name = "menuFileImport";
            this.menuFileImport.Size = new System.Drawing.Size(149, 22);
            this.menuFileImport.Text = "Import Profile";
            this.menuFileImport.Click += new System.EventHandler(this.MenuFileImport_Click);
            // 
            // menuFileSeparator2
            // 
            this.menuFileSeparator2.Name = "menuFileSeparator2";
            this.menuFileSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(149, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionsSettings});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // menuOptionsSettings
            // 
            this.menuOptionsSettings.Name = "menuOptionsSettings";
            this.menuOptionsSettings.Size = new System.Drawing.Size(125, 22);
            this.menuOptionsSettings.Text = "&Settings...";
            this.menuOptionsSettings.Click += new System.EventHandler(this.MenuOptionsSettings_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // txtboxTriggerword
            // 
            this.txtboxTriggerword.Location = new System.Drawing.Point(12, 44);
            this.txtboxTriggerword.Name = "txtboxTriggerword";
            this.txtboxTriggerword.Size = new System.Drawing.Size(104, 20);
            this.txtboxTriggerword.TabIndex = 4;
            // 
            // lblTriggerword
            // 
            this.lblTriggerword.AutoSize = true;
            this.lblTriggerword.Location = new System.Drawing.Point(9, 28);
            this.lblTriggerword.Name = "lblTriggerword";
            this.lblTriggerword.Size = new System.Drawing.Size(69, 13);
            this.lblTriggerword.TabIndex = 5;
            this.lblTriggerword.Text = "Trigger Word";
            // 
            // chklistParticipants
            // 
            this.chklistParticipants.FormattingEnabled = true;
            this.chklistParticipants.Location = new System.Drawing.Point(12, 127);
            this.chklistParticipants.Name = "chklistParticipants";
            this.chklistParticipants.Size = new System.Drawing.Size(172, 334);
            this.chklistParticipants.TabIndex = 6;
            // 
            // btnParticipantsClear
            // 
            this.btnParticipantsClear.Location = new System.Drawing.Point(13, 468);
            this.btnParticipantsClear.Name = "btnParticipantsClear";
            this.btnParticipantsClear.Size = new System.Drawing.Size(171, 45);
            this.btnParticipantsClear.TabIndex = 7;
            this.btnParticipantsClear.Text = "Clear List";
            this.btnParticipantsClear.UseVisualStyleBackColor = true;
            this.btnParticipantsClear.Click += new System.EventHandler(this.BtnParticipantsClear_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(12, 70);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(172, 51);
            this.btnDraw.TabIndex = 8;
            this.btnDraw.Text = "Draw a Present Receiver";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.BtnDraw_Click);
            // 
            // txtboxLog
            // 
            this.txtboxLog.Location = new System.Drawing.Point(208, 266);
            this.txtboxLog.Multiline = true;
            this.txtboxLog.Name = "txtboxLog";
            this.txtboxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxLog.Size = new System.Drawing.Size(446, 195);
            this.txtboxLog.TabIndex = 9;
            // 
            // toolDevSend
            // 
            this.toolDevSend.Location = new System.Drawing.Point(208, 470);
            this.toolDevSend.Name = "toolDevSend";
            this.toolDevSend.Size = new System.Drawing.Size(445, 20);
            this.toolDevSend.TabIndex = 10;
            this.toolDevSend.Text = "PRIVMSG #feanoir85 :";
            this.toolDevSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ToolDevSend_KeyUp);
            // 
            // btnKeywordStart
            // 
            this.btnKeywordStart.Location = new System.Drawing.Point(303, 44);
            this.btnKeywordStart.Name = "btnKeywordStart";
            this.btnKeywordStart.Size = new System.Drawing.Size(172, 26);
            this.btnKeywordStart.TabIndex = 11;
            this.btnKeywordStart.Text = "KEYWORD_START";
            this.btnKeywordStart.UseVisualStyleBackColor = true;
            this.btnKeywordStart.Click += new System.EventHandler(this.BtnKeywordStart_Click);
            // 
            // btnKeywordStop
            // 
            this.btnKeywordStop.Location = new System.Drawing.Point(303, 76);
            this.btnKeywordStop.Name = "btnKeywordStop";
            this.btnKeywordStop.Size = new System.Drawing.Size(172, 23);
            this.btnKeywordStop.TabIndex = 11;
            this.btnKeywordStop.Text = "KEYWORD_STOP";
            this.btnKeywordStop.UseVisualStyleBackColor = true;
            this.btnKeywordStop.Click += new System.EventHandler(this.BtnKeywordStop_Click);
            // 
            // btnIDLE
            // 
            this.btnIDLE.Location = new System.Drawing.Point(481, 44);
            this.btnIDLE.Name = "btnIDLE";
            this.btnIDLE.Size = new System.Drawing.Size(172, 26);
            this.btnIDLE.TabIndex = 11;
            this.btnIDLE.Text = "IDLE";
            this.btnIDLE.UseVisualStyleBackColor = true;
            this.btnIDLE.Click += new System.EventHandler(this.BtnIDLE_Click);
            // 
            // btnEXIT
            // 
            this.btnEXIT.Location = new System.Drawing.Point(481, 76);
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.Size = new System.Drawing.Size(172, 23);
            this.btnEXIT.TabIndex = 11;
            this.btnEXIT.Text = "EXIT";
            this.btnEXIT.UseVisualStyleBackColor = true;
            this.btnEXIT.Click += new System.EventHandler(this.BtnEXIT_Click);
            // 
            // tmrStatusbar
            // 
            this.tmrStatusbar.Enabled = true;
            this.tmrStatusbar.Interval = 250;
            this.tmrStatusbar.Tick += new System.EventHandler(this.TmrStatusbar_Tick);
            // 
            // lblReceivers
            // 
            this.lblReceivers.AutoSize = true;
            this.lblReceivers.Location = new System.Drawing.Point(119, 28);
            this.lblReceivers.Name = "lblReceivers";
            this.lblReceivers.Size = new System.Drawing.Size(65, 13);
            this.lblReceivers.TabIndex = 5;
            this.lblReceivers.Text = "# Receivers";
            // 
            // nudReceivers
            // 
            this.nudReceivers.Location = new System.Drawing.Point(122, 44);
            this.nudReceivers.Name = "nudReceivers";
            this.nudReceivers.Size = new System.Drawing.Size(62, 20);
            this.nudReceivers.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 538);
            this.Controls.Add(this.nudReceivers);
            this.Controls.Add(this.btnEXIT);
            this.Controls.Add(this.btnKeywordStop);
            this.Controls.Add(this.btnIDLE);
            this.Controls.Add(this.btnKeywordStart);
            this.Controls.Add(this.toolDevSend);
            this.Controls.Add(this.txtboxLog);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnParticipantsClear);
            this.Controls.Add(this.chklistParticipants);
            this.Controls.Add(this.lblReceivers);
            this.Controls.Add(this.lblTriggerword);
            this.Controls.Add(this.txtboxTriggerword);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "The Haven\'s Present Receiver Selector";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusConnection;
        private System.Windows.Forms.Timer tmrRefreshToken;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsSettings;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileConnect;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuFileDefault;
        private System.Windows.Forms.ToolStripMenuItem menuFileExport;
        private System.Windows.Forms.ToolStripMenuItem menuFileImport;
        private System.Windows.Forms.TextBox txtboxTriggerword;
        private System.Windows.Forms.Label lblTriggerword;
        private System.Windows.Forms.CheckedListBox chklistParticipants;
        private System.Windows.Forms.Button btnParticipantsClear;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtboxLog;
        private System.Windows.Forms.TextBox toolDevSend;
        private System.Windows.Forms.Button btnKeywordStart;
        private System.Windows.Forms.Button btnKeywordStop;
        private System.Windows.Forms.Button btnIDLE;
        private System.Windows.Forms.Button btnEXIT;
        private System.Windows.Forms.Timer tmrStatusbar;
        private System.Windows.Forms.Label lblReceivers;
        private System.Windows.Forms.NumericUpDown nudReceivers;
    }
}

