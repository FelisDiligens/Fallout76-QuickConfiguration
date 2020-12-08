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
    // TODO: Possible bug in SingleSignOn
    // There might be a bug where if no message is received from the server within 30 seconds (see TimeSpan ReconnectTimeout),
    // the client will try to reconnect and the login fails.

    public static class SingleSignOn
    {
        public static event SSOEventHandler SSOFinished;

        private static Guid uuidv4;
        private static string connectionToken = null;

        private static readonly TimeSpan ReconnectTimeout = TimeSpan.FromSeconds(60);

        private static WebsocketClient client = null;

        private static bool success = false;

        public static void Connect ()
        {
            if (client != null && client.IsRunning)
                client.Stop(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "");

            success = false;
            client = new WebsocketClient(new Uri(NexusMods.SSODomain));
            client.ReconnectTimeout = ReconnectTimeout;
            client.ReconnectionHappened.Subscribe(OnReconnect);
            client.MessageReceived.Subscribe(OnMessage);
            client.DisconnectionHappened.Subscribe(OnDisconnect);
            client.Start();

            string data = BuildLoginData();

            client.Send(data); // SendInstant
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
                    {
                        connectionToken = data["connection_token"].ToString();

                        Utils.OpenURL("https://www.nexusmods.com/sso?id=" + uuidv4 + "&application=" + NexusMods.ApplicationSlug);
                    }

                    if (data.ContainsKey("api_key"))
                    {
                        success = true;

                        SSOEventArgs e = new SSOEventArgs();
                        e.APIKey = data["api_key"].ToString();
                        e.success = true;

                        if (SSOFinished != null)
                            SSOFinished(null, e);
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

        private static void OnDisconnect(DisconnectionInfo info)
        {
            Console.WriteLine(
                $"---- Disconnection happened. ----\n" +
                $"Reason:      {info.CloseStatus}\n" +
                $"Message:     {info.CloseStatusDescription}\n" +
                $"Subprotocol: {info.SubProtocol}\n" +
                $"Exception:   {info.Exception}\n" +
                $"---------------------------------");

            if (success)
            {
                info.CancelReconnection = true;
            }
            else if (info.Exception != null)
            {
                info.CancelReconnection = true;

                SSOEventArgs e = new SSOEventArgs();
                e.Exception = info.Exception;
                e.success = false;

                if (SSOFinished != null)
                    SSOFinished(null, e);
            }
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
        public string APIKey = "";
        public Exception Exception = null;
    }
}
