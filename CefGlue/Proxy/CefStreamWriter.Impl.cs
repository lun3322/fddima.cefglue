namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefStreamWriter
    {
        /// <summary>
        /// Create a new CefStreamWriter object for a file.
        /// </summary>
        /* FIXME: CefStreamWriter.CreateForFile public */
        static cef_stream_writer_t* CreateForFile(/*const*/ cef_string_t* fileName)
        {
            // TODO: CefStreamWriter.CreateForFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefStreamWriter object for a custom handler.
        /// </summary>
        /* FIXME: CefStreamWriter.CreateForHandler public */
        static cef_stream_writer_t* CreateForHandler(cef_write_handler_t* handler)
        {
            // TODO: CefStreamWriter.CreateForHandler
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /* FIXME: CefStreamWriter.Write public */
        int Write(/*const*/ void* ptr, int size, int n)
        {
            // TODO: CefStreamWriter.Write
            throw new NotImplementedException();
        }

        /// <summary>
        /// Seek to the specified offset position. |whence| may be any one of
        /// SEEK_CUR, SEEK_END or SEEK_SET.
        /// </summary>
        /* FIXME: CefStreamWriter.Seek public */
        int Seek(long offset, int whence)
        {
            // TODO: CefStreamWriter.Seek
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /* FIXME: CefStreamWriter.Tell public */
        long Tell()
        {
            // TODO: CefStreamWriter.Tell
            throw new NotImplementedException();
        }

        /// <summary>
        /// Flush the stream.
        /// </summary>
        /* FIXME: CefStreamWriter.Flush public */
        int Flush()
        {
            // TODO: CefStreamWriter.Flush
            throw new NotImplementedException();
        }


    }
}
