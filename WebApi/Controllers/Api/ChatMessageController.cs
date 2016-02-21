using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kandoe.Web.Controllers.Api {
    public class ChatMessageController : ApiController {
        // GET: api/ChatMessage
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ChatMessage/5
        public string Get(int id) {
            return "value";
        }

        // POST: api/ChatMessage
        public void Post([FromBody]string value) {
        }

        // PUT: api/ChatMessage/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE: api/ChatMessage/5
        public void Delete(int id) {
        }
    }
}
