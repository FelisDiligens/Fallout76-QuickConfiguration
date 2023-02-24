using CefSharp;
using CefSharp.DevTools.Network;
using Fo76ini.Properties;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Fo76ini.Utilities.Browser
{
    // https://thechriskent.com/2014/05/12/use-embedded-resources-in-cefsharp/
    // https://stackoverflow.com/questions/35965912/cefsharp-custom-schemehandler

    public class ResourceSchemeHandler : ResourceHandler
    {
        public const String ResourcesFolder = "Resources";

        // Process request and craft response.
        public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
        {
            Uri uri = new Uri(request.Url);
            String file = uri.Authority + uri.AbsolutePath;
            String fileName = uri.AbsolutePath;
            String fileExtension = Path.GetExtension(fileName);

            Assembly assembly = Assembly.GetExecutingAssembly();
            String resourcePath = assembly.GetName().Name + "." + ResourcesFolder + "." + Regex.Replace(file, @"[/\\]{1}", ".");

            if (assembly.GetManifestResourceInfo(resourcePath) != null)
            {
                Stream = assembly.GetManifestResourceStream(resourcePath);
                switch (Path.GetExtension(file))
                {
                    case ".html":
                        MimeType = "text/html";
                        break;
                    case ".js":
                        MimeType = "text/javascript";
                        break;
                    case ".png":
                        MimeType = "image/png";
                        break;
                    case ".appcache":
                    case ".manifest":
                        MimeType = "text/cache-manifest";
                        break;
                    default:
                        // response.MimeType = "application/octet-stream";
                        MimeType = GetMimeType(fileExtension);
                        break;
                }
                callback.Continue();
                return CefReturnValue.Continue; // CefReturnValue.ContinueAsync
            }
            callback.Dispose();
            return CefReturnValue.Cancel;
        }
    }

    public class ResourceSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "resource";

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new ResourceSchemeHandler();
        }
    }
}
