namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefJSBindingHandler
    {
        /// <summary>
        /// Called for adding values to a frame's JavaScript 'window' object.
        /// </summary>
        private void on_jsbinding(cef_jsbinding_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_v8value_t* @object)
        {
            ThrowIfObjectDisposed();
            // TODO: CefJSBindingHandler.on_jsbinding
            throw new NotImplementedException();
        }


    }
}
