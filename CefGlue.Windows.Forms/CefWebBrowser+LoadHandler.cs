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
            private CefWebBrowser control;

            private int framesLoading = 0;

            public LoadHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override void OnLoadStart(CefBrowser browser, CefFrame frame)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadStart");
#endif
                framesLoading++;
                this.control.IsLoading = framesLoading > 0; // TODO: do it async
            }

            protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadEnd: HttpStatusCode=[{0}]", httpStatusCode);
#endif
                framesLoading--;
                if (framesLoading < 0)
                {
                    framesLoading = 0;
                }
                this.control.IsLoading = framesLoading > 0; // TODO: do it async
            }

            protected override bool OnLoadError(CefBrowser browser, CefFrame frame, CefHandlerErrorCode errorCode, string failedUrl, ref string errorText)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LoadHandler.OnLoadError: ErrorCode=[{0}] FailedUrl=[{1}] ErrorText=[{2}]", errorCode, failedUrl, errorText);
#endif
                framesLoading--;
                if (framesLoading < 0)
                {
                    framesLoading = 0;
                }
                this.control.IsLoading = framesLoading > 0; // TODO: do it async

                errorText = "OnLoadError: ErrorCode=[" + errorCode.ToString() + "], URL=[" + failedUrl + "].";
                return true;
            }
        }
    }
}
