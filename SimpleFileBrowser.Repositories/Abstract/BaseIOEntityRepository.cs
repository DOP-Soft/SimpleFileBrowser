using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileManager.Repositories.Abstract
{
    public class BaseIOEntityRepository
    {
        public virtual long GetCount(string path, long lowMbBound, long highMbBound)
        {
            long count = 0;
            long _lowBytesBound = lowMbBound * 1024 * 1024;
            long _highBytesBound = highMbBound * 1024 * 1024;
            DirectoryInfo di = new DirectoryInfo(path);

            try
            {
                foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories))
                {
                    if (_lowBytesBound == 0)
                    {
                        if (fi.Length <= _highBytesBound)
                        {
                            count++;
                        }
                    }
                    else if (_highBytesBound == long.MaxValue)
                    {
                        if (fi.Length >= _lowBytesBound)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (fi.Length > _lowBytesBound && fi.Length <= _highBytesBound)
                        {
                            count++;
                        }
                    }
                }
            }
            catch { }

            return count;
        }
    }
}
