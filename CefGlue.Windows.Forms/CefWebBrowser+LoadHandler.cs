namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class LoadHandler : CefLoadHandler
        {
            public LoadHandler(CefWebBrowser control)
            {
            }

            protected override void OnLoadStart(CefBrowser browser, CefFrame frame)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadStart");
#endif
            }

            protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadEnd: HttpStatusCode=[{0}]", httpStatusCode);
#endif
            }

            protected override bool OnLoadError(CefBrowser browser, CefFrame frame, CefHandlerErrorCode errorCode, string failedUrl, ref string errorText)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadError: ErrorCode=[{0}] FailedUrl=[{1}] ErrorText=[{2}]", errorCode, failedUrl, errorText);
#endif
                errorText = "OnLoadError: ErrorCode=[" + errorCode.ToString() + "], URL=[" + failedUrl + "].";
                return true;
            }
        }
    }
}
