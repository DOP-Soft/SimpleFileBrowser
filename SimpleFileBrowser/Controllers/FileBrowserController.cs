using SimpleFileBrowser.Repositories.Concrete;
using SimpleFileBrowser.Repositories.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleFileBrowser.Controllers
{
    public class FileBrowserController : ApiController
    {
        public FileBrowserController()
        {
            _fileSystemRepository = new FileSystemRepository();
        }

        public IHttpActionResult Get()
        {
            List<SimpleFileManager.Repositories.Models.FileSystemEntity> files = _fileSystemRepository.GetRootEntries().ToList();

            // Get parent dir.
            var parentDirInfo = Directory.GetParent((files != null && files.Count > 0) ? files[0].FullName : @"D:\Dell\"/*Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))*/);
            string parentDir = (parentDirInfo != null) ? parentDirInfo.FullName : null;

            long[] count = _fileSystemRepository.GetFilesCount(
                @"D:\Dell\"/*Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))*/, 
                new FileLengthBound[3] 
                {
                    new FileLengthBound(0, 10),
                    new FileLengthBound(11, 50),
                    new FileLengthBound(100, long.MaxValue)
                });

            return Json(new
            {
                ParentDir = parentDir,
                CurrentDir = Path.GetDirectoryName((files != null && files.Count > 0) ? files[0].FullName : @"D:\Dell\"/*Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))*/),
                Less5Mb = count[0],
                From10To50Mb = count[1],
                MoreThan100Mb = count[2],
                Files = files
            });
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]dynamic data)
        {
            string path = data.path;
            
            // Get list of dirs and files.
            List<SimpleFileManager.Repositories.Models.FileSystemEntity> files = _fileSystemRepository.Get(path).ToList();

            // Get parent dir.
            var parentDirInfo = Directory.GetParent(path);
            string parentDir = (parentDirInfo != null) ? parentDirInfo.FullName : null;

            // Count all files that matches boundary condition.
            long[] count = _fileSystemRepository.GetFilesCount(
                path,
                new FileLengthBound[3]
                {
                    new FileLengthBound(0, 10),
                    new FileLengthBound(11, 50),
                    new FileLengthBound(100, long.MaxValue)
                });

            return Json(new
            {
                ParentDir = parentDir,
                CurrentDir = Path.GetDirectoryName((files != null && files.Count > 0) ? files[0].FullName : @"D:\Dell\"/*Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))*/),
                Less5Mb = count[0],
                From10To50Mb = count[1],
                MoreThan100Mb = count[2],
                Files = files
            });
        }

        // Class-repository that gives ability to explore file system.
        private FileSystemRepository _fileSystemRepository;
    }
}
