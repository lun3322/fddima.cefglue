namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using CefGlue;

    internal sealed class ClientSchemeHandler : CefSchemeHandler
    {
        private Stream stream;

        private void Close()
        {
            if (this.stream != null)
            {
                this.stream.Dispose();
                this.stream = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) Close();
            base.Dispose(disposing);
        }

        protected override bool ProcessRequest(CefRequest request, out string redirectUrl, CefResponse response, out int responseLength)
        {
            var url = request.GetURL();

            var asm = typeof(ClientSchemeHandler).Assembly;
            var resPrefix = "CefGlue.Client.ClientScheme.";
            var urlPrefix = "client://";
            if (url.StartsWith(urlPrefix))
            {
                var resName = resPrefix + url.Substring(urlPrefix.Length).Replace('/', '.');
                this.stream = asm.GetManifestResourceStream(resName);

                if (this.stream != null)
                {
                    // found
                    redirectUrl = null;
                    responseLength = -1; // (int)stream.Length;
                    response.SetStatus(200);
                    response.SetMimeType(GetMimeTypeFromUriSuffix(url));
                    response.SetStatusText("OK");
                    return true;
                }
            }

            // not found - no response
            var message = "<!doctype html><html><body><h1>Not Found!</h1><p>The requested url [" + url + "] not found!</p></body></html>";
            var bytes = Encoding.UTF8.GetBytes(message);
            this.stream = new MemoryStream(bytes, false);

            redirectUrl = null;
            responseLength = -1;
            response.SetStatus(404);
            response.SetStatusText("Not Found");
            response.SetMimeType("text/html");
            return true;
        }

        protected override void Cancel()
        {
            this.Close();
        }

        protected override bool ReadResponse(Stream stream, int bytesToRead, out int bytesRead)
        {
            byte[] buffer = new byte[bytesToRead];
            var readed = this.stream.Read(buffer, 0, buffer.Length);
            if (readed > 0)
            {
                stream.Write(buffer, 0, readed);
                bytesRead = readed;
                return true;
            }
            else
            {
                this.Close();
                bytesRead = 0;
                return true;
            }
        }


        private static string GetMimeTypeFromUriSuffix(string value)
        {
            if (value.EndsWith(".html")) return "text/html";
            else if (value.EndsWith(".js")) return "application/javascript";
            else if (value.EndsWith(".png")) return "image/png";
            else if (value.EndsWith(".jpg") || value.EndsWith(".jpeg")) return "image/jpeg";
            else if (value.EndsWith(".gif")) return "image/gif";
            else if (value.EndsWith(".json")) return "application/json";
            else if (value.EndsWith(".css")) return "text/css";
            else if (value.EndsWith(".txt")) return "text/plain";
            else return "binary/octet-stream";
        }
    }
}
