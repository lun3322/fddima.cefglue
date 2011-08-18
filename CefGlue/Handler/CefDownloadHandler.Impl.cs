namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDownloadHandler
    {
        /// <summary>
        /// A portion of the file contents have been received. This method will
        /// be called multiple times until the download is complete. Return
        /// |true| to continue receiving data and |false| to cancel.
        /// </summary>
        private int received_data(cef_download_handler_t* self, void* data, int data_size)
        {
            // TODO: CefDownloadHandler.received_data
            throw new NotImplementedException();
        }

        /// <summary>
        /// The download is complete.
        /// </summary>
        private void complete(cef_download_handler_t* self)
        {
            // TODO: CefDownloadHandler.complete
            throw new NotImplementedException();
        }


    }
}
