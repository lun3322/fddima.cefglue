namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Context
    {
        /// <summary>
        /// Returns the current (top) context object in the V8 context stack.
        /// </summary>
        public static CefV8Context GetCurrentContext()
        {
            return CefV8Context.From(
                libcef.v8context_get_current_context()
                );
        }

        /// <summary>
        /// Returns the entered (bottom) context object in the V8 context stack.
        /// </summary>
        public static CefV8Context GetEnteredContext()
        {
            return CefV8Context.From(
                libcef.v8context_get_entered_context()
                );
        }

        /// <summary>
        /// Returns the browser for this context.
        /// </summary>
        public CefBrowser GetBrowser()
        {
            return CefBrowser.From(
                this.get_browser(this.ptr)
                );
        }

        /// <summary>
        /// Returns the frame for this context.
        /// </summary>
        public CefFrame GetFrame()
        {
            return CefFrame.From(
                this.get_frame(this.ptr)
                );
        }

        /// <summary>
        /// Returns the global object for this context.
        /// </summary>
        public CefV8Value GetGlobal()
        {
            return CefV8Value.From(
                this.get_global(this.ptr)
                );
        }

        /// <summary>
        /// Enter this context.
        /// A context must be explicitly entered before creating a V8 Object, Array or Function asynchronously.
        /// Exit() must be called the same number of times as Enter() before releasing this context.
        /// V8 objects belong to the context in which they are created.
        /// Returns true if the scope was entered successfully.
        /// </summary>
        public bool Enter()
        {
            return this.enter(this.ptr) != 0;
        }

        /// <summary>
        /// Exit this context.
        /// Call this method only after calling Enter().
        /// Returns true if the scope was exited successfully.
        /// </summary>
        public bool Exit()
        {
            return this.exit(this.ptr) != 0;
        }

    }
}
