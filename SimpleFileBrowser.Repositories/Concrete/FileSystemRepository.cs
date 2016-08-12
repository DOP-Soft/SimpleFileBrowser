using SimpleFileBrowser.Repositories.Abstract;
using SimpleFileBrowser.Repositories.Interfaces;
using SimpleFileManager.Repositories.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileBrowser.Repositories.Concrete
{
    public class FileSystemRepository : BaseIOEntityRepository, IIOEntityRepository<FileSystemEntity>
    { 
        public IEnumerable<FileSystemEntity> Get(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var fsi in di.GetFileSystemInfos())
            {
                yield return new FileSystemEntity
                {
                    Name = fsi.Name,
                    FullName = fsi.FullName,
                    Type = fsi is DirectoryInfo ? FileSystemEntityType.Directory : FileSystemEntityType.File
                };
            }
        }


        public IEnumerable<FileSystemEntity> GetRootEntries()
        {
            var path = Directory.GetDirectoryRoot(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var fsi in di.GetFileSystemInfos())
            {
                yield return new FileSystemEntity
                {
                    Name = fsi.Name,
                    FullName = fsi.FullName,
                    Type = fsi is DirectoryInfo ? FileSystemEntityType.Directory : FileSystemEntityType.File
                };
            }
        }
    }
}