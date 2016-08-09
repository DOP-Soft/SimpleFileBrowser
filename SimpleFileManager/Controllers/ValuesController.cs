using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleFileManager.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            //return Json(new string[] { "value1", "value2"});
            return Json(new { Name = "Oleh", Age = 22 });

        }

        // GET api/values/5
        public JsonResult<string> Get(int id)
        {
            return Json("value");
        }

        // POST api/values
        [HttpPut]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
