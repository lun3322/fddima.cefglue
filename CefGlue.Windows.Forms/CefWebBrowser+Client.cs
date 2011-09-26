namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class Client : CefClient
        {
            private CefLifeSpanHandler lifeSpanHandler;
            private CefLoadHandler loadHandler;
            private CefDisplayHandler displayHandler;
            private CefKeyboardHandler keyboardHandler;

            private CefJSDialogHandler jsDialogHandler;
            private CefJSBindingHandler jsBindingHandler;

            public Client(CefWebBrowser control)
            {
                this.lifeSpanHandler = new LifeSpanHandler(control);
                this.loadHandler = new LoadHandler(control);
                //var requestHandler = new CefRequestHandler();
                this.displayHandler = new DisplayHandler(control);
                //var focusHandler = new CefFocusHandler();
                this.keyboardHandler = new KeyboardHandler(control);
                //var menuHandler = new CefMenuHandler();
                //var printHandler = new CefPrintHandler();
                //var findHandler = new CefFindHandler();
                this.jsDialogHandler = new JSDialogHandler(control);
                this.jsBindingHandler = new JSBindingHandler();
                //var renderHandler = new CefRenderHandler();
            }

            protected override void Dispose(bool disposing)
            {
                // FIXME: Dispose in Client
                if (this.lifeSpanHandler != null) { this.lifeSpanHandler = null; }
                if (this.loadHandler != null) { this.loadHandler = null; }
                if (this.displayHandler != null) { this.displayHandler = null; }
                if (this.keyboardHandler != null) { this.keyboardHandler = null; }

                base.Dispose(disposing);
            }

            protected override CefLifeSpanHandler GetLifeSpanHandler()
            {
                return this.lifeSpanHandler;
            }

            protected override CefLoadHandler GetLoadHandler()
            {
                return this.loadHandler;
            }

            protected override CefDisplayHandler GetDisplayHandler()
            {
                return this.displayHandler;
            }
            
            protected override CefKeyboardHandler GetKeyboardHandler()
            {
                return this.keyboardHandler;
            }

            protected override CefJSDialogHandler GetJSDialogHandler()
            {
                return this.jsDialogHandler;
            }


            protected override CefJSBindingHandler GetJSBindingHandler()
            {
                return this.jsBindingHandler;
            }
        }
    }
}
