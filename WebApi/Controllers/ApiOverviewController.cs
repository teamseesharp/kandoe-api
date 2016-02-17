using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kandoe.Web.Api.Controllers {
    public class ApiOverviewController : ApiController {
        // GET: api/ApiOverview
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApiOverview/5
        public string Get(int id) { return "value"; }

        // POST: api/ApiOverview
        public void Post([FromBody]string value) { }

        // PUT: api/ApiOverview/5
        public void Put(int id, [FromBody]string value) { }

        // DELETE: api/ApiOverview/5
        public void Delete(int id) { }
    }
}
