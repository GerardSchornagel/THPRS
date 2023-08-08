using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THPRS
{
    class Connection
    {
        private static string clientId = "a1dfrppzjrula2poe9sthth3uwae8c";
        private static string clientSecret = "8embxdsxu4mvey92hd5815zyql8vq3";
        private static string redirectUri = "http://localhost:3000";
        private static string authorizationEndpoint = "https://id.twitch.tv/oauth2/authorize";
        private static string authorizationCode = "";
        private static string authorizationScope = "chat:read chat:edit";
        private static string oauthState = "";
        private static string tokenEndpoint = "https://id.twitch.tv/oauth2/token";
        private static string tokenCode = "";
        private static string tokenRefresh = "";
        public static string tokenExpiresIn = "";
        private static string tokenType = "";

        public static void connectTwitch(ToolStripStatusLabel progressText, ToolStripProgressBar progressValue, ToolStripStatusLabel progressConnection)
        {
            progressConnection.Text = "Disconnected";
            progressConnection.ForeColor = System.Drawing.Color.Red;

            progressText.Text = "Connecting to Twitch; Authorization Request";
            progressValue.Value = 0;
            oauthAuthorizationRequest(progressText, progressValue);

            progressText.Text = "Connecting to Twitch; Token Request";
            oauthTokenRequest(progressText, progressValue);

            progressConnection.Text = "Connected";
            progressConnection.ForeColor = System.Drawing.Color.Green;
        }

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

        static void oauthAuthorizationRequest(ToolStripStatusLabel progressText, ToolStripProgressBar progressValue)
        {
            oauthState = generateRandomHexCode();

            progressText.Text = "Connecting to Twitch; Authorization Request; Building URI";
            progressValue.Value = 8;
            // Build the URL for an OAuth AUTHorization Token
            var dictAuthorization = new Dictionary<string, string> {
    {"client_id", clientId},
    {"redirect_uri", redirectUri},
    {"response_type", "code"},
    {"scope", authorizationScope},
    {"state", oauthState } };
            var requestQuery = new FormUrlEncodedContent(dictAuthorization);
            var uriBuilder = new UriBuilder(authorizationEndpoint);
            uriBuilder.Query = requestQuery.ReadAsStringAsync().Result.ToString();
            string stringAuthorizationURL = uriBuilder.Uri.AbsoluteUri;

            progressText.Text = "Connecting to Twitch; Authorization Request; Start Listener";
            progressValue.Value = 16;
            // Opens Listener for localhost for redirects
            var listener = new HttpListener();
            listener.Prefixes.Add(redirectUri + "/");
            listener.Start();

            progressText.Text = "Connecting to Twitch; Authorization Request; Opening URL in browser";
            progressValue.Value = 25;
            // Opens URL in standard browser
            Process.Start(new ProcessStartInfo(stringAuthorizationURL) { UseShellExecute = true });

            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                // Check for redirection to localhost
                if (ctx.Request.Url.ToString().StartsWith(redirectUri))
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
                        if (valueState == oauthState)
                        {
                            //Valid response > process
                            //code scope state
                            dictX.TryGetValue("code", out authorizationCode);
                            dictX.TryGetValue("scope", out authorizationScope);

                            progressText.Text = "Connecting to Twitch; Authorization Request; Valid response";
                            progressValue.Value = 42;
                        }
                        else
                        {
                            //Mismatched or missing oauthState > Try Again
                            MessageBox.Show("oauth respnose is not valid, wrong or missing State.");
                            MessageBox.Show(valueState + " != " + oauthState);

                            progressText.Text = "Connecting to Twitch; Authorization Request; Unvalid Response";
                            progressValue.Value = 42;
                        }
                    }
                    break;
                }
            }
        }

        static void oauthTokenRequest(ToolStripStatusLabel progressText, ToolStripProgressBar progressValue)
        {
            progressText.Text = "Connecting to Twitch; Token Request; Building URI";
            progressValue.Value = 60;
            // Build the URL for an OAuth ACCESS Token and send

            var queryDict = new Dictionary<string, string>{
    {"client_id", clientId},
    {"client_secret", clientSecret},
    {"redirect_uri", redirectUri},
    {"code", authorizationCode},
    {"grant_type", "authorization_code"} };
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            progressText.Text = "Connecting to Twitch; Token Request; Send request";
            progressValue.Value = 70;
            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint) { Content = requestContent };

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

                    var arrayX = responseContent.Split(',');
                    var dictX = new Dictionary<string, string>();
                    foreach (var x in arrayX)
                    {
                        // Foreach "," Dictonary <string:string>.Add
                        dictX.Add(x.Split(':')[0], x.Split(':')[1].TrimStart(':'));
                    }
                    //Fix scope
                    authorizationScope.Replace('=', ':');
                    authorizationScope.Replace("+", " ");

                    // Check for validity and parse to variables
                    dictX.TryGetValue("access_token", out tokenCode);
                    dictX.TryGetValue("expires_in", out tokenExpiresIn);
                    dictX.TryGetValue("refresh_token", out tokenRefresh);
                    dictX.TryGetValue("scope", out authorizationScope);
                    dictX.TryGetValue("token_type", out tokenType);
                    progressText.Text = "Connecting to Twitch; SUCCES; refresh_in=" + tokenExpiresIn + " refresh_token=" + tokenRefresh;
                    progressValue.Value = 100;
                    break;
                }
            }
        }

        public static void oauthRefreshRequest(ToolStripStatusLabel progressText, ToolStripProgressBar progressValue, ToolStripStatusLabel progressConnection)
        {
            progressValue.Value = 0;
            progressConnection.Text = "Refreshing";
            progressConnection.ForeColor = System.Drawing.Color.Yellow;

            progressText.Text = "Refresh Token; Building Request";
            progressValue.Value = 10;
            var queryDict = new Dictionary<string, string>{
    {"client_id", clientId},
    {"client_secret", clientSecret},
    {"grant_type", "refresh_token"},
    {"refresh_token", tokenRefresh} };
            progressText.Text = "Refresh Token; Building Request";
            progressValue.Value = 30;
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            progressText.Text = "Refresh Token; Send request";
            progressValue.Value = 60;
            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint) { Content = requestContent };

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
                    //Fix scope
                    authorizationScope.Replace('=', ':');
                    authorizationScope.Replace("+", " ");

                    // Check for validity and parse to variables
                    dictX.TryGetValue("access_token", out tokenCode);
                    dictX.TryGetValue("refresh_token", out tokenRefresh);
                    dictX.TryGetValue("scope", out authorizationScope);
                    dictX.TryGetValue("token_type", out tokenType);

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
