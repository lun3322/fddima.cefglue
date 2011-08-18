namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Diagnostics;

    public partial class CefWebBrowser : Control
    {
        private CefBrowserSettings settings;

        private CefClient client;

        private CefBrowser browser;
        private IntPtr browserWindowHandle;

        public CefWebBrowser()
            : this(new CefBrowserSettings())
        {
        }

        public CefWebBrowser(CefBrowserSettings settings)
            : this(settings, "about:blank")
        {
        }

        public CefWebBrowser(string startUrl)
            : this(new CefBrowserSettings(), startUrl)
        {
        }

        public CefWebBrowser(CefBrowserSettings settings, string startUrl)
        {
            this.settings = settings;
            this.StartUrl = startUrl;

            this.SetStyle(
                ControlStyles.ContainerControl
                | ControlStyles.ResizeRedraw
                | ControlStyles.FixedWidth
                | ControlStyles.FixedHeight
                | ControlStyles.StandardClick
                | ControlStyles.Selectable      // ?
                | ControlStyles.UserMouse
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.StandardDoubleClick
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.CacheText
                | ControlStyles.EnableNotifyMessage
                | ControlStyles.DoubleBuffer
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UseTextForAccessibility

                // | ControlStyles.Opaque
                , false);

            this.SetStyle(
                ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint, 
                true);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.Close();

            // FIXME: browser here
            if (this.browser != null) { this.browser.Dispose(); this.browser = null; }
#if DIAGNOSTICS
            ObjectCt.WriteDump();
#endif
            this.client = null;
            // if (this.client != null) { this.client.Dispose(); this.client = null; }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            var windowInfo = new CefWindowInfo();
            windowInfo.SetAsChild(this.Handle, 0, 0, this.Width, this.Height);

            this.client = CreateClient();

            CefBrowser.Create(windowInfo, client, this.StartUrl, this.settings);

            windowInfo.Dispose();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.browserWindowHandle != IntPtr.Zero)
            {
                NativeMethods.SetWindowPos(this.browserWindowHandle, IntPtr.Zero,
                    0, 0, this.Width, this.Height,
                    SetWindowPosFlags.NoMove | SetWindowPosFlags.NoZOrder
                    );
            }
        }

        private CefClient CreateClient()
        {
            var client = new Client(this);
            return client;
        }

        // TODO: SetFocus


    }
}
