using Fo76ini.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;
using Websocket.Client.Models;

namespace Fo76ini.NexusAPI
{
    public static class SingleSignOn
    {
        public static event SSOEventHandler APIKeyReceived;

        private static Guid uuidv4;
        private static string connectionToken = null;

        private static readonly TimeSpan ReconnectTimeout = TimeSpan.FromSeconds(30); // TODO 5 sec?

        public static void Connect ()
        {
            var client = new WebsocketClient(new Uri(NexusMods.SSODomain))
            {
                IsReconnectionEnabled = false
            };
            //client.ReconnectTimeout = ReconnectTimeout;
            //client.ReconnectionHappened.Subscribe(OnReconnect);
            client.MessageReceived.Subscribe(OnMessage);
            client.DisconnectionHappened.Subscribe((info) => { Console.WriteLine($"DisconnectionHappened: {info.CloseStatusDescription}"); });
            client.Start();

            string data = BuildLoginData();

            client.Send(data); // SendInstant

            Utils.OpenURL("https://www.nexusmods.com/sso?id=" + uuidv4 + "&application=" + NexusMods.ApplicationSlug);
        }

        private static void OnMessage(ResponseMessage msg)
        {
            if (msg.MessageType == System.Net.WebSockets.WebSocketMessageType.Text)
            {
                JObject response = JObject.Parse(msg.Text);

                if (response["success"].Value<bool>())
                {
                    JObject data = (JObject)response["data"];

                    if (data.ContainsKey("connection_token"))
                        connectionToken = data["connection_token"].ToString();

                    if (data.ContainsKey("api_key"))
                    {
                        SSOEventArgs e = new SSOEventArgs();
                        e.APIKey = data["api_key"].ToString();
                        e.success = true;

                        if (APIKeyReceived != null)
                            APIKeyReceived(null, e);
                    }
                }
                else
                {
                    Console.WriteLine($"Something went wrong: {response["error"]}");
                }
            }
            else
            {
                Console.WriteLine($"Received message was not of type 'Text': {msg}");
                return;
            }
        }

        private static void OnReconnect(ReconnectionInfo info)
        {
            Console.WriteLine($"Reconnection happened, type: {info.Type}");
        }


        private class LoginData
        {
            public string id;
            public string token;
            public int protocol;
        }

        private static string BuildLoginData()
        {
            if (uuidv4 == Guid.Empty)
                uuidv4 = Guid.NewGuid();

            LoginData loginData = new LoginData();
            loginData.id = uuidv4.ToString();
            loginData.token = connectionToken;
            loginData.protocol = 2;

            return JsonConvert.SerializeObject(loginData);
        }
    }

    public delegate void SSOEventHandler(object sender, SSOEventArgs e);

    public class SSOEventArgs : EventArgs
    {
        public bool success;
        public string APIKey;
    }
}
