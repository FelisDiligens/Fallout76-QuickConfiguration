using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;

namespace Fo76ini.Utilities.Browser
{
    public static class BrowserIPC
    {
        public class JSMessage
        {
            public string message { get; set; }

            public object data { get; set; }

            public IJavascriptCallback callback { get; set; }
        }

        public static void SendMessage(IFrame browserFrame, string message, object data)
        {
            String script =
                $"let cefSharpMessageEvent = new CustomEvent('cefsharpmessagerecv', {{ detail: {{ message: {JsonConvert.SerializeObject(message)}, data: {JsonConvert.SerializeObject(data)} }} }});\n" +
                $"document.dispatchEvent(cefSharpMessageEvent);";
            Console.WriteLine($"[BrowserIPC] SendMessage ({message}):\n{script}");
            browserFrame.ExecuteJavaScriptAsync(script);
        }

        public static void RecvMessage(ChromiumWebBrowser browser, Func<object, string, object, object> callback)
        {
            browser.JavascriptMessageReceived += (sender, e) =>
            {
                var msg = e.ConvertMessageTo<JSMessage>();
                Console.WriteLine($"[BrowserIPC] JavascriptMessageReceived ({msg.message}):\n{JsonConvert.SerializeObject(msg.data)}");
                object callbackData = callback?.Invoke(sender, msg.message, msg.data);
                if (callbackData != null && msg.callback != null && msg.callback.CanExecute)
                    msg.callback.ExecuteAsync(callbackData);
            };
        }
    }
}
