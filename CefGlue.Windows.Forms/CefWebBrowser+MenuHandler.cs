namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class MenuHandler : CefMenuHandler
        {
            private CefWebBrowser control;

            public MenuHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override bool OnBeforeMenu(CefBrowser browser, CefHandlerMenuInfo menuInfo)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "RequestHandler.OnBeforeMenu");
#endif
                return this.control.PostBeforeMenu(menuInfo);
            }

            protected override bool OnMenuAction(CefBrowser browser, CefHandlerMenuId menuId)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "RequestHandler.OnMenuAction");
#endif
                return this.control.PostMenuAction(menuId);
            }
        }
    }
}
