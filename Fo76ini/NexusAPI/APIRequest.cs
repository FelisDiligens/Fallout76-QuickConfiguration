using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Fo76ini.NexusAPI
{
    /// <summary>
    /// Wrapper around the classes of System.Net.
    /// Used to make HTTPS requests to the NexusMods' API.
    /// </summary>
    public class APIRequest
    {
        public string URL;

        private HttpWebRequest request;
        private HttpWebResponse response;

        public WebException Exception = null;

        public string PostData = "";

        public APIRequest(string url)
        {
            this.URL = url;
            this.request = (HttpWebRequest)WebRequest.Create(this.URL);

            this.UserAgent = Shared.AppUserAgent;
            this.Headers["Application-Version"] = Shared.VERSION;
            this.Headers["Application-Name"] = NexusMods.ApplicationName;
        }

        /// <summary>
        /// Sends the request and reads the response.
        /// </summary>
        public void Execute()
        {
            this.Success = false;
            try
            {
                // Send POST data, if needed:
                if (Method.ToUpper() == "POST" && PostData.Trim() != "")
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        streamWriter.Write(PostData);

                // Get response:
                this.response = (HttpWebResponse)request.GetResponse();
                this.Success = true;

                // Read the response:
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    ResponseText = reader.ReadToEnd();
                }

                this.Exception = null;
            }
            catch (WebException ex)
            {
                // If the status code isn't 200 (or rather 2xx), it will throw an exception:
                if (ex.Response != null)
                {
                    // Get response:
                    this.response = (HttpWebResponse)ex.Response;
                    this.Success = true;

                    // Read the response:
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        ResponseText = reader.ReadToEnd();
                    }
                }

                this.Exception = ex;
            }
        }

        public JObject GetJObject()
        {
            return JObject.Parse(ResponseText);
        }

        public JArray GetJArray()
        {
            return JArray.Parse(ResponseText);
        }

        public WebHeaderCollection ResponseHeaders
        {
            get => response.Headers;
        }

        public WebHeaderCollection Headers
        {
            get => request.Headers;
        }

        public HttpStatusCode StatusCode
        {
            get => response.StatusCode;
        }

        /// <summary>
        /// Whether the request was successful.
        /// </summary>
        public bool Success { get; private set; }
        public string ResponseText { get; private set; }

        public string UserAgent
        {
            get => this.request.UserAgent;
            set => this.request.UserAgent = value;
        }

        public string Accept
        {
            get => this.request.Accept;
            set => this.request.Accept = value;
        }

        public string Method
        {
            get => this.request.Method;
            set => this.request.Method = value;
        }

        public string RequestContentType
        {
            get => this.request.ContentType;
            set => this.request.ContentType = value;
        }
    }
}
