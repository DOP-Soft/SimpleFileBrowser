using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleFileManager.Controllers
{
    public class DirectoriesController : ApiController
    {
        // GET: api/Directories
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Directories/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Directories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Directories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Directories/5
        public void Delete(int id)
        {
        }
    }
}
