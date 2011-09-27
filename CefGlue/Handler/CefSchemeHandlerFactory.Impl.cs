namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefSchemeHandlerFactory
    {
        /// <summary>
        /// Return a new scheme handler instance to handle the request.
        /// </summary>
        private cef_scheme_handler_t* create(cef_scheme_handler_factory_t* self, /*const*/ cef_string_t* scheme_name, cef_request_t* request)
        {
            ThrowIfObjectDisposed();

            var m_schemeName = cef_string_t.ToString(scheme_name);
            var m_request = CefRequest.From(request);

            var handler = this.Create(m_schemeName, m_request);

            return handler.GetNativePointerAndAddRef();
        }

        /// <summary>
        /// Return a new scheme handler instance to handle the request.
        /// </summary>
        protected abstract CefSchemeHandler Create(string schemeName, CefRequest request);


    }
}
