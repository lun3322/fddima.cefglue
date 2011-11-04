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

            var m_browser = CefBrowser.From(browser);
            var m_frame = CefFrame.From(frame);
            var m_object = CefV8Value.From(@object);

            this.OnJSBinding(m_browser, m_frame, m_object);
        }

        /// <summary>
        /// Called for adding values to a frame's JavaScript 'window' object.
        /// </summary>
        protected abstract void OnJSBinding(CefBrowser browser, CefFrame frame, CefV8Value obj);

    }
}
