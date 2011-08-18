namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Security.Permissions;
    using System.Text;

    public class CefGlueException : Exception
    {
        public CefGlueException() : base() { }
        public CefGlueException(string message) : base(message) { }
        public CefGlueException(string message, Exception innerException) : base(message, innerException) { }
    }
}
