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
            var files = _fileSystemRepository.GetRootEntries();
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
                Less5Mb = count[0],
                From10To50Mb = count[1],
                MoreThan100Mb = count[2],
                Files = files
            });
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]string path)
        {
            // Get list of dirs and files.
            var files = _fileSystemRepository.Get(path);
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
