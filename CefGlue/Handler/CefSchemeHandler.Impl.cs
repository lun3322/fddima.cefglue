namespace CefGlue
{
    using System;
    using System.IO;
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

            var m_request = CefRequest.From(request);
            string m_redirectUrl;
            var m_response = CefResponse.From(response);
            int m_responseLength;

            var handled = this.ProcessRequest(m_request, out m_redirectUrl, m_response, out m_responseLength);

            *response_length = m_responseLength;

            if (handled)
            {
                cef_string_t.Copy(m_redirectUrl, redirectUrl);
            }

            return handled ? 1 : 0;
        }

        /// <summary>
        /// Process the request.
        /// All response generation should take place in this method.
        /// If there is no response set |response_length| to zero or return false and ReadResponse() will not be called.
        /// If the response length is not known set |response_length| to -1 and ReadResponse() will be called until it returns false or until the value of |bytes_read| is set to 0.
        /// If the response length is known set |response_length| to a positive value and ReadResponse() will be called until it returns false, the value of |bytes_read| is set to 0 or the specified number of bytes have been read.
        /// Use the |response| object to set the mime type, http status code and optional header values for the response and return true.
        /// To redirect the request to a new URL set |redirectUrl| to the new URL and return true.
        /// </summary>
        protected abstract bool ProcessRequest(CefRequest request, out string redirectUrl, CefResponse response, out int responseLength);


        /// <summary>
        /// Cancel processing of the request.
        /// </summary>
        private void cancel(cef_scheme_handler_t* self)
        {
            ThrowIfObjectDisposed();

            this.Cancel();
        }

        /// <summary>
        /// Cancel processing of the request.
        /// </summary>
        protected abstract void Cancel();


        /// <summary>
        /// Copy up to |bytes_to_read| bytes into |data_out|. If the copy
        /// succeeds set |bytes_read| to the number of bytes copied and return
        /// true. If the copy fails return false and ReadResponse() will not be
        /// called again.
        /// </summary>
        private int read_response(cef_scheme_handler_t* self, void* data_out, int bytes_to_read, int* bytes_read)
        {
            ThrowIfObjectDisposed();

            using (var m_stream = new UnmanagedMemoryStream((byte*)data_out, bytes_to_read, bytes_to_read, FileAccess.Write))
            {
                int m_bytesRead;
                var handled = this.ReadResponse(m_stream, bytes_to_read, out m_bytesRead);
                *bytes_read = m_bytesRead;
                return handled ? 1 : 0;
            }
        }

        /// <summary>
        /// Copy up to |bytes_to_read| bytes into |data_out|.
        /// If the copy succeeds set |bytes_read| to the number of bytes copied and return true.
        /// If the copy fails return false and ReadResponse() will not be called again.
        /// </summary>
        protected abstract bool ReadResponse(Stream stream, int bytesToRead, out int bytesRead);


    }
}