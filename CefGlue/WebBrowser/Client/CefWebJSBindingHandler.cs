namespace CefGlue.WebBrowser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CefGlue.Diagnostics;
    using CefGlue.JSBinding;

    public class CefWebJSBindingHandler : CefJSBindingHandler
    {
        private readonly CefWebBrowserCore context;

        public CefWebJSBindingHandler(CefWebBrowserCore context)
        {
            this.context = context;
        }

        protected override void OnJSBinding(CefBrowser browser, CefFrame frame, CefV8Value obj)
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefJSBindingHandler, "OnJSBinding: Frame: IsMain=[{0}] Name=[{1}]", frame.IsMain, frame.GetName());
#endif

            if (frame.IsMain)
            {
                var mainFrameCtx = this.context.MainFrame;

                // Bind V8Context to frame here due to CEF Issue#344: http://code.google.com/p/chromiumembedded/issues/detail?id=344.

                // Because OnJSBinding handler executed twice per page (http://code.google.com/p/chromiumembedded/issues/detail?id=359)
                // we will unbind v8 context first.
                mainFrameCtx.UnbindV8Context();

                mainFrameCtx.BindCurrentV8Context();
            }

            {
                CefV8Value retVal;
                string exception;

                var eval = obj.GetValue("eval");

                {
                    var script = CefV8Value.CreateString(ResourceHelper.Core);
                    eval.ExecuteFunction(obj, new CefV8Value[] { script }, out retVal, out exception);
                    script.Dispose();
                    if (retVal != null) retVal.Dispose();
                    if (!string.IsNullOrEmpty(exception)) throw new JavaScriptException(exception);
                }

                if ((this.context.ReadyOptions & CefReadyOptions.XmlHttpRequest) != 0)
                {
                    var script = CefV8Value.CreateString(ResourceHelper.XmlHttpRequest);
                    eval.ExecuteFunction(obj, new CefV8Value[] { script }, out retVal, out exception);
                    script.Dispose();
                    if (retVal != null) retVal.Dispose();
                    if (!string.IsNullOrEmpty(exception)) throw new JavaScriptException(exception);
                }

                eval.Dispose();
            }

            Cef.JSBindingContext.BindObjects(obj);
            this.context.JSBindingContext.BindObjects(obj);
        }
    }
}
