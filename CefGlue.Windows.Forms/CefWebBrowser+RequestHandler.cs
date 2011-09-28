namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class RequestHandler : CefRequestHandler
        {
            private CefWebBrowser control;

            public RequestHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, CefHandlerNavType navType, bool isRedirect)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "RequestHandler.OnBeforeBrowse: Method=[{0}] Url=[{1}] NavType=[{2}] IsRedirect=[{3}]", request.GetMethod(), request.GetURL(), navType, isRedirect);
#endif
                return this.control.PostBeforeBrowse(frame, request, navType, isRedirect);
            }

        }
    }
}
