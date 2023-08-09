using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THPRS
{
    public partial class frmSettings : Form
    {
        Configuration configSettings;

        internal frmSettings(Configuration configSettings)
        {
            InitializeComponent();
            this.configSettings = configSettings;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtboxClientID.Text = configSettings.ClientID;
            txtboxClientSecret.Text = configSettings.ClientSecret;
            txtboxRedirectURL.Text = configSettings.RedirectUri;
            txtboxAuthorisationEndpoint.Text = configSettings.AuthorizationEndpoint;
            txtboxTokenEndpoint.Text = configSettings.TokenEndpoint;
            chkScopesChannelModerate.Checked = configSettings.ScopeChannelModerator;
            chkScopesChatEdit.Checked = configSettings.ScopeChatEdit;
            chkScopesChatRead.Checked = configSettings.ScopeChatRead;
            chkScopesModeratorReadChatters.Checked = configSettings.ScopeModeratorReadChatters;
        }

        private void btnHideClientID_Click(object sender, EventArgs e)
        {
            txtboxClientID.UseSystemPasswordChar = !txtboxClientID.UseSystemPasswordChar;
            txtboxClientID.ReadOnly = !txtboxClientID.ReadOnly;
        }

        private void btnHideClientSecret_Click(object sender, EventArgs e)
        {
            txtboxClientSecret.UseSystemPasswordChar = !txtboxClientSecret.UseSystemPasswordChar;
            txtboxClientSecret.ReadOnly = !txtboxClientSecret.ReadOnly;
        }

        private void btnHideRedirectURL_Click(object sender, EventArgs e)
        {
            txtboxRedirectURL.UseSystemPasswordChar = !txtboxRedirectURL.UseSystemPasswordChar;
            txtboxRedirectURL.ReadOnly = !txtboxRedirectURL.ReadOnly;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configSettings.ClientID = txtboxClientID.Text;
            configSettings.ClientSecret = txtboxClientSecret.Text;
            configSettings.RedirectUri = txtboxRedirectURL.Text;
            configSettings.AuthorizationEndpoint = txtboxAuthorisationEndpoint.Text;
            configSettings.TokenEndpoint = txtboxTokenEndpoint.Text;
            configSettings.ScopeChannelModerator = chkScopesChannelModerate.Checked;
            configSettings.ScopeChatEdit = chkScopesChatEdit.Checked;
            configSettings.ScopeChatRead = chkScopesChatRead.Checked;
            configSettings.ScopeModeratorReadChatters = chkScopesModeratorReadChatters.Checked;
            ConfigurationManager.WriteConfiguration(configSettings);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
