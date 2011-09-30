namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class JSBindingHandler : CefJSBindingHandler
        {
            private readonly CefWebBrowser control;

            public JSBindingHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override void OnJSBinding(CefBrowser browser, CefFrame frame, CefV8Value obj)
            {
                #if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.CefJSBindingHandler, "OnJSBinding: browser.WindowHandle=[{0}] frame.IsMain=[{1}]", browser.WindowHandle, frame.IsMain);
                #endif

                // TODO: note, that this is executed twice per-page

                if (!browser.IsPopup && frame.IsMain)
                {
                    if (this.control.mainFrameV8Context != null) { this.control.mainFrameV8Context.Dispose(); this.control.mainFrameV8Context = null; }
                    this.control.mainFrameV8Context = CefV8Context.GetEnteredContext();
                }

                Cef.ExportScriptableObjects(obj);
            }
        }
    }
}
