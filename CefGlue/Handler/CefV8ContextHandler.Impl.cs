namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    unsafe partial class CefV8ContextHandler
    {
        private void on_context_created(cef_v8context_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_v8context_t* context)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.From(browser);
            var m_frame = CefFrame.From(frame);
            var m_context = CefV8Context.From(context);
            
            this.OnContextCreated(m_browser, m_frame, m_context);
        }

        private void on_context_released(cef_v8context_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_v8context_t* context)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.From(browser);
            var m_frame = CefFrame.From(frame);
            var m_context = CefV8Context.From(context);

            this.OnContextReleased(m_browser, m_frame, m_context);
        }

        protected abstract void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context);

        protected abstract void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context);
    }
}