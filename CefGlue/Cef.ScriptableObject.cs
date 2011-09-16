namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Diagnostics;
    using ScriptableObject;

    partial class Cef
    {
        private static Dictionary<string, ScriptableObjectDef> scriptableObjects = new Dictionary<string, ScriptableObjectDef>();
        private static ScriptableObjectOptions DefaultScriptableObjectOptions = ScriptableObjectOptions.None;

        public static void RegisterScriptableObject(string member, object obj, Type type, ScriptableObjectOptions options)
        {
            var def = new ScriptableObjectDef(obj, type, member, options);

            if (scriptableObjects.ContainsKey(def.MemberName))
            {
                throw new ScriptableObjectException(string.Format(
                    "ScriptableObject with name '{0}' already registered.", member
                    ));
            }

            // force binder creation
            var binder = ScriptableObjectBinder.Get(def.TargetType);

            if (def.Extension)
            {
                // Register V8 extension
                var javaScriptCode = binder.CreateJavaScriptExtension(def.MemberName);
                var handler = new ScriptableObjectV8Handler(binder, def.Target, true);

                if (!Cef.RegisterExtension(def.ExtensionName, javaScriptCode, (CefV8Handler)handler))
                {
                    throw new InvalidOperationException("Cef.RegisterExtension failed.");
                }
            }

            scriptableObjects.Add(def.MemberName, def);
        }

        public static void ExportScriptableObjects(CefV8Value target)
        {
            foreach (var def in scriptableObjects.Values.Where(_ => !_.Extension))
            {
                var binder = ScriptableObjectBinder.Get(def.TargetType);

                // TODO: support namespaced object names
                // TODO: Dispose unused CefV8Values

                target.SetValue(def.MemberName, binder.CreateScriptableObject(def.Target));
            }
        }

        public static void RegisterScriptableObject(object obj)
        {
            RequireNotNullObject(obj);
            RegisterScriptableObject(obj, obj.GetType());
        }

        public static void RegisterScriptableObject(object obj, Type type)
        {
            RegisterScriptableObject(obj, type, DefaultScriptableObjectOptions);
        }

        public static void RegisterScriptableObject<T>(T obj)
        {
            RegisterScriptableObject(obj, typeof(T));
        }

        public static void RegisterScriptableObject(object obj, ScriptableObjectOptions options)
        {
            RequireNotNullObject(obj);

            RegisterScriptableObject(obj, obj.GetType(), options);
        }

        public static void RegisterScriptableObject(object obj, Type type, ScriptableObjectOptions options)
        {
            RegisterScriptableObject(GetMemberNameForType(type), obj, type, options);
        }

        public static void RegisterScriptableObject<T>(T obj, ScriptableObjectOptions options)
        {
            RegisterScriptableObject(obj, typeof(T), options);
        }

        public static void RegisterScriptableObject(string member, object obj)
        {
            RequireNotNullObject(obj);

            RegisterScriptableObject(member, obj, obj.GetType(), DefaultScriptableObjectOptions);
        }

        public static void RegisterScriptableObject(string member, object obj, Type type)
        {
            RegisterScriptableObject(member, obj, type, DefaultScriptableObjectOptions);
        }

        public static void RegisterScriptableObject<T>(string member, T obj)
        {
            RequireNotNullObject(obj);

            RegisterScriptableObject(member, obj, obj.GetType(), DefaultScriptableObjectOptions);
        }

        public static void RegisterScriptableObject(string member, object obj, ScriptableObjectOptions options)
        {
            RequireNotNullObject(obj);

            RegisterScriptableObject(member, obj, obj.GetType(), options);
        }

        public static void RegisterScriptableObject<T>(string member, T obj, ScriptableObjectOptions options)
        {
            RegisterScriptableObject(member, obj, typeof(T), options);
        }

        private static string GetMemberNameForType(Type type)
        {
            // TODO: use ScriptableObject attribute, if it set
            return NameHelper.ConvertMemberName(type.FullName, NamingConvention.Default);
        }

        private static void RequireNotNullObject(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
        }
    }
}
