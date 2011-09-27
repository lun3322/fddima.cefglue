namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            // TODO: bind to browser 'controller' object, which will be implemented in form, via interface IAboutFormController 
            // it must implement Close() for closing form.
            // and OpenUrl(...) to open links in default (system) browser
            // and CefGlueVersion property.
            // and other... to show info about CefGlue (libcef version, etc...)
        }
    }
}
