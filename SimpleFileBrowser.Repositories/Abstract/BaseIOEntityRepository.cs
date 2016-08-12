using SimpleFileBrowser.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileBrowser.Repositories.Abstract
{
    public class BaseIOEntityRepository
    {
        public virtual long[] GetFilesCount(string root, FileLengthBound[] lengthBounds)
        {
            // Array length depends of input length boundary conditions.
            long[] filesCountPerCondition = new long[lengthBounds.Length];

            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    continue;
                }

                // Enumerate all files in directory and check matching the file length condition.
                foreach (string file in files)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        for (var i = 0; i < lengthBounds.Length; i++)
                        {
                            if (lengthBounds[i].LowMbBound == 0)
                            {
                                if (fi.Length <= lengthBounds[i].HighMbBound.ToBytes())
                                {
                                    filesCountPerCondition[i]++;
                                    continue;
                                }
                            }
                            else if (lengthBounds[i].HighMbBound.ToBytes() == long.MaxValue)
                            {
                                if (fi.Length >= lengthBounds[i].LowMbBound.ToBytes())
                                {
                                    filesCountPerCondition[i]++;
                                    continue;
                                }
                            }
                            else
                            {
                                if (fi.Length > lengthBounds[i].LowMbBound && fi.Length <= lengthBounds[i].HighMbBound)
                                {
                                    filesCountPerCondition[i]++;
                                    continue;
                                }
                            }
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }

            return filesCountPerCondition;
        }
    }
}
