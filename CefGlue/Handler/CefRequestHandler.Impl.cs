namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefRequestHandler
    {
        /// <summary>
        /// Called on the UI thread before browser navigation. Return true to
        /// cancel the navigation or false to allow the navigation to proceed.
        /// </summary>
        private int on_before_browse(cef_request_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_request_t* request, cef_handler_navtype_t navType, int isRedirect)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.on_before_browse
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called on the IO thread before a resource is loaded.  To allow the
        /// resource to load normally return false. To redirect the resource to a
        /// new url populate the |redirectUrl| value and return false.  To
        /// specify data for the resource return a CefStream object in
        /// |resourceStream|, use the |response| object to set mime type, HTTP
        /// status code and optional header values, and return false. To cancel
        /// loading of the resource return true. Any modifications to |request|
        /// will be observed.  If the URL in |request| is changed and
        /// |redirectUrl| is also set, the URL in |request| will be used.
        /// </summary>
        private int on_before_resource_load(cef_request_handler_t* self, cef_browser_t* browser, cef_request_t* request, cef_string_t* redirectUrl, cef_stream_reader_t** resourceStream, cef_response_t* response, int loadFlags)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.on_before_resource_load
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called on the UI thread after a response to the resource request is
        /// received. Set |filter| if response content needs to be monitored
        /// and/or modified as it arrives.
        /// </summary>
        private void on_resource_response(cef_request_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* url, cef_response_t* response, cef_content_filter_t** filter)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.on_resource_response
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called on the IO thread to handle requests for URLs with an unknown
        /// protocol component. Return true to indicate that the request should
        /// succeed because it was handled externally. Set |allowOSExecution| to
        /// true and return false to attempt execution via the registered OS
        /// protocol handler, if any. If false is returned and either
        /// |allow_os_execution| is false or OS protocol handler execution fails
        /// then the request will fail with an error condition. SECURITY WARNING:
        /// YOU SHOULD USE THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME,
        /// HOST OR OTHER URL ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        private int on_protocol_execution(cef_request_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* url, int* allowOSExecution)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.on_protocol_execution
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called on the UI thread when a server indicates via the 'Content-
        /// Disposition' header that a response represents a file to download.
        /// |mimeType| is the mime type for the download, |fileName| is the
        /// suggested target file name and |contentLength| is either the value of
        /// the 'Content-Size' header or -1 if no size was provided. Set
        /// |handler| to the CefDownloadHandler instance that will recieve the
        /// file contents. Return true to download the file or false to cancel
        /// the file download.
        /// </summary>
        private int get_download_handler(cef_request_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* mimeType, /*const*/ cef_string_t* fileName, long contentLength, cef_download_handler_t** handler)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.get_download_handler
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the
        /// user. |isProxy| indicates whether the host is a proxy server. |host|
        /// contains the hostname and port number. Set |username| and |password|
        /// and return true to handle the request. Return false to cancel the
        /// request.
        /// </summary>
        private int get_auth_credentials(cef_request_handler_t* self, cef_browser_t* browser, int isProxy, /*const*/ cef_string_t* host, /*const*/ cef_string_t* realm, /*const*/ cef_string_t* scheme, cef_string_t* username, cef_string_t* password)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRequestHandler.get_auth_credentials
            throw new NotImplementedException();
        }


    }
}
