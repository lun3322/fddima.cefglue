namespace CefGlue.Windows.Forms
{
    using System;

    public sealed class CefStatusMessageEventArgs : EventArgs
    {
        private readonly CefHandlerStatusType type;
        private readonly string value;

        public CefStatusMessageEventArgs(CefHandlerStatusType type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public CefHandlerStatusType Type { get { return this.type; } }

        public string Value { get { return this.value; } }
    }
}
