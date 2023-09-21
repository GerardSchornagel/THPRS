namespace THPRS
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.txtboxOAuthAuthorisationEndpoint = new System.Windows.Forms.TextBox();
            this.txtboxOAuthTokenEndpoint = new System.Windows.Forms.TextBox();
            this.lblOAthClientID = new System.Windows.Forms.Label();
            this.lblOAthSecret = new System.Windows.Forms.Label();
            this.lblOAthRedirectURL = new System.Windows.Forms.Label();
            this.lblblOAthAuthorisationEndpoint = new System.Windows.Forms.Label();
            this.lblOAuthTokenEndpoint = new System.Windows.Forms.Label();
            this.grpOAuth = new System.Windows.Forms.GroupBox();
            this.grpOAuthScope = new System.Windows.Forms.GroupBox();
            this.chkOAuthScopeModeratorReadChatters = new System.Windows.Forms.CheckBox();
            this.chkOAuthScopeChatRead = new System.Windows.Forms.CheckBox();
            this.chkOAuthScopeChatEdit = new System.Windows.Forms.CheckBox();
            this.chkOAuthScopeChannelModerate = new System.Windows.Forms.CheckBox();
            this.txtboxOAuthRedirectURL = new System.Windows.Forms.TextBox();
            this.txtboxOAuthSecret = new System.Windows.Forms.TextBox();
            this.txtboxOAthClientID = new System.Windows.Forms.TextBox();
            this.btnHideRedirectURL = new System.Windows.Forms.Button();
            this.btnHideClientSecret = new System.Windows.Forms.Button();
            this.btnHideClientID = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpIRC = new System.Windows.Forms.GroupBox();
            this.lblIRCIP = new System.Windows.Forms.Label();
            this.txtboxIRCIP = new System.Windows.Forms.TextBox();
            this.lblIRCHost = new System.Windows.Forms.Label();
            this.txtboxIRCHost = new System.Windows.Forms.TextBox();
            this.lblIRCPort = new System.Windows.Forms.Label();
            this.txtboxIRCPort = new System.Windows.Forms.TextBox();
            this.lblIRCNick = new System.Windows.Forms.Label();
            this.txtboxIRCNick = new System.Windows.Forms.TextBox();
            this.lblIRCChannel = new System.Windows.Forms.Label();
            this.txtboxIRCChannel = new System.Windows.Forms.TextBox();
            this.grpOAuth.SuspendLayout();
            this.grpOAuthScope.SuspendLayout();
            this.grpIRC.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxOAuthAuthorisationEndpoint
            // 
            this.txtboxOAuthAuthorisationEndpoint.Location = new System.Drawing.Point(6, 149);
            this.txtboxOAuthAuthorisationEndpoint.Name = "txtboxOAuthAuthorisationEndpoint";
            this.txtboxOAuthAuthorisationEndpoint.Size = new System.Drawing.Size(254, 20);
            this.txtboxOAuthAuthorisationEndpoint.TabIndex = 3;
            // 
            // txtboxOAuthTokenEndpoint
            // 
            this.txtboxOAuthTokenEndpoint.Location = new System.Drawing.Point(6, 188);
            this.txtboxOAuthTokenEndpoint.Name = "txtboxOAuthTokenEndpoint";
            this.txtboxOAuthTokenEndpoint.Size = new System.Drawing.Size(254, 20);
            this.txtboxOAuthTokenEndpoint.TabIndex = 4;
            // 
            // lblOAthClientID
            // 
            this.lblOAthClientID.AutoSize = true;
            this.lblOAthClientID.Location = new System.Drawing.Point(6, 16);
            this.lblOAthClientID.Name = "lblOAthClientID";
            this.lblOAthClientID.Size = new System.Drawing.Size(47, 13);
            this.lblOAthClientID.TabIndex = 6;
            this.lblOAthClientID.Text = "Client ID";
            // 
            // lblOAthSecret
            // 
            this.lblOAthSecret.AutoSize = true;
            this.lblOAthSecret.Location = new System.Drawing.Point(6, 55);
            this.lblOAthSecret.Name = "lblOAthSecret";
            this.lblOAthSecret.Size = new System.Drawing.Size(67, 13);
            this.lblOAthSecret.TabIndex = 6;
            this.lblOAthSecret.Text = "Client Secret";
            // 
            // lblOAthRedirectURL
            // 
            this.lblOAthRedirectURL.AutoSize = true;
            this.lblOAthRedirectURL.Location = new System.Drawing.Point(6, 94);
            this.lblOAthRedirectURL.Name = "lblOAthRedirectURL";
            this.lblOAthRedirectURL.Size = new System.Drawing.Size(72, 13);
            this.lblOAthRedirectURL.TabIndex = 6;
            this.lblOAthRedirectURL.Text = "Redirect URL";
            // 
            // lblblOAthAuthorisationEndpoint
            // 
            this.lblblOAthAuthorisationEndpoint.AutoSize = true;
            this.lblblOAthAuthorisationEndpoint.Location = new System.Drawing.Point(6, 133);
            this.lblblOAthAuthorisationEndpoint.Name = "lblblOAthAuthorisationEndpoint";
            this.lblblOAthAuthorisationEndpoint.Size = new System.Drawing.Size(113, 13);
            this.lblblOAthAuthorisationEndpoint.TabIndex = 6;
            this.lblblOAthAuthorisationEndpoint.Text = "Authorisation Endpoint";
            // 
            // lblOAuthTokenEndpoint
            // 
            this.lblOAuthTokenEndpoint.AutoSize = true;
            this.lblOAuthTokenEndpoint.Location = new System.Drawing.Point(6, 172);
            this.lblOAuthTokenEndpoint.Name = "lblOAuthTokenEndpoint";
            this.lblOAuthTokenEndpoint.Size = new System.Drawing.Size(83, 13);
            this.lblOAuthTokenEndpoint.TabIndex = 6;
            this.lblOAuthTokenEndpoint.Text = "Token Endpoint";
            // 
            // grpOAuth
            // 
            this.grpOAuth.Controls.Add(this.grpOAuthScope);
            this.grpOAuth.Controls.Add(this.txtboxOAuthRedirectURL);
            this.grpOAuth.Controls.Add(this.txtboxOAuthSecret);
            this.grpOAuth.Controls.Add(this.txtboxOAthClientID);
            this.grpOAuth.Controls.Add(this.btnHideRedirectURL);
            this.grpOAuth.Controls.Add(this.btnHideClientSecret);
            this.grpOAuth.Controls.Add(this.btnHideClientID);
            this.grpOAuth.Controls.Add(this.lblOAthClientID);
            this.grpOAuth.Controls.Add(this.lblOAuthTokenEndpoint);
            this.grpOAuth.Controls.Add(this.lblblOAthAuthorisationEndpoint);
            this.grpOAuth.Controls.Add(this.lblOAthRedirectURL);
            this.grpOAuth.Controls.Add(this.txtboxOAuthAuthorisationEndpoint);
            this.grpOAuth.Controls.Add(this.lblOAthSecret);
            this.grpOAuth.Controls.Add(this.txtboxOAuthTokenEndpoint);
            this.grpOAuth.Location = new System.Drawing.Point(12, 12);
            this.grpOAuth.Name = "grpOAuth";
            this.grpOAuth.Size = new System.Drawing.Size(267, 328);
            this.grpOAuth.TabIndex = 7;
            this.grpOAuth.TabStop = false;
            this.grpOAuth.Text = "oAuth";
            // 
            // grpOAuthScope
            // 
            this.grpOAuthScope.Controls.Add(this.chkOAuthScopeModeratorReadChatters);
            this.grpOAuthScope.Controls.Add(this.chkOAuthScopeChatRead);
            this.grpOAuthScope.Controls.Add(this.chkOAuthScopeChatEdit);
            this.grpOAuthScope.Controls.Add(this.chkOAuthScopeChannelModerate);
            this.grpOAuthScope.Location = new System.Drawing.Point(6, 214);
            this.grpOAuthScope.Name = "grpOAuthScope";
            this.grpOAuthScope.Size = new System.Drawing.Size(255, 108);
            this.grpOAuthScope.TabIndex = 11;
            this.grpOAuthScope.TabStop = false;
            this.grpOAuthScope.Text = "Permission Scopes";
            // 
            // chkOAuthScopeModeratorReadChatters
            // 
            this.chkOAuthScopeModeratorReadChatters.AutoSize = true;
            this.chkOAuthScopeModeratorReadChatters.Location = new System.Drawing.Point(6, 88);
            this.chkOAuthScopeModeratorReadChatters.Name = "chkOAuthScopeModeratorReadChatters";
            this.chkOAuthScopeModeratorReadChatters.Size = new System.Drawing.Size(138, 17);
            this.chkOAuthScopeModeratorReadChatters.TabIndex = 0;
            this.chkOAuthScopeModeratorReadChatters.Text = "moderator:read:chatters";
            this.chkOAuthScopeModeratorReadChatters.UseVisualStyleBackColor = true;
            // 
            // chkOAuthScopeChatRead
            // 
            this.chkOAuthScopeChatRead.AutoSize = true;
            this.chkOAuthScopeChatRead.Location = new System.Drawing.Point(6, 65);
            this.chkOAuthScopeChatRead.Name = "chkOAuthScopeChatRead";
            this.chkOAuthScopeChatRead.Size = new System.Drawing.Size(71, 17);
            this.chkOAuthScopeChatRead.TabIndex = 0;
            this.chkOAuthScopeChatRead.Text = "chat:read";
            this.chkOAuthScopeChatRead.UseVisualStyleBackColor = true;
            // 
            // chkOAuthScopeChatEdit
            // 
            this.chkOAuthScopeChatEdit.AutoSize = true;
            this.chkOAuthScopeChatEdit.Location = new System.Drawing.Point(6, 42);
            this.chkOAuthScopeChatEdit.Name = "chkOAuthScopeChatEdit";
            this.chkOAuthScopeChatEdit.Size = new System.Drawing.Size(67, 17);
            this.chkOAuthScopeChatEdit.TabIndex = 0;
            this.chkOAuthScopeChatEdit.Text = "chat:edit";
            this.chkOAuthScopeChatEdit.UseVisualStyleBackColor = true;
            // 
            // chkOAuthScopeChannelModerate
            // 
            this.chkOAuthScopeChannelModerate.AutoSize = true;
            this.chkOAuthScopeChannelModerate.Location = new System.Drawing.Point(6, 19);
            this.chkOAuthScopeChannelModerate.Name = "chkOAuthScopeChannelModerate";
            this.chkOAuthScopeChannelModerate.Size = new System.Drawing.Size(111, 17);
            this.chkOAuthScopeChannelModerate.TabIndex = 0;
            this.chkOAuthScopeChannelModerate.Text = "channel:moderate";
            this.chkOAuthScopeChannelModerate.UseVisualStyleBackColor = true;
            // 
            // txtboxOAuthRedirectURL
            // 
            this.txtboxOAuthRedirectURL.Location = new System.Drawing.Point(6, 110);
            this.txtboxOAuthRedirectURL.Name = "txtboxOAuthRedirectURL";
            this.txtboxOAuthRedirectURL.ReadOnly = true;
            this.txtboxOAuthRedirectURL.Size = new System.Drawing.Size(228, 20);
            this.txtboxOAuthRedirectURL.TabIndex = 10;
            this.txtboxOAuthRedirectURL.UseSystemPasswordChar = true;
            // 
            // txtboxOAuthSecret
            // 
            this.txtboxOAuthSecret.Location = new System.Drawing.Point(6, 71);
            this.txtboxOAuthSecret.Name = "txtboxOAuthSecret";
            this.txtboxOAuthSecret.ReadOnly = true;
            this.txtboxOAuthSecret.Size = new System.Drawing.Size(228, 20);
            this.txtboxOAuthSecret.TabIndex = 9;
            this.txtboxOAuthSecret.UseSystemPasswordChar = true;
            // 
            // txtboxOAthClientID
            // 
            this.txtboxOAthClientID.Location = new System.Drawing.Point(6, 32);
            this.txtboxOAthClientID.Name = "txtboxOAthClientID";
            this.txtboxOAthClientID.ReadOnly = true;
            this.txtboxOAthClientID.Size = new System.Drawing.Size(228, 20);
            this.txtboxOAthClientID.TabIndex = 8;
            this.txtboxOAthClientID.UseSystemPasswordChar = true;
            // 
            // btnHideRedirectURL
            // 
            this.btnHideRedirectURL.Location = new System.Drawing.Point(240, 110);
            this.btnHideRedirectURL.Name = "btnHideRedirectURL";
            this.btnHideRedirectURL.Size = new System.Drawing.Size(20, 20);
            this.btnHideRedirectURL.TabIndex = 7;
            this.btnHideRedirectURL.Text = "*";
            this.btnHideRedirectURL.UseVisualStyleBackColor = true;
            this.btnHideRedirectURL.Click += new System.EventHandler(this.BtnHideRedirectURL_Click);
            // 
            // btnHideClientSecret
            // 
            this.btnHideClientSecret.Location = new System.Drawing.Point(240, 71);
            this.btnHideClientSecret.Name = "btnHideClientSecret";
            this.btnHideClientSecret.Size = new System.Drawing.Size(20, 20);
            this.btnHideClientSecret.TabIndex = 7;
            this.btnHideClientSecret.Text = "*";
            this.btnHideClientSecret.UseVisualStyleBackColor = true;
            this.btnHideClientSecret.Click += new System.EventHandler(this.BtnHideClientSecret_Click);
            // 
            // btnHideClientID
            // 
            this.btnHideClientID.Location = new System.Drawing.Point(240, 32);
            this.btnHideClientID.Name = "btnHideClientID";
            this.btnHideClientID.Size = new System.Drawing.Size(20, 20);
            this.btnHideClientID.TabIndex = 7;
            this.btnHideClientID.Text = "*";
            this.btnHideClientID.UseVisualStyleBackColor = true;
            this.btnHideClientID.Click += new System.EventHandler(this.BtnHideClientID_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(234, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(234, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // grpIRC
            // 
            this.grpIRC.Controls.Add(this.txtboxIRCChannel);
            this.grpIRC.Controls.Add(this.txtboxIRCNick);
            this.grpIRC.Controls.Add(this.txtboxIRCPort);
            this.grpIRC.Controls.Add(this.txtboxIRCHost);
            this.grpIRC.Controls.Add(this.txtboxIRCIP);
            this.grpIRC.Controls.Add(this.lblIRCChannel);
            this.grpIRC.Controls.Add(this.lblIRCNick);
            this.grpIRC.Controls.Add(this.lblIRCPort);
            this.grpIRC.Controls.Add(this.lblIRCHost);
            this.grpIRC.Controls.Add(this.lblIRCIP);
            this.grpIRC.Location = new System.Drawing.Point(285, 12);
            this.grpIRC.Name = "grpIRC";
            this.grpIRC.Size = new System.Drawing.Size(210, 328);
            this.grpIRC.TabIndex = 9;
            this.grpIRC.TabStop = false;
            this.grpIRC.Text = "IRC";
            // 
            // lblIRCIP
            // 
            this.lblIRCIP.AutoSize = true;
            this.lblIRCIP.Location = new System.Drawing.Point(6, 16);
            this.lblIRCIP.Name = "lblIRCIP";
            this.lblIRCIP.Size = new System.Drawing.Size(17, 13);
            this.lblIRCIP.TabIndex = 0;
            this.lblIRCIP.Text = "IP";
            // 
            // txtboxIRCIP
            // 
            this.txtboxIRCIP.Location = new System.Drawing.Point(6, 32);
            this.txtboxIRCIP.Name = "txtboxIRCIP";
            this.txtboxIRCIP.Size = new System.Drawing.Size(197, 20);
            this.txtboxIRCIP.TabIndex = 1;
            // 
            // lblIRCHost
            // 
            this.lblIRCHost.AutoSize = true;
            this.lblIRCHost.Location = new System.Drawing.Point(6, 55);
            this.lblIRCHost.Name = "lblIRCHost";
            this.lblIRCHost.Size = new System.Drawing.Size(29, 13);
            this.lblIRCHost.TabIndex = 0;
            this.lblIRCHost.Text = "Host";
            // 
            // txtboxIRCHost
            // 
            this.txtboxIRCHost.Location = new System.Drawing.Point(6, 71);
            this.txtboxIRCHost.Name = "txtboxIRCHost";
            this.txtboxIRCHost.Size = new System.Drawing.Size(197, 20);
            this.txtboxIRCHost.TabIndex = 1;
            // 
            // lblIRCPort
            // 
            this.lblIRCPort.AutoSize = true;
            this.lblIRCPort.Location = new System.Drawing.Point(6, 94);
            this.lblIRCPort.Name = "lblIRCPort";
            this.lblIRCPort.Size = new System.Drawing.Size(26, 13);
            this.lblIRCPort.TabIndex = 0;
            this.lblIRCPort.Text = "Port";
            // 
            // txtboxIRCPort
            // 
            this.txtboxIRCPort.Location = new System.Drawing.Point(6, 110);
            this.txtboxIRCPort.Name = "txtboxIRCPort";
            this.txtboxIRCPort.Size = new System.Drawing.Size(197, 20);
            this.txtboxIRCPort.TabIndex = 1;
            // 
            // lblIRCNick
            // 
            this.lblIRCNick.AutoSize = true;
            this.lblIRCNick.Location = new System.Drawing.Point(6, 133);
            this.lblIRCNick.Name = "lblIRCNick";
            this.lblIRCNick.Size = new System.Drawing.Size(29, 13);
            this.lblIRCNick.TabIndex = 0;
            this.lblIRCNick.Text = "Nick";
            // 
            // txtboxIRCNick
            // 
            this.txtboxIRCNick.Location = new System.Drawing.Point(6, 149);
            this.txtboxIRCNick.Name = "txtboxIRCNick";
            this.txtboxIRCNick.Size = new System.Drawing.Size(197, 20);
            this.txtboxIRCNick.TabIndex = 1;
            // 
            // lblIRCChannel
            // 
            this.lblIRCChannel.AutoSize = true;
            this.lblIRCChannel.Location = new System.Drawing.Point(6, 175);
            this.lblIRCChannel.Name = "lblIRCChannel";
            this.lblIRCChannel.Size = new System.Drawing.Size(46, 13);
            this.lblIRCChannel.TabIndex = 0;
            this.lblIRCChannel.Text = "Channel";
            // 
            // txtboxIRCChannel
            // 
            this.txtboxIRCChannel.Location = new System.Drawing.Point(6, 191);
            this.txtboxIRCChannel.Name = "txtboxIRCChannel";
            this.txtboxIRCChannel.Size = new System.Drawing.Size(197, 20);
            this.txtboxIRCChannel.TabIndex = 1;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 378);
            this.Controls.Add(this.grpIRC);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpOAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.grpOAuth.ResumeLayout(false);
            this.grpOAuth.PerformLayout();
            this.grpOAuthScope.ResumeLayout(false);
            this.grpOAuthScope.PerformLayout();
            this.grpIRC.ResumeLayout(false);
            this.grpIRC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtboxOAuthAuthorisationEndpoint;
        private System.Windows.Forms.TextBox txtboxOAuthTokenEndpoint;
        private System.Windows.Forms.Label lblOAthClientID;
        private System.Windows.Forms.Label lblOAthSecret;
        private System.Windows.Forms.Label lblOAthRedirectURL;
        private System.Windows.Forms.Label lblblOAthAuthorisationEndpoint;
        private System.Windows.Forms.Label lblOAuthTokenEndpoint;
        private System.Windows.Forms.GroupBox grpOAuth;
        private System.Windows.Forms.Button btnHideRedirectURL;
        private System.Windows.Forms.Button btnHideClientSecret;
        private System.Windows.Forms.Button btnHideClientID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtboxOAuthRedirectURL;
        private System.Windows.Forms.TextBox txtboxOAuthSecret;
        private System.Windows.Forms.TextBox txtboxOAthClientID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpOAuthScope;
        private System.Windows.Forms.CheckBox chkOAuthScopeModeratorReadChatters;
        private System.Windows.Forms.CheckBox chkOAuthScopeChatRead;
        private System.Windows.Forms.CheckBox chkOAuthScopeChatEdit;
        private System.Windows.Forms.CheckBox chkOAuthScopeChannelModerate;
        private System.Windows.Forms.GroupBox grpIRC;
        private System.Windows.Forms.TextBox txtboxIRCIP;
        private System.Windows.Forms.Label lblIRCIP;
        private System.Windows.Forms.TextBox txtboxIRCPort;
        private System.Windows.Forms.TextBox txtboxIRCHost;
        private System.Windows.Forms.Label lblIRCPort;
        private System.Windows.Forms.Label lblIRCHost;
        private System.Windows.Forms.TextBox txtboxIRCChannel;
        private System.Windows.Forms.TextBox txtboxIRCNick;
        private System.Windows.Forms.Label lblIRCChannel;
        private System.Windows.Forms.Label lblIRCNick;
    }
}