namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;

    public enum CefLogSeverity
    {
        Verbose = cef_log_severity_t.LOGSEVERITY_VERBOSE,
        Info = cef_log_severity_t.LOGSEVERITY_INFO,
        Warning = cef_log_severity_t.LOGSEVERITY_WARNING,
        Error = cef_log_severity_t.LOGSEVERITY_ERROR,
        ErrorReport = cef_log_severity_t.LOGSEVERITY_ERROR_REPORT,

        /// <summary>
        /// Disables logging completely.
        /// </summary>
        Disable = cef_log_severity_t.LOGSEVERITY_DISABLE
    }
}
