using SimpleFileManager.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleFileManager.Controllers
{
    public class FilesController : ApiController
    {
        public FilesController()
        {
            _filesRepository = new FilesRepository();
        }

        public IHttpActionResult Get()
        {
            var files = _filesRepository.GetRootEntries();
            long[] count = GetFilesCount(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));

            return Json(new
            {
                Less5Mb = count[0],
                From10To50Mb = count[1],
                MoreThan100Mb = count[2],
                Files = files
            });
        }

        public IHttpActionResult Get(string path)
        {
            var files = _filesRepository.Get(path);

            long[] count = GetFilesCount(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));

            return Json(new
            {
                Less5Mb = count[0],
                From10To50Mb = count[1],
                MoreThan100Mb = count[2],
                Files = files
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        private long[] GetFilesCount(string path)
        {
            var countLess10Mb = _filesRepository.GetCount(path, 0, 10);
            var countFrom10To50Mb = _filesRepository.GetCount(path, 11, 50);
            var countMoreThan100Mb = _filesRepository.GetCount(path, 100, uint.MaxValue);

            return new long[] { countLess10Mb, countFrom10To50Mb, countMoreThan100Mb };
        }

        private FilesRepository _filesRepository;
    }
}
