namespace CefGlue
{
    using System;

    public enum PopupCreation
    {
        /// <summary>
        /// Create the new popup window based on the parameters in windowInfo.
        /// </summary>
        Proceed = 0,

        /// <summary>
        /// Cancel creation of the popup window
        /// </summary>
        Cancel = 1
    }
}
