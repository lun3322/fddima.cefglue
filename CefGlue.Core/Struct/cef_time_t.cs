namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    ///
    // Time information. Values should always be in UTC.
    ///
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe partial struct cef_time_t
    {
        int year;          // Four digit year "2007"
        int month;         // 1-based month (values 1 = January, etc.)
        int day_of_week;   // 0-based day of week (0 = Sunday, etc.)
        int day_of_month;  // 1-based day of month (1-31)
        int hour;          // Hour within the current day (0-23)
        int minute;        // Minute within the current hour (0-59)
        int second;        // Second within the current minute (0-59 plus leap
        //   seconds which may take it up to 60).
        int millisecond;   // Milliseconds within the current second (0-999)
    }
}
