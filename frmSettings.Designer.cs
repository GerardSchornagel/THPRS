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
            this.txtboxAuthorisationEndpoint = new System.Windows.Forms.TextBox();
            this.txtboxTokenEndpoint = new System.Windows.Forms.TextBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.lblRedirectURL = new System.Windows.Forms.Label();
            this.lblAuthorisationEndpoint = new System.Windows.Forms.Label();
            this.lblTokenEndpoint = new System.Windows.Forms.Label();
            this.grpDeveloper = new System.Windows.Forms.GroupBox();
            this.grpDeveloperScopes = new System.Windows.Forms.GroupBox();
            this.chkScopesModeratorReadChatters = new System.Windows.Forms.CheckBox();
            this.chkScopesChatRead = new System.Windows.Forms.CheckBox();
            this.chkScopesChatEdit = new System.Windows.Forms.CheckBox();
            this.chkScopesChannelModerate = new System.Windows.Forms.CheckBox();
            this.txtboxRedirectURL = new System.Windows.Forms.TextBox();
            this.txtboxClientSecret = new System.Windows.Forms.TextBox();
            this.txtboxClientID = new System.Windows.Forms.TextBox();
            this.btnHideRedirectURL = new System.Windows.Forms.Button();
            this.btnHideClientSecret = new System.Windows.Forms.Button();
            this.btnHideClientID = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDeveloper.SuspendLayout();
            this.grpDeveloperScopes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxAuthorisationEndpoint
            // 
            this.txtboxAuthorisationEndpoint.Location = new System.Drawing.Point(6, 149);
            this.txtboxAuthorisationEndpoint.Name = "txtboxAuthorisationEndpoint";
            this.txtboxAuthorisationEndpoint.Size = new System.Drawing.Size(254, 20);
            this.txtboxAuthorisationEndpoint.TabIndex = 3;
            // 
            // txtboxTokenEndpoint
            // 
            this.txtboxTokenEndpoint.Location = new System.Drawing.Point(6, 188);
            this.txtboxTokenEndpoint.Name = "txtboxTokenEndpoint";
            this.txtboxTokenEndpoint.Size = new System.Drawing.Size(254, 20);
            this.txtboxTokenEndpoint.TabIndex = 4;
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(6, 16);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(47, 13);
            this.lblClientID.TabIndex = 6;
            this.lblClientID.Text = "Client ID";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(6, 55);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(67, 13);
            this.lblClientSecret.TabIndex = 6;
            this.lblClientSecret.Text = "Client Secret";
            // 
            // lblRedirectURL
            // 
            this.lblRedirectURL.AutoSize = true;
            this.lblRedirectURL.Location = new System.Drawing.Point(6, 94);
            this.lblRedirectURL.Name = "lblRedirectURL";
            this.lblRedirectURL.Size = new System.Drawing.Size(72, 13);
            this.lblRedirectURL.TabIndex = 6;
            this.lblRedirectURL.Text = "Redirect URL";
            // 
            // lblAuthorisationEndpoint
            // 
            this.lblAuthorisationEndpoint.AutoSize = true;
            this.lblAuthorisationEndpoint.Location = new System.Drawing.Point(6, 133);
            this.lblAuthorisationEndpoint.Name = "lblAuthorisationEndpoint";
            this.lblAuthorisationEndpoint.Size = new System.Drawing.Size(113, 13);
            this.lblAuthorisationEndpoint.TabIndex = 6;
            this.lblAuthorisationEndpoint.Text = "Authorisation Endpoint";
            // 
            // lblTokenEndpoint
            // 
            this.lblTokenEndpoint.AutoSize = true;
            this.lblTokenEndpoint.Location = new System.Drawing.Point(6, 172);
            this.lblTokenEndpoint.Name = "lblTokenEndpoint";
            this.lblTokenEndpoint.Size = new System.Drawing.Size(83, 13);
            this.lblTokenEndpoint.TabIndex = 6;
            this.lblTokenEndpoint.Text = "Token Endpoint";
            // 
            // grpDeveloper
            // 
            this.grpDeveloper.Controls.Add(this.grpDeveloperScopes);
            this.grpDeveloper.Controls.Add(this.txtboxRedirectURL);
            this.grpDeveloper.Controls.Add(this.txtboxClientSecret);
            this.grpDeveloper.Controls.Add(this.txtboxClientID);
            this.grpDeveloper.Controls.Add(this.btnHideRedirectURL);
            this.grpDeveloper.Controls.Add(this.btnHideClientSecret);
            this.grpDeveloper.Controls.Add(this.btnHideClientID);
            this.grpDeveloper.Controls.Add(this.lblClientID);
            this.grpDeveloper.Controls.Add(this.lblTokenEndpoint);
            this.grpDeveloper.Controls.Add(this.lblAuthorisationEndpoint);
            this.grpDeveloper.Controls.Add(this.lblRedirectURL);
            this.grpDeveloper.Controls.Add(this.txtboxAuthorisationEndpoint);
            this.grpDeveloper.Controls.Add(this.lblClientSecret);
            this.grpDeveloper.Controls.Add(this.txtboxTokenEndpoint);
            this.grpDeveloper.Location = new System.Drawing.Point(12, 12);
            this.grpDeveloper.Name = "grpDeveloper";
            this.grpDeveloper.Size = new System.Drawing.Size(267, 328);
            this.grpDeveloper.TabIndex = 7;
            this.grpDeveloper.TabStop = false;
            this.grpDeveloper.Text = "Developer Settings (DON\'T change)";
            // 
            // grpDeveloperScopes
            // 
            this.grpDeveloperScopes.Controls.Add(this.chkScopesModeratorReadChatters);
            this.grpDeveloperScopes.Controls.Add(this.chkScopesChatRead);
            this.grpDeveloperScopes.Controls.Add(this.chkScopesChatEdit);
            this.grpDeveloperScopes.Controls.Add(this.chkScopesChannelModerate);
            this.grpDeveloperScopes.Location = new System.Drawing.Point(6, 214);
            this.grpDeveloperScopes.Name = "grpDeveloperScopes";
            this.grpDeveloperScopes.Size = new System.Drawing.Size(255, 108);
            this.grpDeveloperScopes.TabIndex = 11;
            this.grpDeveloperScopes.TabStop = false;
            this.grpDeveloperScopes.Text = "Permission Scopes";
            // 
            // chkScopesModeratorReadChatters
            // 
            this.chkScopesModeratorReadChatters.AutoSize = true;
            this.chkScopesModeratorReadChatters.Location = new System.Drawing.Point(6, 88);
            this.chkScopesModeratorReadChatters.Name = "chkScopesModeratorReadChatters";
            this.chkScopesModeratorReadChatters.Size = new System.Drawing.Size(138, 17);
            this.chkScopesModeratorReadChatters.TabIndex = 0;
            this.chkScopesModeratorReadChatters.Text = "moderator:read:chatters";
            this.chkScopesModeratorReadChatters.UseVisualStyleBackColor = true;
            // 
            // chkScopesChatRead
            // 
            this.chkScopesChatRead.AutoSize = true;
            this.chkScopesChatRead.Location = new System.Drawing.Point(6, 65);
            this.chkScopesChatRead.Name = "chkScopesChatRead";
            this.chkScopesChatRead.Size = new System.Drawing.Size(71, 17);
            this.chkScopesChatRead.TabIndex = 0;
            this.chkScopesChatRead.Text = "chat:read";
            this.chkScopesChatRead.UseVisualStyleBackColor = true;
            // 
            // chkScopesChatEdit
            // 
            this.chkScopesChatEdit.AutoSize = true;
            this.chkScopesChatEdit.Location = new System.Drawing.Point(6, 42);
            this.chkScopesChatEdit.Name = "chkScopesChatEdit";
            this.chkScopesChatEdit.Size = new System.Drawing.Size(67, 17);
            this.chkScopesChatEdit.TabIndex = 0;
            this.chkScopesChatEdit.Text = "chat:edit";
            this.chkScopesChatEdit.UseVisualStyleBackColor = true;
            // 
            // chkScopesChannelModerate
            // 
            this.chkScopesChannelModerate.AutoSize = true;
            this.chkScopesChannelModerate.Location = new System.Drawing.Point(6, 19);
            this.chkScopesChannelModerate.Name = "chkScopesChannelModerate";
            this.chkScopesChannelModerate.Size = new System.Drawing.Size(111, 17);
            this.chkScopesChannelModerate.TabIndex = 0;
            this.chkScopesChannelModerate.Text = "channel:moderate";
            this.chkScopesChannelModerate.UseVisualStyleBackColor = true;
            // 
            // txtboxRedirectURL
            // 
            this.txtboxRedirectURL.Location = new System.Drawing.Point(6, 110);
            this.txtboxRedirectURL.Name = "txtboxRedirectURL";
            this.txtboxRedirectURL.ReadOnly = true;
            this.txtboxRedirectURL.Size = new System.Drawing.Size(228, 20);
            this.txtboxRedirectURL.TabIndex = 10;
            this.txtboxRedirectURL.UseSystemPasswordChar = true;
            // 
            // txtboxClientSecret
            // 
            this.txtboxClientSecret.Location = new System.Drawing.Point(6, 71);
            this.txtboxClientSecret.Name = "txtboxClientSecret";
            this.txtboxClientSecret.ReadOnly = true;
            this.txtboxClientSecret.Size = new System.Drawing.Size(228, 20);
            this.txtboxClientSecret.TabIndex = 9;
            this.txtboxClientSecret.UseSystemPasswordChar = true;
            // 
            // txtboxClientID
            // 
            this.txtboxClientID.Location = new System.Drawing.Point(6, 32);
            this.txtboxClientID.Name = "txtboxClientID";
            this.txtboxClientID.ReadOnly = true;
            this.txtboxClientID.Size = new System.Drawing.Size(228, 20);
            this.txtboxClientID.TabIndex = 8;
            this.txtboxClientID.UseSystemPasswordChar = true;
            // 
            // btnHideRedirectURL
            // 
            this.btnHideRedirectURL.Location = new System.Drawing.Point(240, 110);
            this.btnHideRedirectURL.Name = "btnHideRedirectURL";
            this.btnHideRedirectURL.Size = new System.Drawing.Size(20, 20);
            this.btnHideRedirectURL.TabIndex = 7;
            this.btnHideRedirectURL.Text = "*";
            this.btnHideRedirectURL.UseVisualStyleBackColor = true;
            this.btnHideRedirectURL.Click += new System.EventHandler(this.btnHideRedirectURL_Click);
            // 
            // btnHideClientSecret
            // 
            this.btnHideClientSecret.Location = new System.Drawing.Point(240, 71);
            this.btnHideClientSecret.Name = "btnHideClientSecret";
            this.btnHideClientSecret.Size = new System.Drawing.Size(20, 20);
            this.btnHideClientSecret.TabIndex = 7;
            this.btnHideClientSecret.Text = "*";
            this.btnHideClientSecret.UseVisualStyleBackColor = true;
            this.btnHideClientSecret.Click += new System.EventHandler(this.btnHideClientSecret_Click);
            // 
            // btnHideClientID
            // 
            this.btnHideClientID.Location = new System.Drawing.Point(240, 32);
            this.btnHideClientID.Name = "btnHideClientID";
            this.btnHideClientID.Size = new System.Drawing.Size(20, 20);
            this.btnHideClientID.TabIndex = 7;
            this.btnHideClientID.Text = "*";
            this.btnHideClientID.UseVisualStyleBackColor = true;
            this.btnHideClientID.Click += new System.EventHandler(this.btnHideClientID_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(148, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpDeveloper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpDeveloper.ResumeLayout(false);
            this.grpDeveloper.PerformLayout();
            this.grpDeveloperScopes.ResumeLayout(false);
            this.grpDeveloperScopes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtboxAuthorisationEndpoint;
        private System.Windows.Forms.TextBox txtboxTokenEndpoint;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.Label lblRedirectURL;
        private System.Windows.Forms.Label lblAuthorisationEndpoint;
        private System.Windows.Forms.Label lblTokenEndpoint;
        private System.Windows.Forms.GroupBox grpDeveloper;
        private System.Windows.Forms.Button btnHideRedirectURL;
        private System.Windows.Forms.Button btnHideClientSecret;
        private System.Windows.Forms.Button btnHideClientID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtboxRedirectURL;
        private System.Windows.Forms.TextBox txtboxClientSecret;
        private System.Windows.Forms.TextBox txtboxClientID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpDeveloperScopes;
        private System.Windows.Forms.CheckBox chkScopesModeratorReadChatters;
        private System.Windows.Forms.CheckBox chkScopesChatRead;
        private System.Windows.Forms.CheckBox chkScopesChatEdit;
        private System.Windows.Forms.CheckBox chkScopesChannelModerate;
    }
}