using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kandoe.Web.Controllers.Api {
    public class CardReviewController : ApiController {
        // GET: api/CardReview
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CardReview/5
        public string Get(int id) {
            return "value";
        }

        // POST: api/CardReview
        public void Post([FromBody]string value) {
        }

        // PUT: api/CardReview/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE: api/CardReview/5
        public void Delete(int id) {
        }
    }
}
