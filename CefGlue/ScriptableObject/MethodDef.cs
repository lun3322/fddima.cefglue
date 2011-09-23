namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Core;

    internal sealed class MethodDef : DispatchTableEntry
    {
        private MethodDefAttributes attributes;
        private object methods;
        private InvokeMethod invoke;

        public MethodDef(string name, MethodDefAttributes attributes)
            : base(name)
        {
            Check(attributes);

            this.attributes = attributes;
        }

        public MethodDefAttributes Attributes { get { return this.attributes; } }

        public bool Hidden { get { return (this.attributes & MethodDefAttributes.Hidden) != 0; } }
        public bool Getter { get { return (this.attributes & MethodDefAttributes.Getter) != 0; } }
        public bool Setter { get { return (this.attributes & MethodDefAttributes.Setter) != 0; } }
        public bool Static { get { return (this.attributes & MethodDefAttributes.Static) != 0; } }
        public bool HasOverloads { get { return (this.attributes & MethodDefAttributes.HasOverloads) != 0; } }
        public bool Compiled { get { return (this.attributes & MethodDefAttributes.Compiled) != 0; } }

        public void Add(MethodInfo method)
        {
            if (this.methods == null)
            {
                this.methods = method;
                return;
            }

            if ((this.Attributes & (MethodDefAttributes.Getter | MethodDefAttributes.Setter)) != 0)
            {
                throw new ScriptableObjectException("Property accessor methods can't have overloads.");
            }

            if (this.methods is MethodInfo)
            {
                this.methods = new MethodInfo[] { (MethodInfo)this.methods, method };
                this.attributes |= MethodDefAttributes.HasOverloads;
                return;
            }

            var methods = this.methods as MethodInfo[];
            Array.Resize<MethodInfo>(ref methods, methods.Length + 1);
            methods[methods.Length - 1] = method;
            this.methods = methods;
        }

        private static void Check(MethodDefAttributes attributes)
        {
            var isHidden = (attributes & MethodDefAttributes.Hidden) != 0;
            var isGetter = (attributes & MethodDefAttributes.Getter) != 0;
            var isSetter = (attributes & MethodDefAttributes.Setter) != 0;
            var isStatic = (attributes & MethodDefAttributes.Static) != 0;
            var isHasOverloads = (attributes & MethodDefAttributes.HasOverloads) != 0;
            var isPropertyAccessor = isGetter || isSetter;
            var isCompiled = (attributes & MethodDefAttributes.Compiled) != 0;

            if (isGetter && isSetter) throw new InvalidOperationException("Property accessor can be getter or setter, but not both.");
            if (isPropertyAccessor && !isHidden) throw new InvalidOperationException("Property accessor methods must be hidden.");
            if (isHasOverloads) throw new InvalidOperationException("HasOverloads attribute can't be set directly.");
            if (isCompiled) throw new InvalidOperationException("Compiled attribute can't be set directly.");
        }

        public string[] GetArgumentNames()
        {
            if (HasOverloads)
            {
                throw new NotSupportedException("Overloads currently is not supported.");
            }

            var methodInfo = (MethodInfo)this.methods;

            return methodInfo.GetParameters().Select(_ => _.Name).ToArray();
        }

        // TODO: rename it
        public bool ReturnTypeIsVoid
        {
            get
            {
                // TODO: check real retval of method and their overloads. if all overloads return void == then method returnsVoid
                if (HasOverloads)
                {
                    throw new NotSupportedException("Overloads currently is not supported.");
                }

                var methodInfo = (MethodInfo)this.methods;
                return methodInfo.ReturnType == typeof(void);
            }
        }

        public void Compile()
        {
            if (!this.Compiled)
            {
                if (HasOverloads)
                {
                    throw new NotSupportedException("Overloads currently is not supported.");
                }

                this.invoke = InvokeMethodBuilder.Create(this, (MethodInfo)methods);

                this.attributes |= MethodDefAttributes.Compiled;
            }
        }

        internal unsafe void Invoke(object instance, int argumentsCount, cef_v8value_t** arguments, cef_v8value_t** retval)
        {
            if (!this.Compiled)
            {
                this.Compile();
            }

            this.invoke(instance, argumentsCount, arguments, retval);
        }

    }
}
