namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefWebUrlRequest
    {
        /// <summary>
        /// Create a new CefWebUrlRequest object.
        /// </summary>
        /* FIXME: CefWebUrlRequest.CreateWebURLRequest public */
        static cef_web_urlrequest_t* CreateWebURLRequest(cef_request_t* request, cef_web_urlrequest_client_t* client)
        {
            // TODO: CefWebUrlRequest.CreateWebURLRequest
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancels the request.
        /// </summary>
        /* FIXME: CefWebUrlRequest.Cancel public */
        void Cancel()
        {
            // TODO: CefWebUrlRequest.Cancel
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the current ready state of the request.
        /// </summary>
        /* FIXME: CefWebUrlRequest.GetState public */
        cef_weburlrequest_state_t GetState()
        {
            // TODO: CefWebUrlRequest.GetState
            throw new NotImplementedException();
        }


    }
}
