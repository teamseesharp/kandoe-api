using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;
using Kandoe.Web.Results;

namespace Kandoe.Web.Controllers.Api {
    [RoutePrefix("api/card")]
    public class CardController : ApiController {
        private readonly Service<Card> service;

        public CardController() {
            this.service = new CardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Card> cards = this.service.Get();
            ModelMapper.Map<CardDto>(cards);
            return Ok();
        }

        [Route("{id}")]
        public string Get(int id) {
            return "value";
        }

        [Route("")]
        public void Post([FromBody]string value) {
        }

        [Route("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        [Route("{id}")]
        public void Delete(int id) {
        }
    }
}
