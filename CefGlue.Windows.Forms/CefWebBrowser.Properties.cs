namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private bool isLoading = false;
        private string title = "";
        private bool canGoBack = false;
        private bool canGoForward = false;
        private string address = null;

        public string StartUrl { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            private set
            {
                if (this.isLoading != value)
                {
                    this.isLoading = value;
                    this.PostIsLoadingChanged();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                // TODO: check null?
                if (this.title != value)
                {
                    this.title = value;
                    this.PostTitleChanged();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanGoBack
        {
            get
            {
                // FIXME: ???
                return this.canGoBack;
            }
            private set
            {
                if (this.canGoBack != value)
                {
                    this.canGoBack = value;
                    this.PostCanGoBackChanged();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanGoForward
        {
            get
            {
                // FIXME: ???
                return this.canGoForward;
            }
            private set
            {
                if (this.canGoForward != value)
                {
                    this.canGoForward = value;
                    this.PostCanGoForwardChanged();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Address
        {
            get
            {
                if (this.address == null)
                {
                    // FIXME: check that browser created
                    // FIXME: this.Address = this.browser.Address;
                    this.address = "";
                }
                return this.address;
            }
            private set
            {
                if (this.address != value)
                {
                    this.address = value;
                    this.PostAddressChanged();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ZoomLevel
        {
            get
            {
                return this.browser.ZoomLevel;
            }
            set
            {
                this.browser.ZoomLevel = value;
            }
        }

    }
}
