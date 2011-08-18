namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefJSDialogHandler
    {
        /// <summary>
        /// Called  to run a JavaScript alert message. Return false to display
        /// the default alert or true if you displayed a custom alert.
        /// </summary>
        private int on_jsalert(cef_jsdialog_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, /*const*/ cef_string_t* message)
        {
            // TODO: CefJSDialogHandler.on_jsalert
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to run a JavaScript confirm request. Return false to display
        /// the default alert or true if you displayed a custom alert. If you
        /// handled the alert set |retval| to true if the user accepted the
        /// confirmation.
        /// </summary>
        private int on_jsconfirm(cef_jsdialog_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, /*const*/ cef_string_t* message, int* retval)
        {
            // TODO: CefJSDialogHandler.on_jsconfirm
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to run a JavaScript prompt request. Return false to display
        /// the default prompt or true if you displayed a custom prompt. If you
        /// handled the prompt set |retval| to true if the user accepted the
        /// prompt and request and |result| to the resulting value.
        /// </summary>
        private int on_jsprompt(cef_jsdialog_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, /*const*/ cef_string_t* message, /*const*/ cef_string_t* defaultValue, int* retval, cef_string_t* result)
        {
            // TODO: CefJSDialogHandler.on_jsprompt
            throw new NotImplementedException();
        }


    }
}
