using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Fo76ini.Utilities
{
    public class APIRequest
    {
        public string url;

        private HttpWebRequest request;
        private HttpWebResponse response;

        public WebException Exception;

        public string PostData = "";

        public APIRequest(string url)
        {
            this.url = url;
            this.request = (HttpWebRequest)WebRequest.Create(this.url);
            this.UserAgent = Shared.AppUserAgent;
        }

        public void Execute()
        {
            this.Success = false;
            try
            {
                if (Method.ToUpper() == "POST")
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        streamWriter.Write(PostData);
                this.response = (HttpWebResponse)request.GetResponse();
                this.Success = true;

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    ResponseText = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    this.response = (HttpWebResponse)ex.Response;
                    this.Success = true;

                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        ResponseText = reader.ReadToEnd();
                    }
                }
                this.Exception = ex;
            }
        }

        public JObject GetJSON()
        {
            // TODO: throw new Newtonsoft.Json.JsonReaderException("Test");
            return JObject.Parse(ResponseText);
        }

        public WebHeaderCollection ResponseHeaders
        {
            get => response.Headers;
        }

        public WebHeaderCollection Headers
        {
            get => request.Headers;
        }

        public int StatusCode
        {
            get => (int)response.StatusCode;
        }

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
