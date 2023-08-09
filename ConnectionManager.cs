using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Windows.Forms;

namespace THPRS
{
    class ConnectionManager
    {
        static string generateRandomHexCode()
        {
            var random = new Random();
            var hexChars = "0123456789ABCDEF";
            var hexCode = new char[16];

            for (int i = 0; i < hexCode.Length; i++)
            {
                hexCode[i] = hexChars[random.Next(hexChars.Length)];
            }

            return new string(hexCode);
        }

        public static void oauthAuthorizationRequest(Configuration config, Connection connect, ToolStripStatusLabel progressText, ToolStripProgressBar progressValue)
        {
            string scope = "";
            if (config.ScopeChannelModerator == true) { scope += "channel:moderator "; }
            if (config.ScopeChatEdit == true) { scope += "chat:edit "; }
            if (config.ScopeChatRead == true) { scope += "chat:read "; }
            if (config.ScopeModeratorReadChatters == true) { scope += "moderator:read:chatters "; }
            scope = scope.TrimEnd();

            connect.oauthState = generateRandomHexCode();
            string authorizationCode;

            progressText.Text = "Connecting to Twitch; Authorization Request; Building URI";
            progressValue.Value = 8;
            // Build the URL for an OAuth AUTHorization Token
            var dictAuthorization = new Dictionary<string, string> {
    {"client_id", config.ClientID},
    {"redirect_uri", config.RedirectUri},
    {"response_type", "code"},
    {"scope", scope},
    {"state", connect.oauthState } };
            var requestQuery = new FormUrlEncodedContent(dictAuthorization);
            var uriBuilder = new UriBuilder(config.AuthorizationEndpoint);
            uriBuilder.Query = requestQuery.ReadAsStringAsync().Result.ToString();
            string stringAuthorizationURL = uriBuilder.Uri.AbsoluteUri;

            progressText.Text = "Connecting to Twitch; Authorization Request; Start Listener";
            progressValue.Value = 16;
            // Opens Listener for localhost for redirects
            var listener = new HttpListener();
            listener.Prefixes.Add(config.RedirectUri + "/");
            listener.Start();

            progressText.Text = "Connecting to Twitch; Authorization Request; Opening URL in browser";
            progressValue.Value = 25;
            // Opens URL in standard browser
            Process.Start(new ProcessStartInfo(stringAuthorizationURL) { UseShellExecute = true });

            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                // Check for redirection to localhost
                if (ctx.Request.Url.ToString().StartsWith(config.RedirectUri))
                {
                    listener.Close();
                    progressText.Text = "Connecting to Twitch; Authorization Request; Response received";
                    progressValue.Value = 40;

                    // Parse URL to Dictonary
                    var stringX = ctx.Request.Url.Query.TrimStart('?');
                    stringX = stringX.Replace("%3A", ":");
                    stringX = stringX.Replace('+', ' ');
                    var arrayX = stringX.Split('&');
                    var dictX = new Dictionary<string, string>();
                    foreach (var x in arrayX)
                    {
                        dictX.Add(x.Split('=')[0], x.Split('=')[1].TrimStart('='));
                    }

                    progressText.Text = "Connecting to Twitch; Authorization Request; Validity check of response";
                    progressValue.Value = 33;
                    // Check for validity and parse to variables
                    string valueState = "";
                    if (dictX.TryGetValue("state", out valueState))
                    {
                        if (valueState == connect.oauthState)
                        {
                            //Valid response > process
                            //code scope state
                            dictX.TryGetValue("code", out authorizationCode);

                            connect.authorizationCode = authorizationCode;
                            progressText.Text = "Connecting to Twitch; Authorization Request; Valid response";
                            progressValue.Value = 42;
                        }
                        else
                        {
                            //Mismatched or missing oauthState > Try Again
                            MessageBox.Show("oauth respnose is not valid, wrong or missing State.");
                            MessageBox.Show(valueState + " != " + connect.oauthState);

                            progressText.Text = "Connecting to Twitch; Authorization Request; Unvalid Response";
                            progressValue.Value = 42;
                        }
                    }
                    break;
                }
            }
        }

        public static void oauthTokenRequest(Configuration config, Connection connect, ToolStripStatusLabel progressText, ToolStripProgressBar progressValue)
        {
            string tokenCode;
            string tokenRefresh;
            string tokenExpiresIn;

            progressText.Text = "Connecting to Twitch; Token Request; Building URI";
            progressValue.Value = 60;
            // Build the URL for an OAuth ACCESS Token and send

            var queryDict = new Dictionary<string, string>{
    {"client_id", config.ClientID},
    {"client_secret", config.ClientSecret},
    {"redirect_uri", config.RedirectUri},
    {"code", connect.authorizationCode},
    {"grant_type", "authorization_code"} };
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            progressText.Text = "Connecting to Twitch; Token Request; Send request";
            progressValue.Value = 70;
            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, config.TokenEndpoint) { Content = requestContent };

