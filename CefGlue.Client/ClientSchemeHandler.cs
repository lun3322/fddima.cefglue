namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using CefGlue;

    internal sealed class ClientSchemeHandler : CefSchemeHandler
    {
        private string requestedUrl;

        protected override bool ProcessRequest(CefRequest request, out string redirectUrl, CefResponse response, out int responseLength)
        {
            requestedUrl = request.GetURL();

            redirectUrl = null;
            response.SetStatus(200);
            response.SetMimeType("text/plain");
            response.SetStatusText("OK");
            responseLength = requestedUrl.Length;
            return true;
        }

        protected override void Cancel()
        {
        }

        protected override bool ReadResponse(Stream stream, int bytesToRead, out int bytesRead)
        {
            var bytes = Encoding.UTF8.GetBytes(requestedUrl);
            stream.Write(bytes, 0, bytes.Length);
            bytesRead = bytes.Length;
            return true;
        }
    }
}
