namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefZipReader
    {
        /// <summary>
        /// Create a new CefZipReader object. The returned object's methods can
        /// only be called from the thread that created the object.
        /// </summary>
        /* FIXME: CefZipReader.Create public */
        static cef_zip_reader_t* Create(cef_stream_reader_t* stream)
        {
            // TODO: CefZipReader.Create
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the first file in the archive. Returns true if
        /// the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefZipReader.MoveToFirstFile public */
        int MoveToFirstFile()
        {
            // TODO: CefZipReader.MoveToFirstFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the next file in the archive. Returns true if the
        /// cursor position was set successfully.
        /// </summary>
        /* FIXME: CefZipReader.MoveToNextFile public */
        int MoveToNextFile()
        {
            // TODO: CefZipReader.MoveToNextFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the specified file in the archive. If
        /// |caseSensitive| is true then the search will be case sensitive.
        /// Returns true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefZipReader.MoveToFile public */
        int MoveToFile(/*const*/ cef_string_t* fileName, int caseSensitive)
        {
            // TODO: CefZipReader.MoveToFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the archive. This should be called directly to ensure that
        /// cleanup occurs on the correct thread.
        /// </summary>
        /* FIXME: CefZipReader.Close public */
        int Close()
        {
            // TODO: CefZipReader.Close
            throw new NotImplementedException();
        }


        // The below methods act on the file at the current cursor position.

        /// <summary>
        /// Returns the name of the file.
        /// </summary>
        /* FIXME: CefZipReader.GetFileName public */
        cef_string_userfree_t GetFileName()
        {
            // TODO: CefZipReader.GetFileName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the uncompressed size of the file.
        /// </summary>
        /* FIXME: CefZipReader.GetFileSize public */
        long GetFileSize()
        {
            // TODO: CefZipReader.GetFileSize
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the last modified timestamp for the file.
        /// </summary>
        /* FIXME: CefZipReader.GetFileLastModified public */
        time_t GetFileLastModified()
        {
            // TODO: CefZipReader.GetFileLastModified
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens the file for reading of uncompressed data. A read password may
        /// optionally be specified.
        /// </summary>
        /* FIXME: CefZipReader.OpenFile public */
        int OpenFile(/*const*/ cef_string_t* password)
        {
            // TODO: CefZipReader.OpenFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the file.
        /// </summary>
        /* FIXME: CefZipReader.CloseFile public */
        int CloseFile()
        {
            // TODO: CefZipReader.CloseFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read uncompressed file contents into the specified buffer. Returns &amp;
        /// 0 if an error occurred, 0 if at the end of file, or the number of
        /// bytes read.
        /// </summary>
        /* FIXME: CefZipReader.ReadFile public */
        int ReadFile(void* buffer, int bufferSize)
        {
            // TODO: CefZipReader.ReadFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the current offset in the uncompressed file contents.
        /// </summary>
        /* FIXME: CefZipReader.Tell public */
        long Tell()
        {
            // TODO: CefZipReader.Tell
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if at end of the file contents.
        /// </summary>
        /* FIXME: CefZipReader.Eof public */
        int Eof()
        {
            // TODO: CefZipReader.Eof
            throw new NotImplementedException();
        }


    }
}
