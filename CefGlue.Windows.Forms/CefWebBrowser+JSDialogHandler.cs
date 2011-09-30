namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class JSDialogHandler : CefJSDialogHandler
        {
            private CefWebBrowser control;

            public JSDialogHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override bool OnJSAlert(CefBrowser browser, CefFrame frame, string message)
            {
                // TODO: this is invalid, cross-thread problem.
                MessageBox.Show(this.control, message, "CefJSDialogHandler.OnJSAlert");
                return true;
            }

            protected override bool OnJSConfirm(CefBrowser browser, CefFrame frame, string message, out bool retval)
            {
                var result = MessageBox.Show(this.control, message, "CefJSDialogHandler.OnJSConfirm", MessageBoxButtons.YesNo);
                retval = result == DialogResult.Yes;
                return true;
            }

            protected override bool OnJSPrompt(CefBrowser browser, CefFrame frame, string message, string defaultValue, out bool retval, out string result)
            {
                // TODO: CefWebBrowser+JSDialogHandler.OnJSPrompt
                MessageBox.Show(this.control, "NOT IMPLEMENTED\n"+message, "CefJSDialogHandler.OnJSPrompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                retval = false;
                result = null;

                return true;
            }
        }
    }
}
