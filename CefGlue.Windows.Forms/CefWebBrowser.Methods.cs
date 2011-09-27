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
    }
}
