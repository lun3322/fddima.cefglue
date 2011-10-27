namespace CefGlue.Windows.Forms
{
    using System;

    public sealed class BeforeMenuEventArgs : System.ComponentModel.CancelEventArgs
    {
        public CefHandlerMenuInfo MenuInfo { get; private set; }

        public BeforeMenuEventArgs(CefHandlerMenuInfo menuInfo)
        {
            MenuInfo = menuInfo;
        }
    }
}
