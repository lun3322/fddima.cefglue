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
        Extension = 0x1,

        /// <summary>
        /// Lazy compilation of method marshallers.
        /// </summary>
        /// <remarks>
        /// Use this with caution:
        /// 
        /// By default, all method marshallers will be compiled when you get object binder (register object).
        /// In this case if compilation fails - you got exception and binder will not be created (object will not be registered).
        /// 
        /// If you set LazyCompile options - method marshallers will be compiled, when actuall call performed.
        /// In this case if compilation fails - you got exception of method invokation (i.e. called method throw exception).
        /// </remarks>
        LazyCompile = 0x2,
    }
}
