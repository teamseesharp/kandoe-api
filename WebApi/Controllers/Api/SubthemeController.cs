using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kandoe.Web.Controllers.Api {
    public class SubthemeController : ApiController {
        // GET: api/Subtheme
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subtheme/5
        public string Get(int id) {
            return "value";
        }

        // POST: api/Subtheme
        public void Post([FromBody]string value) {
        }

        // PUT: api/Subtheme/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE: api/Subtheme/5
        public void Delete(int id) {
        }
    }
}
