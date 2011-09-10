namespace CefGlue.ScriptableObject
{
    using System;

    [Flags]
    public enum ScriptableObjectOptions
    {
        None = 0,

        /// <summary>
        /// Register object using v8 extension.
        /// </summary>
        Extension = 0x1
    }
}
