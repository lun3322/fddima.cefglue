namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal sealed class ScriptableObjectDef
    {
        private readonly string member;
        private readonly object target;
        private readonly Type targetType;
        private readonly ScriptableObjectOptions options;

        public ScriptableObjectDef(object target, Type targetType, string member, ScriptableObjectOptions options)
        {
            if (string.IsNullOrEmpty(member)) throw new ArgumentNullException(member);
            if (target == null) throw new ArgumentNullException("target");
            if (targetType == null) throw new ArgumentNullException("targetType");
            // validate options here

            if (!targetType.IsAssignableFrom(target.GetType()))
            {
                throw new ScriptableObjectException(string.Format(
                    "ScriptableObject is not assignable from '{0}'.", target.GetType().FullName
                    ));
            }

            this.member = member;
            this.target = target;
            this.targetType = targetType;
            this.options = options;
        }

        public string MemberName { get { return this.member; } }
        public string ExtensionName { get { return this.member; } }
        public object Target { get { return this.target; } }
        public Type TargetType { get { return this.targetType; } }
        public ScriptableObjectOptions Options { get { return this.options; } }

        public bool Extension { get { return (this.Options & ScriptableObjectOptions.Extension) != 0; } }
    }

}
