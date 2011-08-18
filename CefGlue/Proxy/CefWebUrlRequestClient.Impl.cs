namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefWebUrlRequestClient
    {
        /// <summary>
        /// Notifies the client that the request state has changed. State change
        /// notifications will always be sent before the below notification
        /// methods are called.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnStateChange public */
        void OnStateChange(cef_web_urlrequest_t* requester, cef_weburlrequest_state_t state)
        {
            // TODO: CefWebUrlRequestClient.OnStateChange
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies the client that the request has been redirected and
        /// provides a chance to change the request parameters.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnRedirect public */
        void OnRedirect(cef_web_urlrequest_t* requester, cef_request_t* request, cef_response_t* response)
        {
            // TODO: CefWebUrlRequestClient.OnRedirect
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies the client of the response data.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnHeadersReceived public */
        void OnHeadersReceived(cef_web_urlrequest_t* requester, cef_response_t* response)
        {
            // TODO: CefWebUrlRequestClient.OnHeadersReceived
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies the client of the upload progress.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnProgress public */
        void OnProgress(cef_web_urlrequest_t* requester, ulong bytesSent, ulong totalBytesToBeSent)
        {
            // TODO: CefWebUrlRequestClient.OnProgress
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies the client that content has been received.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnData public */
        void OnData(cef_web_urlrequest_t* requester, /*const*/ void* data, int dataLength)
        {
            // TODO: CefWebUrlRequestClient.OnData
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies the client that the request ended with an error.
        /// </summary>
        /* FIXME: CefWebUrlRequestClient.OnError public */
        void OnError(cef_web_urlrequest_t* requester, cef_handler_errorcode_t errorCode)
        {
            // TODO: CefWebUrlRequestClient.OnError
            throw new NotImplementedException();
        }


    }
}
