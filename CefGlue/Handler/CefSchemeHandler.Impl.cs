namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefSchemeHandler
    {
        /// <summary>
        /// Process the request. All response generation should take place in
        /// this method. If there is no response set |response_length| to zero or
        /// return false and ReadResponse() will not be called. If the response
        /// length is not known set |response_length| to -1 and ReadResponse()
        /// will be called until it returns false or until the value of
        /// |bytes_read| is set to 0. If the response length is known set
        /// |response_length| to a positive value and ReadResponse() will be
        /// called until it returns false, the value of |bytes_read| is set to 0
        /// or the specified number of bytes have been read. Use the |response|
        /// object to set the mime type, http status code and optional header
        /// values for the response and return true. To redirect the request to a
        /// new URL set |redirectUrl| to the new URL and return true.
        /// </summary>
        private int process_request(cef_scheme_handler_t* self, cef_request_t* request, cef_string_t* redirectUrl, cef_response_t* response, int* response_length)
        {
            ThrowIfObjectDisposed();
            // TODO: CefSchemeHandler.process_request
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel processing of the request.
        /// </summary>
        private void cancel(cef_scheme_handler_t* self)
        {
            ThrowIfObjectDisposed();
            // TODO: CefSchemeHandler.cancel
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copy up to |bytes_to_read| bytes into |data_out|. If the copy
        /// succeeds set |bytes_read| to the number of bytes copied and return
        /// true. If the copy fails return false and ReadResponse() will not be
        /// called again.
        /// </summary>
        private int read_response(cef_scheme_handler_t* self, void* data_out, int bytes_to_read, int* bytes_read)
        {
            ThrowIfObjectDisposed();
            // TODO: CefSchemeHandler.read_response
            throw new NotImplementedException();
        }


    }
}
