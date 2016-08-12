using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileBrowser.Repositories.Models
{
    public struct FileLengthBound
    {
        public FileLengthBound(long lowMbBound, long highMbBound)
        {
            LowMbBound = lowMbBound;
            HighMbBound = highMbBound;
        }

        public long LowMbBound { get; set; }
        public long HighMbBound { get; set; }
    }

    public static class FromMbToBytesHelper
    {
        // Helpful method to compare file length with boundary condition in Mb.
        public static long ToBytes(this long Mbytes)
        {
            return Mbytes * 1024 * 1024;
        }
    }
}

