namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    [ToolboxBitmap(typeof(CefWebBrowser))]
    public partial class CefWebBrowser : Control
    {
        // TODO: move most of this fields to BrowserCore/BrowserContext
        private SynchronizationContext synchronizationContext;

        private CefBrowserSettings settings;

        private Client client;

        private CefBrowser browser;
        private IntPtr browserWindowHandle;

        private CefV8Context mainFrameV8Context;

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
            this.synchronizationContext = SynchronizationContext.Current;
            if (this.synchronizationContext == null) throw new InvalidOperationException("SynchronizationContext required. Try create control on UI thread.");

            this.settings = settings;
            this.StartUrl = startUrl;

            this.SetStyle(
                ControlStyles.ContainerControl
                | ControlStyles.ResizeRedraw
                | ControlStyles.FixedWidth
                | ControlStyles.FixedHeight
                | ControlStyles.StandardClick
                //| ControlStyles.Selectable
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
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.Selectable,
                true);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            // TODO: give to associated CefWebBrowser.Client's to know that we are disposing,
            // in this case client must not generate events for control.

            this.Close();

            // FIXME: browser here
            if (this.browser != null) { this.browser.Dispose(); this.browser = null; }
            this.client = null;
            // if (this.client != null) { this.client.Dispose(); this.client = null; }
            if (this.mainFrameV8Context != null) { this.mainFrameV8Context.Dispose(); this.mainFrameV8Context = null; }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (this.DesignMode)
            {
                this.Paint += new PaintEventHandler(DesignModePaint);
            }
            else
            {
                // TODO: fix when browser still creating, but control already disposed
                // it can be done via setting client to detached state, and onaftercreated
                // force browser to be closed.

                var windowInfo = new CefWindowInfo();
                windowInfo.SetAsChild(this.Handle, 0, 0, this.Width, this.Height);

                this.client = CreateClient();

                CefBrowser.Create(windowInfo, client, this.StartUrl, this.settings);

                windowInfo.Dispose();
            }
        }

        private void DesignModePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(SystemPens.ControlDark, 0, 0, this.Width - 1, this.Height - 1);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ResizeBrowserWindow();
        }

        private void ResizeBrowserWindow()
        {
            if (this.browserWindowHandle != IntPtr.Zero)
            {
                NativeMethods.SetWindowPos(this.browserWindowHandle, IntPtr.Zero,
                    0, 0, this.Width, this.Height,
                    SetWindowPosFlags.NoMove | SetWindowPosFlags.NoZOrder
                    );
            }
        }

        /*
        protected override void WndProc(ref Message m)
        {
            Cef.Logger.Info(LogTarget.Default, "CefWebBrowser.WndProc: Msg=[{0}]", ((WM)m.Msg));
            base.WndProc(ref m);
        }
        */

        public override bool Focused
        {
            get
            {
                var handle = NativeMethods.GetFocus();
                return handle != IntPtr.Zero && this.browserWindowHandle == handle;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            // base.OnGotFocus(e);

            if (!Focused)
            {
                if (this.browser != null)
                {
#if DIAGNOSTICS
                    Cef.Logger.Info(LogTarget.Default, "OnGotFocus");
#endif
                    //this.browser.SendFocusEvent(true);
                    // FIXME: this is to avoid dead lock with Invoke from CEF UI thread, may be we must execute this call on CEF UI thread async
                    CefTask.Post(CefThreadId.UI, () => { this.browser.SetFocus(true); });
                    // this.browser.SendFocusEvent(true);
                }
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (Focused)
            {
                if (this.browser != null)
                {
                    // Cef.Logger.Info(LogTarget.Default, "OnLostFocus");
                    CefTask.Post(CefThreadId.UI, () => this.browser.SetFocus(false));
                    // this.browser.SendFocusEvent(false);
                    // FIXME: this is to avoid dead lock with Invoke from CEF UI thread, may be we must execute this call on CEF UI thread async
                }
            }
        }

        private Client CreateClient()
        {
            var client = new Client(this);
            return client;
        }
    }
}
