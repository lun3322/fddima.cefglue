namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {

        /// <summary>
        /// Closes this browser window. This method will do not block the calling thread.
        /// </summary>
        public void Close()
        {
            // TODO: change this method - it must Dispose itself
            if (this.browser != null)
            {
                this.browser.Close();
            }
        }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        public void GoBack()
        {
            this.browser.GoBack();
        }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        public void GoForward()
        {
            this.browser.GoForward();
        }

        /// <summary>
        /// Reload the current page.
        /// </summary>
        public void Reload()
        {
            this.browser.Reload();
        }

        /// <summary>
        /// Reload the current page ignoring any cached data.
        /// </summary>
        public void ReloadIgnoreCache()
        {
            this.browser.ReloadIgnoreCache();
        }

        /// <summary>
        /// Stop loading the page.
        /// </summary>
        public void StopLoad()
        {
            this.browser.StopLoad();
        }

        /// <summary>
        /// Open developer tools in its own window.
        /// </summary>
        public void ShowDevTools()
        {
            // FIXME: check that browser created
            this.browser.ShowDevTools();
        }

        /// <summary>
        /// Explicitly close the developer tools window if one exists for this browser instance.
        /// </summary>
        public void CloseDevTools()
        {
            // FIXME: check that browser created
            this.browser.CloseDevTools();
        }

        public IEnumerable<string> GetFrameNames()
        {
            // TODO: check CefWebBrowser.GetFrameNames implementation
            if (Cef.CurrentlyOn(CefThreadId.UI))
            {
                return this.browser.GetFrameNames().AsEnumerable();
            }
            else
            {
                IEnumerable<string> frameNames = null;
                ManualResetEvent mrevent = new ManualResetEvent(false);
                CefTask.Post(CefThreadId.UI, () =>
                {
                    frameNames = this.browser.GetFrameNames().AsEnumerable();
                    mrevent.Set();
                });
                while (!mrevent.WaitOne(50)) // TODO: do it only if we are on WinForms UI thread
                {
                    Application.DoEvents();
                }
                mrevent.Dispose();
                return frameNames;
            }
        }

        // frame-related

        public void LoadURL(string url)
        {
            var frame = this.browser.GetMainFrame();
            frame.LoadURL(url);
            frame.Dispose();
        }

        public void LoadURL(Uri url)
        {
            LoadURL(url.ToString());
        }

        // TODO: move out InvokeScript methods to ScriptableObject feature?

        public object InvokeScript(string memberName, params object[] args)
        {
            // TODO: check CefWebBrowser.InvokeScript implementation
            if (Cef.CurrentlyOn(CefThreadId.UI))
            {
                return InvokeScript(this.mainFrameV8Context, memberName, args);
            }
            else
            {
                object result = null;
                Exception exception = null;
                ManualResetEvent mrevent = new ManualResetEvent(false);
                CefTask.Post(CefThreadId.UI, () =>
                {
                    try
                    {
                        result = InvokeScript(this.mainFrameV8Context, memberName, args);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }
                    finally
                    {
                        mrevent.Set();
                    }
                });
                while (!mrevent.WaitOne(50)) // TODO: do it only if we are on WinForms UI thread
                {
                    Application.DoEvents();
                }
                mrevent.Dispose();

                if (exception != null) throw exception;
                return result;
            }
        }

        private static object InvokeScript(CefV8Context context, string memberName, params object[] args)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (!context.Enter()) throw new CefException("Failed to enter V8 context.");
            try
            {
                // TODO: this list can be private list of context, 'cause we can invoke only one function at one time
                List<CefV8Value> proxies = new List<CefV8Value>(16);

                // javascript 'this' object
                CefV8Value obj = null;

                CefV8Value target = context.GetGlobal();
                proxies.Add(target);
                if (!memberName.Contains('.'))
                {
                    obj = target;
                    target = obj.GetValue(memberName);
                    proxies.Add(target);
                }
                else
                {
                    foreach (var member in memberName.Split('.'))
                    {
                        obj = target;
                        target = obj.GetValue(member); // TODO: do analysis of target - if it is not an object - throw
                        if (!target.IsObject) throw new CefException("Argument 'memberName' must be member access expression to a function. Invalid object in path.");
                        proxies.Add(target);
                    }
                }
                if (!target.IsFunction) throw new ArgumentException("Argument 'memberName' must be member access expression to a function.");

                CefV8Value[] v8Args;

                if (args.Length == 0) v8Args = null;
                else
                {
                    v8Args = new CefV8Value[args.Length]; // TODO: InvokeScript core can be optimized by prevent recreating arrays
                    for (var i = 0; i < args.Length; i++)
                    {
                        var value = CefConvert.ToV8Value(args[i]);
                        v8Args[i] = value;
                    }
                }

                CefV8Value v8RetVal;
                string exception;
                target.ExecuteFunctionWithContext(context, obj, v8Args, out v8RetVal, out exception);

                // force destroing of proxies, to avoid unneccessary GC load (CLR and V8)
                foreach (var proxy in proxies) proxy.Dispose();
                proxies.Clear();

                if (!string.IsNullOrEmpty(exception)) throw new JavaScriptException(exception);

                var result = CefConvert.ToObject(v8RetVal);
                v8RetVal.Dispose();
                return result;
            }
            finally
            {
                if (!context.Exit()) throw new CefException("Failed to exit V8 context.");
            }
        }

    }
}
