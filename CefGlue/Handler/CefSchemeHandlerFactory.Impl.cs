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
            // TODO: CefSchemeHandlerFactory.create
            throw new NotImplementedException();
        }


    }
}
