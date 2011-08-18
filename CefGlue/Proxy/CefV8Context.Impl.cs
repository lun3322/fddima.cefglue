namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Context
    {
        /// <summary>
        /// Returns the current (top) context object in the V8 context stack.
        /// </summary>
        /* FIXME: CefV8Context.GetCurrentContext public */
        static cef_v8context_t* GetCurrentContext()
        {
            // TODO: CefV8Context.GetCurrentContext
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the entered (bottom) context object in the V8 context stack.
        /// </summary>
        /* FIXME: CefV8Context.GetEnteredContext public */
        static cef_v8context_t* GetEnteredContext()
        {
            // TODO: CefV8Context.GetEnteredContext
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the browser for this context.
        /// </summary>
        /* FIXME: CefV8Context.GetBrowser public */
        cef_browser_t* GetBrowser()
        {
            // TODO: CefV8Context.GetBrowser
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the frame for this context.
        /// </summary>
        /* FIXME: CefV8Context.GetFrame public */
        cef_frame_t* GetFrame()
        {
            // TODO: CefV8Context.GetFrame
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the global object for this context.
        /// </summary>
        /* FIXME: CefV8Context.GetGlobal public */
        cef_v8value_t* GetGlobal()
        {
            // TODO: CefV8Context.GetGlobal
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enter this context. A context must be explicitly entered before
        /// creating a V8 Object, Array or Function asynchronously. Exit() must
        /// be called the same number of times as Enter() before releasing this
        /// context. V8 objects belong to the context in which they are created.
        /// Returns true if the scope was entered successfully.
        /// </summary>
        /* FIXME: CefV8Context.Enter public */
        int Enter()
        {
            // TODO: CefV8Context.Enter
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exit this context. Call this method only after calling Enter().
        /// Returns true if the scope was exited successfully.
        /// </summary>
        /* FIXME: CefV8Context.Exit public */
        int Exit()
        {
            // TODO: CefV8Context.Exit
            throw new NotImplementedException();
        }


    }
}
