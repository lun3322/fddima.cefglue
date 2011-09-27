namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class KeyboardHandler : CefKeyboardHandler
        {
            private CefWebBrowser control;

            public KeyboardHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override bool OnKeyEvent(CefBrowser browser, CefHandlerKeyEventType type, int code, CefHandlerKeyEventModifiers modifiers, bool isSystemKey)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "KeyboardHandler.OnKeyEvent: type=[{0}] code=[{1}] modifiers=[{2}] isSystemKey=[{3}]", type, code, modifiers, isSystemKey);
#endif
                return this.control.PostKeyEvent(type, code, modifiers, isSystemKey);
            }

        }
    }
}
