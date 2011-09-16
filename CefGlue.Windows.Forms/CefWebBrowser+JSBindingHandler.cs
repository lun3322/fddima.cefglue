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
            protected override void OnJSBinding(CefBrowser browser, CefFrame frame, CefV8Value obj)
            {
                Cef.ExportScriptableObjects(obj);
            }
        }
    }
}
