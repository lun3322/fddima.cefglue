namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class ScriptableObjectAttribute : Attribute
    {
        public static readonly ScriptableObjectAttribute Default = new ScriptableObjectAttribute();

        public ScriptableObjectAttribute()
        {
        }
    }
}
