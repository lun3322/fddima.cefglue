namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefWebUrlRequest
    {
        /// <summary>
        /// Create a new CefWebUrlRequest object.
        /// </summary>
        public static CefWebUrlRequest Create(CefRequest request, CefWebUrlRequestClient client)
        {
            return CefWebUrlRequest.From(
                libcef.web_urlrequest_create(
                    request.GetNativePointerAndAddRef(),
                    client.GetNativePointerAndAddRef()
                    )
                );
        }

        /// <summary>
        /// Cancels the request.
        /// </summary>
        public void Cancel()
        {
            this.cancel(this.ptr);
        }

        /// <summary>
        /// Returns the current ready state of the request.
        /// </summary>
        public CefWebUrlRequestState GetState()
        {
            return (CefWebUrlRequestState)this.get_state(this.ptr);
        }

    }
}
