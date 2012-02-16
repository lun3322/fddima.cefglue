namespace CefGlue.WebBrowser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CefGlue.Diagnostics;
    using CefGlue.JSBinding;

    public class CefWebV8ContextHandler : CefV8ContextHandler
    {
        private readonly CefWebBrowserCore context;

        public CefWebV8ContextHandler(CefWebBrowserCore context)
        {
            this.context = context;
        }

        protected override unsafe void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            throw new NotImplementedException();
        }

        protected override unsafe void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            throw new NotImplementedException();
        }
    }
}
