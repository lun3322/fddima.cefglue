namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefReadHandler
    {
        /// <summary>
        /// Read raw binary data.
        /// </summary>
        private int read(cef_read_handler_t* self, void* ptr, int size, int n)
        {
            ThrowIfObjectDisposed();
            // TODO: CefReadHandler.read
            throw new NotImplementedException();
        }

        /// <summary>
        /// Seek to the specified offset position. |whence| may be any one of
        /// SEEK_CUR, SEEK_END or SEEK_SET.
        /// </summary>
        private int seek(cef_read_handler_t* self, long offset, int whence)
        {
            ThrowIfObjectDisposed();
            // TODO: CefReadHandler.seek
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        private long tell(cef_read_handler_t* self)
        {
            ThrowIfObjectDisposed();
            // TODO: CefReadHandler.tell
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        private int eof(cef_read_handler_t* self)
        {
            ThrowIfObjectDisposed();
            // TODO: CefReadHandler.eof
            throw new NotImplementedException();
        }


    }
}
