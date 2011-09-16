namespace CefGlue.ScriptableObject
{
    using System;

    public enum NamingConvention
    {
        None = 0,

        Default = 1,

        /// <summary>
        /// camelCase
        /// </summary>
        CamelCase = 2,

        /// <summary>
        /// PascalCase
        /// </summary>
        PascalCase = 3,
    }
}
