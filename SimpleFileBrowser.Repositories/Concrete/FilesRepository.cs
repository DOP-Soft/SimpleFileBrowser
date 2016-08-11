using SimpleFileManager.Repositories.Abstract;
using SimpleFileManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileManager.Repositories.Concrete
{
    public class FilesRepository : BaseIOEntityRepository, IIOEntityRepository<FileInfo>
    {
        public IEnumerable<FileInfo> Get(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            return di.GetFiles();
        }

        public IEnumerable<FileInfo> GetRootEntries()
        {
            var path = Directory.GetDirectoryRoot(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            DirectoryInfo di = new DirectoryInfo(path);

            return di.GetFiles();
        }
    }
}
