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

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            txtboxOAthClientID.Text = configSettings.OAuthClientID;
            txtboxOAuthSecret.Text = configSettings.OAuthClientSecret;
            txtboxOAuthRedirectURL.Text = configSettings.OAuthRedirectUri;
            txtboxOAuthAuthorisationEndpoint.Text = configSettings.OAuthAuthorizationEndpoint;
            txtboxOAuthTokenEndpoint.Text = configSettings.OAuthTokenEndpoint;
            chkOAuthScopeChannelModerate.Checked = configSettings.OAuthScopeChannelModerator;
            chkOAuthScopeChatEdit.Checked = configSettings.OAuthScopeChatEdit;
            chkOAuthScopeChatRead.Checked = configSettings.OAuthScopeChatRead;
            chkOAuthScopeModeratorReadChatters.Checked = configSettings.OAuthScopeModeratorReadChatters;
            txtboxIRCIP.Text = configSettings.IRCIP;
            txtboxIRCHost.Text = configSettings.IRCHost;
            txtboxIRCPort.Text = configSettings.IRCPort.ToString();
            txtboxIRCNick.Text = configSettings.IRCNick;
            txtboxIRCChannel.Text = configSettings.IRCChannel;
        }

        private void BtnHideClientID_Click(object sender, EventArgs e)
        {
            txtboxOAthClientID.UseSystemPasswordChar = !txtboxOAthClientID.UseSystemPasswordChar;
            txtboxOAthClientID.ReadOnly = !txtboxOAthClientID.ReadOnly;
        }

        private void BtnHideClientSecret_Click(object sender, EventArgs e)
        {
            txtboxOAuthSecret.UseSystemPasswordChar = !txtboxOAuthSecret.UseSystemPasswordChar;
            txtboxOAuthSecret.ReadOnly = !txtboxOAuthSecret.ReadOnly;
        }

        private void BtnHideRedirectURL_Click(object sender, EventArgs e)
        {
            txtboxOAuthRedirectURL.UseSystemPasswordChar = !txtboxOAuthRedirectURL.UseSystemPasswordChar;
            txtboxOAuthRedirectURL.ReadOnly = !txtboxOAuthRedirectURL.ReadOnly;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            configSettings.OAuthClientID = txtboxOAthClientID.Text;
            configSettings.OAuthClientSecret = txtboxOAuthSecret.Text;
            configSettings.OAuthRedirectUri = txtboxOAuthRedirectURL.Text;
            configSettings.OAuthAuthorizationEndpoint = txtboxOAuthAuthorisationEndpoint.Text;
            configSettings.OAuthTokenEndpoint = txtboxOAuthTokenEndpoint.Text;
            configSettings.OAuthScopeChannelModerator = chkOAuthScopeChannelModerate.Checked;
            configSettings.OAuthScopeChatEdit = chkOAuthScopeChatEdit.Checked;
            configSettings.OAuthScopeChatRead = chkOAuthScopeChatRead.Checked;
            configSettings.OAuthScopeModeratorReadChatters = chkOAuthScopeModeratorReadChatters.Checked;
            configSettings.IRCIP = txtboxIRCIP.Text;
            configSettings.IRCHost = txtboxIRCHost.Text;
            configSettings.IRCPort = int.Parse(txtboxIRCPort.Text);
            configSettings.IRCNick = txtboxIRCNick.Text;
            configSettings.IRCChannel = txtboxIRCChannel.Text;
            ConfigurationManager.WriteConfiguration(configSettings);

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
