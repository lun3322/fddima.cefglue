namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using CefGlue;
    using CefGlue.Windows.Forms;
    using System.Threading;

    public partial class MainForm : Form
    {
        private const string homeUrl = "res://client/index.html";

        private string caption;
        private CefBrowserSettings browserSettings;
        private BrowserSettingsForm browserSettingsForm;

        private CefWebBrowser browser;

        private ConsoleForm consoleForm;
        private BindingList<ConsoleMessageEventArgs> consoleMessages = new BindingList<ConsoleMessageEventArgs>();

        public MainForm()
        {
            InitializeComponent();
            // this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.caption = this.Text;

            this.browserSettings = new CefBrowserSettings();
            this.browserSettings.FileAccessFromFileUrlsAllowed = true;

            this.consoleForm = new ConsoleForm();
            consoleForm.BindData(consoleMessages);

            // TODO: check that form works correctly even with browser==null
            // TODO: also update state when browser was be destroyed
            // TODO: to create new browser use home page or adressbar test
            CreateBrowserControl();
        }

        protected override void DestroyHandle()
        {
            base.DestroyHandle();

            // TODO: do it only for CEF message loop -> detect cef message loop can be done if Cef.RunMessageLoop was be run, and it can be reflected in Cef.CurrentSettings
            if (!Cef.CurrentSettings.MultiThreadedMessageLoop)
            {
                NativeMethods.PostQuitMessage(0);
            }
        }

        private void CreateBrowserControl()
        {
            this.browser = new CefWebBrowser(browserSettings, homeUrl);
            browser.Dock = DockStyle.Fill;
            browser.BackColor = Color.White;

            browser.CanGoBackChanged += new EventHandler(browser_CanGoBackChanged);
            browser.CanGoForwardChanged += new EventHandler(browser_CanGoForwardChanged);
            browser.AddressChanged += new EventHandler(browser_AddressChanged);
            browser.TitleChanged += new EventHandler(browser_TitleChanged);
            browser.StatusMessage += new EventHandler<StatusMessageEventArgs>(browser_StatusMessage);
            browser.ConsoleMessage += new EventHandler<ConsoleMessageEventArgs>(browser_ConsoleMessage);
            browser.IsLoadingChanged += new EventHandler(browser_IsLoadingChanged);

            browser.Parent = this;
            browser.BringToFront();
        }

        private void browserCreateMenuItem_Click(object sender, EventArgs e)
        {
            if (this.browserSettingsForm == null)
            {
                this.browserSettingsForm = new BrowserSettingsForm();
                this.browserSettingsForm.BrowserSettings = browserSettings;
            }

            var result = this.browserSettingsForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                browserCloseMenuItem.PerformClick();
                CreateBrowserControl();
            }
        }

        private void browserCloseMenuItem_Click(object sender, EventArgs e)
        {
            if (this.browser != null)
            {
                this.browser.Dispose();
                this.browser = null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            browser.Focus();
        }

        void browser_CanGoBackChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            goBackButton.Enabled = browser.CanGoBack;
        }

        void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            goForwardButton.Enabled = browser.CanGoForward;
        }

        void browser_AddressChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            addressTextBox.Text = browser.Address;
        }

        void browser_TitleChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            var documentTitle = browser.Title;
            if (documentTitle != "" && documentTitle != caption)
            {
                this.Text = documentTitle + " - " + this.caption;
            }
            else
            {
                this.Text = this.caption;
            }
        }

        void browser_IsLoadingChanged(object sender, EventArgs e)
        {
            var isLoading = browser.IsLoading;
            progressBar.Visible = isLoading;
            
            stopButton.Visible = isLoading;
            reloadButton.Visible = !isLoading;

            stopButton.Enabled = stopButton.Visible;
            reloadButton.Enabled = reloadButton.Visible;
        }

        void browser_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            this.statusLabel.Visible = true;
            if (string.IsNullOrEmpty(e.Value))
            {
                this.statusLabel.Text = "";
            }
            else
            {
                this.statusLabel.Text = string.Format("{0}: {1}", e.Type, e.Value);
            }
        }

        void browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            this.consoleMessages.Add(e);
        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browserShowDevToolsMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.ShowDevTools();
        }

        private void browserCloseDevToolsMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.CloseDevTools();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.browser.GoBack();
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            this.browser.GoForward();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.browser.StopLoad();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            this.browser.Reload();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            this.browser.LoadURL(homeUrl);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.browser.LoadURL(addressTextBox.Text);
        }

        private void addressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') goButton.PerformClick();
        }

        private void consoleShowOrHideMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            if (this.consoleForm.Visible)
            {
                this.consoleForm.Hide();
                menuItem.Text = "&Show";
            }
            else
            {
                this.consoleForm.Show();
                menuItem.Text = "&Hide";
            }
        }

        private void consoleClearMenuItem_Click(object sender, EventArgs e)
        {
            this.consoleMessages.Clear();
        }

        private void browserZoomInMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.ZoomLevel += 1;
        }

        private void browserZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.ZoomLevel -= 1;
        }

        private void browserResetZoomMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.ZoomLevel = 0;
        }

        private void browserGetFrameNamesMenuItem_Click(object sender, EventArgs e)
        {
            var names = this.browser.GetFrameNames();
            MessageBox.Show(string.Join(", ", names));
        }

        private void helpAboutMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AboutForm())
            {
                form.ShowDialog();
            }
        }
    }
}
