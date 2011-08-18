namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefStreamReader
    {
        /// <summary>
        /// Create a new CefStreamReader object from a file.
        /// </summary>
        /* FIXME: CefStreamReader.CreateForFile public */
        static cef_stream_reader_t* CreateForFile(/*const*/ cef_string_t* fileName)
        {
            // TODO: CefStreamReader.CreateForFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefStreamReader object from data.
        /// </summary>
        /* FIXME: CefStreamReader.CreateForData public */
        static cef_stream_reader_t* CreateForData(void* data, int size)
        {
            // TODO: CefStreamReader.CreateForData
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefStreamReader object from a custom handler.
        /// </summary>
        /* FIXME: CefStreamReader.CreateForHandler public */
        static cef_stream_reader_t* CreateForHandler(cef_read_handler_t* handler)
        {
            // TODO: CefStreamReader.CreateForHandler
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /* FIXME: CefStreamReader.Read public */
        int Read(void* ptr, int size, int n)
        {
            // TODO: CefStreamReader.Read
            throw new NotImplementedException();
        }

        /// <summary>
        /// Seek to the specified offset position. |whence| may be any one of
        /// SEEK_CUR, SEEK_END or SEEK_SET. Returns zero on success and non-zero
        /// on failure.
        /// </summary>
        /* FIXME: CefStreamReader.Seek public */
        int Seek(long offset, int whence)
        {
            // TODO: CefStreamReader.Seek
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /* FIXME: CefStreamReader.Tell public */
        long Tell()
        {
            // TODO: CefStreamReader.Tell
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /* FIXME: CefStreamReader.Eof public */
        int Eof()
        {
            // TODO: CefStreamReader.Eof
            throw new NotImplementedException();
        }


    }
}
