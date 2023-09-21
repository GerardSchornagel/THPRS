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
        static string oauthState;

        static string GenerateRandomHexCode()
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

        public static void OauthAuthorizationRequest(Configuration config)
        {
            string scope = "";
            if (config.OAuthScopeChannelModerator == true) { scope += "channel:moderator "; }
            if (config.OAuthScopeChatEdit == true) { scope += "chat:edit "; }
            if (config.OAuthScopeChatRead == true) { scope += "chat:read "; }
            if (config.OAuthScopeModeratorReadChatters == true) { scope += "moderator:read:chatters "; }
            scope = scope.TrimEnd();

            oauthState = GenerateRandomHexCode();

            // Build the URL for an OAuth AUTHorization Token
            var dictAuthorization = new Dictionary<string, string> {
    {"client_id", config.OAuthClientID},
    {"redirect_uri", config.OAuthRedirectUri},
    {"response_type", "code"},
    {"scope", scope},
    {"state", oauthState } };
            var requestQuery = new FormUrlEncodedContent(dictAuthorization);
            var uriBuilder = new UriBuilder(config.OAuthAuthorizationEndpoint);
            uriBuilder.Query = requestQuery.ReadAsStringAsync().Result.ToString();
            string stringAuthorizationURL = uriBuilder.Uri.AbsoluteUri;

            // Opens Listener for localhost for redirects
            var listener = new HttpListener();
            listener.Prefixes.Add(config.OAuthRedirectUri + "/");
            listener.Start();

            // Opens URL in standard browser
            Process.Start(new ProcessStartInfo(stringAuthorizationURL) { UseShellExecute = true });

            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                // Check for redirection to localhost
                if (ctx.Request.Url.ToString().StartsWith(config.OAuthRedirectUri))
                {
                    listener.Close();

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

                    // Check for validity and parse to variables
                    string valueState = "";
                    if (dictX.TryGetValue("state", out valueState))
                    {
                        if (valueState == oauthState)
                        {
                            //Valid response > process
                            //code scope state
                            dictX.TryGetValue("code", out string authorizationCode);

                            config.AuthorizationCode = authorizationCode;
                            ConfigurationManager.WriteConfiguration(config);
                        }
                        else
                        {
                            //Mismatched or missing oauthState > Try Again
                            MessageBox.Show("oauth respnose is not valid, wrong or missing State.");
                            MessageBox.Show($"{valueState} != {oauthState}");
                        }
                    }
                    break;
                }
            }
        }

        public static void OauthTokenRequest(Configuration config)
        {
            // Build the URL for an OAuth ACCESS Token and send
            var queryDict = new Dictionary<string, string>{
    {"client_id", config.OAuthClientID},
    {"client_secret", config.OAuthClientSecret},
    {"redirect_uri", config.OAuthRedirectUri},
    {"code", config.AuthorizationCode},
    {"grant_type", "authorization_code"} };
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, config.OAuthTokenEndpoint) { Content = requestContent };

            // Awaiting response
            var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            while (true)
            {
                if (response.Result.Content.Headers.ContentLength != null)
                {
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
                    dictX.TryGetValue("access_token", out string tokenCode);
                    dictX.TryGetValue("expires_in", out string tokenExpiresIn);
                    dictX.TryGetValue("refresh_token", out string tokenRefresh);

                    config.TokenCode = tokenCode;
                    config.TokenExpiresAt = DateTime.Now.AddSeconds(Convert.ToDouble(tokenExpiresIn) - 1000);
                    config.TokenRefresh = tokenRefresh;
                    ConfigurationManager.WriteConfiguration(config);

                    break;
                }
            }
        }

        public static void OauthRefreshRequest(Configuration config)
        {
            var queryDict = new Dictionary<string, string>{
    {"client_id", config.OAuthClientID},
    {"client_secret", config.OAuthClientSecret},
    {"grant_type", "refresh_token"},
    {"refresh_token", config.TokenRefresh} };
            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(queryDict);

            // Sending request
            var request = new HttpRequestMessage(HttpMethod.Post, config.OAuthTokenEndpoint) { Content = requestContent };

            // Awaiting response
            var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            while (true)
            {
                if (response.Result.Content.Headers.ContentLength != null)
                {
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
                    dictX.TryGetValue("access_token", out string tokenCode);
                    dictX.TryGetValue("refresh_token", out string tokenRefresh);

                    config.TokenCode = tokenCode;
                    config.TokenRefresh = tokenRefresh;
                    ConfigurationManager.WriteConfiguration(config);
                    break;
                }
            }
        }
    }
}