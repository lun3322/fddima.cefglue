namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;

    internal static class InvokeMethodHelper
    {
        public static void ThrowArgumentCountMismatch()
        {
            throw new ScriptableObjectException("Argument count mismatch.");
        }

        public unsafe delegate cef_v8value_t* CreateUndefinedNativeV8Value();
    }
}
