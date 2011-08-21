namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefPrintHandler
    {
        /// <summary>
        /// Called to allow customization of standard print options before the
        /// print dialog is displayed. |printOptions| allows specification of
        /// paper size, orientation and margins. Note that the specified margins
        /// may be adjusted if they are outside the range supported by the
        /// printer. All units are in inches. Return false to display the default
        /// print options or true to display the modified |printOptions|.
        /// </summary>
        private int get_print_options(cef_print_handler_t* self, cef_browser_t* browser, cef_print_options_t* printOptions)
        {
            ThrowIfObjectDisposed();
            // TODO: CefPrintHandler.get_print_options
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to format print headers and footers. |printInfo| contains
        /// platform- specific information about the printer context. |url| is
        /// the URL if the currently printing page, |title| is the title of the
        /// currently printing page, |currentPage| is the current page number and
        /// |maxPages| is the total number of pages. Six default header locations
        /// are provided by the implementation: top left, top center, top right,
        /// bottom left, bottom center and bottom right. To use one of these
        /// default locations just assign a string to the appropriate variable.
        /// To draw the header and footer yourself return true. Otherwise,
        /// populate the approprate variables and return false.
        /// </summary>
        private int get_print_header_footer(cef_print_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, /*const*/ cef_print_info_t* printInfo, /*const*/ cef_string_t* url, /*const*/ cef_string_t* title, int currentPage, int maxPages, cef_string_t* topLeft, cef_string_t* topCenter, cef_string_t* topRight, cef_string_t* bottomLeft, cef_string_t* bottomCenter, cef_string_t* bottomRight)
        {
            ThrowIfObjectDisposed();
            // TODO: CefPrintHandler.get_print_header_footer
            throw new NotImplementedException();
        }


    }
}
