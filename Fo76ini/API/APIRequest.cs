using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Fo76ini.API
{
    /// <summary>
    /// Wrapper around the class System.Net.HttpWebResponse with getters for Newtonsoft.Json.JArray and Newtonsoft.Json.JObject.
    /// Returned by APIRequest.GetResponse()
    /// </summary>
    public class APIResponse
    {
        public APIResponse(HttpWebResponse response, WebException ex = null)
        {
            if (response != null)
            {
                // Read the response:
                this.response = response;
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    this.ResponseText = reader.ReadToEnd();
                }

                this.Success = true;
            }
            else
            {
                this.ResponseText = string.Empty;
                this.Success = false;
            }

            this.Exception = ex;
        }

        private HttpWebResponse response;

        public WebHeaderCollection Headers
        {
            get => response.Headers;
        }

        public HttpStatusCode StatusCode
        {
            get => response.StatusCode;
        }

        /// <summary>
        /// Whether the request was successful.
        /// </summary>
        public bool Success { get; private set; }

        public WebException Exception = null;

        public string ResponseText { get; private set; }

        public JObject GetJObject()
        {
            return JObject.Parse(ResponseText);
        }

        public JArray GetJArray()
        {
            return JArray.Parse(ResponseText);
        }
    }

    /// <summary>
    /// Wrapper around the classes System.Net.WebRequest and System.Net.HttpWebRequest.
    /// Used to make HTTP(S) requests to various APIs.
    /// Automatically sets the user agent.
    /// </summary>
    public class APIRequest
    {
        public string URL;

        private HttpWebRequest request;

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
        /// <returns>Returns an instance 'APIResponse', representing the response from the server.</returns>
        public APIResponse GetResponse()
        {
            try
            {
                // Send POST data, if needed:
                if (Method.ToUpper() == "POST" && PostData.Trim() != "")
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        streamWriter.Write(PostData);

                // Get response:
                return new APIResponse((HttpWebResponse)request.GetResponse());
            }
            catch (WebException ex)
            {
                // If the status code isn't 200 (or rather 2xx), it will throw an exception:
                if (ex.Response != null)
                {
                    // Get response:
                    return new APIResponse((HttpWebResponse)ex.Response, ex);
                }

                return new APIResponse(null, ex);
            }
        }

        public WebHeaderCollection Headers
        {
            get => request.Headers;
        }

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
