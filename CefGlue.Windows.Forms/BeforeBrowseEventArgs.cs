namespace CefGlue.Windows.Forms
{
    using System;

    public sealed class BeforeBrowseEventArgs : System.ComponentModel.CancelEventArgs
    {
        public CefFrame Frame { get; private set; }
        public CefRequest Request { get; private set; }
        public CefHandlerNavType NavType { get; private set; }
        public bool IsRedirect { get; private set; }

        public BeforeBrowseEventArgs(CefFrame frame, CefRequest request, CefHandlerNavType navType, bool isRedirect)
        {
            Frame = frame;
            Request = request;
            NavType = navType;
            IsRedirect = isRedirect;
        }

    }
}
