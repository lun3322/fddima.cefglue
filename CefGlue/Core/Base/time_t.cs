namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal unsafe struct time_t
    {
        private int seconds;

        public DateTime ToDateTime()
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }
    }
}
