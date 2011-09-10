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
            var urlString = request.GetURL();

            string errorMessage = null;
            int errorStatus = 0;
            string errorStatusText = null;

            try
            {
                var uri = new Uri(urlString);
                var path = uri.Host + uri.AbsolutePath;

                var asm = typeof(ClientSchemeHandler).Assembly;
                var resPrefix = "CefGlue.Client.ClientScheme.";

                // convert path to resource name
                var parts = path.Split('/');
                for (var i = 0; i < parts.Length-1; i++)
                {
                    var filename = Path.GetFileNameWithoutExtension(parts[i]);
                    var extension = Path.GetExtension(parts[i]);

                    parts[i] = filename.Replace(".", "._").Replace('-', '_') + extension;
                }

                var resName = resPrefix + string.Join(".", parts);
                this.stream = asm.GetManifestResourceStream(resName);

                if (this.stream != null)
                {
                    // found
                    redirectUrl = null;
                    responseLength = -1; // (int)stream.Length;
                    response.SetStatus(200);
                    response.SetMimeType(GetMimeTypeFromUriSuffix(path));
                    response.SetStatusText("OK");
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorStatus = 500;
                errorStatusText = "Internal Error";
                errorMessage = "<!doctype html><html><body><h1>Internal Error!</h1><pre>" + ex.ToString() + "</pre></body></html>";
            }

            // not found or error while processing request
            errorMessage = errorMessage ?? "<!doctype html><html><body><h1>Not Found!</h1><p>The requested url [" + urlString + "] not found!</p></body></html>";
            var bytes = Encoding.UTF8.GetBytes(errorMessage);
            this.stream = new MemoryStream(bytes, false);

            redirectUrl = null;
            responseLength = -1;
            response.SetStatus(errorStatus != 0 ? errorStatus : 404);
            response.SetStatusText(errorStatusText ?? "Not Found");
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
