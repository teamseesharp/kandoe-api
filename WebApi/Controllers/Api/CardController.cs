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
    [Authorize]
    [RoutePrefix("api/card")]
    public class CardController : ApiController {
        private readonly Service<Card> service;

        public CardController() {
            this.service = new CardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Card> entities = this.service.Get();
            IEnumerable<CardDto> dtos = ModelMapper.Map<IEnumerable<Card>, IEnumerable<CardDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Card entity = this.service.Get(id);
            CardDto dto = ModelMapper.Map<CardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CardDto dto) {
            Card entity = ModelMapper.Map<Card>(dto);
            this.service.Add(entity);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]CardDto dto) {
            Card entity = ModelMapper.Map<Card>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.service.Remove(id);
            return Ok();
        }
    }
}
