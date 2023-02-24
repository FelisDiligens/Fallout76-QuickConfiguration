using CefSharp;
using System;
using System.IO;

namespace Fo76ini.Utilities.Browser
{
    // https://thechriskent.com/2014/04/21/use-local-files-in-cefsharp/
    // https://stackoverflow.com/questions/35965912/cefsharp-custom-schemehandler

    public class LocalSchemeHandler : ResourceHandler
    {
        // Specifies where you bundled app resides.
        // Basically path to your index.html
        private string frontendFolderPath;

        public LocalSchemeHandler()
        {
            frontendFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        // Process request and craft response.
        public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
        {
            Uri uri = new Uri(request.Url);
            String file = uri.Authority + uri.AbsolutePath;

            String requestedFilePath = Path.Combine(frontendFolderPath, file);

            if (File.Exists(requestedFilePath))
            {
                byte[] bytes = File.ReadAllBytes(requestedFilePath);
                Stream = new MemoryStream(bytes);

                String fileExtension = Path.GetExtension(file);
                MimeType = GetMimeType(fileExtension);

                callback.Continue();
                return CefReturnValue.Continue;
            }

            callback.Dispose();
            return CefReturnValue.Cancel;
        }
    }

    public class LocalSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "local";

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new LocalSchemeHandler();
        }
    }
}
