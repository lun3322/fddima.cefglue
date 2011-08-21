namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefContentFilter
    {
        /// <summary>
        /// Set |substitute_data| to the replacement for the data in |data| if
        /// data should be modified.
        /// </summary>
        private void process_data(cef_content_filter_t* self, /*const*/ void* data, int data_size, cef_stream_reader_t** substitute_data)
        {
            ThrowIfObjectDisposed();
            // TODO: CefContentFilter.process_data
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when there is no more data to be processed. It is expected
        /// that whatever data was retained in the last ProcessData() call, it
        /// should be returned now by setting |remainder| if appropriate.
        /// </summary>
        private void drain(cef_content_filter_t* self, cef_stream_reader_t** remainder)
        {
            ThrowIfObjectDisposed();
            // TODO: CefContentFilter.drain
            throw new NotImplementedException();
        }


    }
}