            progressText.Text = "Connecting to Twitch; Token Request; Await token-response";
            progressValue.Value = 80;
            // Awaiting response
            var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            while (true)
            {
                if (response.Result.Content.Headers.ContentLength != null)
                {
                    progressText.Text = "Connecting to Twitch; Token Request; Formatting Response";
                    progressValue.Value = 90;

                    // Parse Response to Dictonary
                    var responseContent = response.Result.Content.ReadAsStringAsync().Result;

                    responseContent = responseContent.ToString().Remove(0, 2);
                    responseContent = responseContent.Remove(responseContent.Length - 3, 3);
                    responseContent = responseContent.Replace("\\", "");
                    responseContent = responseContent.Replace("\"", "");
                    responseContent = responseContent.Replace("[", "");
                    responseContent = responseContent.Replace("]", "");
                    responseContent = responseContent.Replace("it,ch", "it+ch");
                    responseContent = responseContent.Replace("chat:", "chat=");
                    responseContent = responseContent.Replace("channel:", "channel=");
                    responseContent = responseContent.Replace("moderator:", "moderator=");
                    responseContent = responseContent.Replace("read:", "read=");


                    var arrayX = responseContent.Split(',');
                    var dictX = new Dictionary<string, string>();
                    foreach (var x in arrayX)
                    {
                        // Foreach "," Dictonary <string:string>.Add
                        dictX.Add(x.Split(':')[0], x.Split(':')[1].TrimStart(':'));
                    }

                    // Check for validity and parse to variables
                    dictX.TryGetValue("access_token", out tokenCode);
                    dictX.TryGetValue("expires_in", out tokenExpiresIn);
                    dictX.TryGetValue("refresh_token", out tokenRefresh);

                    connect.tokenCode = tokenCode;
                    connect.tokenExpiresIn = tokenExpiresIn;
                    connect.tokenRefresh = tokenRefresh;

                    progressText.Text = "Connecting to Twitch; SUCCES; refresh_in=" + tokenExpiresIn + " refresh_token=" + tokenRefresh;
                    progressValue.Value = 100;
                    break;
                }
            }
        }

        public static void oauthRefreshRequest(Configuration config, Connection connect ,ToolStripStatusLabel progressText, ToolStripProgressBar progressValue, ToolStripStatusLabel progressConnection)
        {
            string tokenCode;
            string tokenRefresh;

            progressValue.Value = 0;
            progressConnection.Text = "Refreshing";
            progressConnection.ForeColor = System.Drawing.Color.Yellow;

            progressText.Text = "Refresh Token; Building Request";
            progressValue.Value = 10;
            var queryDict = new Dictionary<string, string>{
    {"client_id", config.ClientID},
    {"client_secret", config.ClientSecret},
    {"grant_type", "refresh_token"},
    {"refresh_token", connect.tokenRefresh} };
            progressText.Text = "Refresh Token; Building Request";
            progressValue.Value = 30;
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            progressText.Text = "Refresh Token; Send request";
            progressValue.Value = 60;
            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, config.TokenEndpoint) { Content = requestContent };

            progressText.Text = "Refresh Token; Await token-response";
            progressValue.Value = 80;
            // Awaiting response
            var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            while (true)
            {
                if (response.Result.Content.Headers.ContentLength != null)
                {
                    progressText.Text = "Refresh Token; token-response; Formatting Response";
                    progressValue.Value = 90;

                    // Parse Response to Dictonary
                    var responseContent = response.Result.Content.ReadAsStringAsync().Result;

                    responseContent = responseContent.ToString().Remove(0, 2);
                    responseContent = responseContent.Remove(responseContent.Length - 3, 3);
                    responseContent = responseContent.Replace("\\", "");
                    responseContent = responseContent.Replace("\"", "");
                    responseContent = responseContent.Replace("[", "");
                    responseContent = responseContent.Replace("]", "");
                    responseContent = responseContent.Replace("it,ch", "it+ch");
                    responseContent = responseContent.Replace("chat:", "chat=");

                    var arrayX = responseContent.Split(',');
                    var dictX = new Dictionary<string, string>();
                    foreach (var x in arrayX)
                    {
                        // Foreach "," Dictonary <string:string>.Add
                        dictX.Add(x.Split(':')[0], x.Split(':')[1].TrimStart(':'));
                    }

                    // Check for validity and parse to variables
                    dictX.TryGetValue("access_token", out tokenCode);
                    dictX.TryGetValue("refresh_token", out tokenRefresh);

                    connect.tokenCode = tokenCode;
                    connect.tokenRefresh = tokenRefresh;

                    progressText.Text = "Refresh Token; SUCCES";
                    progressValue.Value = 100;
                    progressConnection.Text = "Connected";
                    progressConnection.ForeColor = System.Drawing.Color.Green;
                    break;
                }
            }
        }
    }
}

class Connection
{
    public string authorizationCode { get; set; }
    public string oauthState { get; set; }
    public string tokenCode { get; set; }
    public string tokenRefresh { get; set; }
    public string tokenExpiresIn { get; set; }
    public string tokenType { get; set; }
}
