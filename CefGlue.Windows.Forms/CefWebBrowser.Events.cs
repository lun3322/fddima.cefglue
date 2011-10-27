namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    // TODO: NavStateChanged/NavigationStateChanged instead of CanGoBackChanged/CanGoForwardChanged ?

    partial class CefWebBrowser
    {
        public event EventHandler IsLoadingChanged;
        public event EventHandler TitleChanged;
        public event EventHandler CanGoBackChanged;
        public event EventHandler CanGoForwardChanged;
        public event EventHandler AddressChanged;
        public event EventHandler<KeyEventArgs> KeyEvent;
        public event EventHandler<StatusMessageEventArgs> StatusMessage;
        public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
        public event EventHandler<BeforeMenuEventArgs> BeforeMenu;
        public event EventHandler<MenuActionEventArgs> MenuAction;
        public event EventHandler<BeforeBrowseEventArgs> BeforeBrowse;

        protected virtual void OnIsLoadingChanged(EventArgs e)
        {
            RequireUIThread();

            var handler = IsLoadingChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostIsLoadingChanged()
        {
            this.synchronizationContext.Post((state) => { this.OnIsLoadingChanged(EventArgs.Empty); }, null);
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            RequireUIThread();

            var handler = TitleChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostTitleChanged()
        {
            this.synchronizationContext.Post((state) => { this.OnTitleChanged(EventArgs.Empty); }, null);
        }

        protected virtual void OnCanGoBackChanged(EventArgs e)
        {
            RequireUIThread();

            var handler = CanGoBackChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostCanGoBackChanged()
        {
            this.synchronizationContext.Post((state) => { this.OnCanGoBackChanged(EventArgs.Empty); }, null);
        }

        protected virtual void OnCanGoForwardChanged(EventArgs e)
        {
            RequireUIThread();

            var handler = CanGoForwardChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostCanGoForwardChanged()
        {
            this.synchronizationContext.Post((state) => { this.OnCanGoForwardChanged(EventArgs.Empty); }, null);
        }

        protected virtual void OnAddressChanged(EventArgs e)
        {
            RequireUIThread();

            var handler = AddressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostAddressChanged()
        {
            this.synchronizationContext.Post((state) => { this.OnAddressChanged(EventArgs.Empty); }, null);
        }

        protected virtual void OnStatusMessage(StatusMessageEventArgs e)
        {
            RequireUIThread();

            var handler = StatusMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostStatusMessage(StatusMessageEventArgs e)
        {
            this.synchronizationContext.Post((state) => { this.OnStatusMessage((StatusMessageEventArgs)state); }, e);
        }

        protected virtual void OnConsoleMessage(ConsoleMessageEventArgs e)
        {
            RequireUIThread();

            var handler = ConsoleMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PostConsoleMessage(ConsoleMessageEventArgs e)
        {
            this.synchronizationContext.Post((state) => { this.OnConsoleMessage((ConsoleMessageEventArgs)state); }, e);
        }

        private bool PostKeyEvent(CefHandlerKeyEventType type, int code, CefHandlerKeyEventModifiers modifiers, bool isSystemKey)
        {
            var handler = KeyEvent;
            if (handler != null)
            {
                KeyEventArgs ea = new KeyEventArgs(type, code, modifiers, isSystemKey);
                handler(this, ea);
                return ea.Handled;
            }
            return false;
        }

        private bool PostBeforeMenu(CefHandlerMenuInfo menuInfo)
        {
            var handler = BeforeMenu;
            if (handler != null)
            {
                BeforeMenuEventArgs ea = new BeforeMenuEventArgs(menuInfo);
                handler(this, ea);
                return ea.Cancel;
            }
            return false;
        }

        private bool PostMenuAction(CefHandlerMenuId menuId)
        {
            var handler = MenuAction;
            if (handler != null)
            {
                MenuActionEventArgs ea = new MenuActionEventArgs(menuId);
                handler(this, ea);
                return ea.Cancel;
            }
            return false;
        }

        private bool PostBeforeBrowse(CefFrame frame, CefRequest request, CefHandlerNavType navType, bool isRedirect)
        {
            var handler = BeforeBrowse;
            if (handler != null)
            {
                BeforeBrowseEventArgs ea = new BeforeBrowseEventArgs(frame, request, navType, isRedirect);
                handler(this, ea);
                return ea.Cancel;
            }
            return false;
        }

        [Conditional("DEBUG")]
        private void RequireUIThread()
        {
            if (this.InvokeRequired) throw new InvalidOperationException("This method can be called on the UI thread.");
        }
    }
}
