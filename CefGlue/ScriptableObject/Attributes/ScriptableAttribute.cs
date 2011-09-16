namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ScriptableAttribute : Attribute
    {
        private bool visible;
        private NamingConvention namingConvention;

        public ScriptableAttribute()
            : this(true) { }

        public ScriptableAttribute(bool visible)
            : this(visible, NamingConvention.Default) { }

        public ScriptableAttribute(NamingConvention namingConvention)
            : this(true, namingConvention) { }

        public ScriptableAttribute(bool visible, NamingConvention namingConvention)
        {
            this.visible = visible;
            this.namingConvention = namingConvention;
        }

        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        public NamingConvention NamingConvention
        {
            get { return this.namingConvention; }
            set { this.namingConvention = value; }
        }

    }
}
