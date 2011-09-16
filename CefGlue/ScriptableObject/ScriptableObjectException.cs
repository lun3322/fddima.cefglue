namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Security.Permissions;
    using System.Text;

    public class ScriptableObjectException : CefException
    {
        public ScriptableObjectException() : base() { }
        public ScriptableObjectException(string message) : base(message) { }
        public ScriptableObjectException(string message, Exception innerException) : base(message, innerException) { }
    }
}
