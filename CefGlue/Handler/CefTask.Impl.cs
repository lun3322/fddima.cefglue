namespace CefGlue
{
    using System;
    using Core;
    using Diagnostics;

    unsafe partial class CefTask
    {
        /// <summary>
        /// Post a task for execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        public static void Post(CefThreadId threadId, CefTask task)
        {
            libcef.post_task((cef_thread_id_t)threadId, task.GetNativePointerAndAddRef());
        }

        /// <summary>
        /// Post a task for execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        public static void Post(CefThreadId threadId, Action action)
        {
            new CefActionTask(action).Post(threadId);
        }

        /// <summary>
        /// Post a task for execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        public void Post(CefThreadId threadId)
        {
            CefTask.Post(threadId, this);
        }

        /// <summary>
        /// Method that will be executed.
        /// |threadId| is the thread executing the call.
        /// </summary>
        private void execute(cef_task_t* self, cef_thread_id_t threadId)
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefTask, self, "Execute: ThreadId=[{0}]", threadId);
#endif

            this.Execute((CefThreadId)threadId);
        }

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <param name="threadId">Thread executing the call.</param>
        protected abstract void Execute(CefThreadId threadId);
    }

    internal sealed class CefActionTask : CefTask
    {
        private Action action;

        public CefActionTask(Action action)
        {
            this.action = action;
        }

        protected override void Execute(CefThreadId threadId)
        {
            this.action();
        }
    }
}
