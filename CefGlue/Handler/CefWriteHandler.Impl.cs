namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefWriteHandler
    {
        /// <summary>
        /// Write raw binary data.
        /// </summary>
        private int write(cef_write_handler_t* self, /*const*/ void* ptr, int size, int n)
        {
            ThrowIfObjectDisposed();
            // TODO: CefWriteHandler.write
            throw new NotImplementedException();
        }

        /// <summary>
        /// Seek to the specified offset position. |whence| may be any one of
        /// SEEK_CUR, SEEK_END or SEEK_SET.
        /// </summary>
        private int seek(cef_write_handler_t* self, long offset, int whence)
        {
            ThrowIfObjectDisposed();
            // TODO: CefWriteHandler.seek
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        private long tell(cef_write_handler_t* self)
        {
            ThrowIfObjectDisposed();
            // TODO: CefWriteHandler.tell
            throw new NotImplementedException();
        }

        /// <summary>
        /// Flush the stream.
        /// </summary>
        private int flush(cef_write_handler_t* self)
        {
            ThrowIfObjectDisposed();
            // TODO: CefWriteHandler.flush
            throw new NotImplementedException();
        }


    }
}
