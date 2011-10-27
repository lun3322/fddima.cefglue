namespace CefGlue.Windows.Forms
{
    using System;

    public sealed class MenuActionEventArgs : System.ComponentModel.CancelEventArgs
	{
		public CefHandlerMenuId MenuId { get; private set; }

		public MenuActionEventArgs(CefHandlerMenuId menuId)
		{
			MenuId = menuId;
        }
    }
}
