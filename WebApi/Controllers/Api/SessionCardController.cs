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
    [RoutePrefix("api/session-cards")]
    public class SessionCardController : ApiController {
        private readonly IService<SessionCard> service;

        public SessionCardController() {
            this.service = new SessionCardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<SessionCard> entities = this.service.Get();
            IEnumerable<CardDto> dtos = ModelMapper.Map<IEnumerable<SessionCard>, IEnumerable<CardDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            SessionCard entity = this.service.Get(id);
            CardDto dto = ModelMapper.Map<CardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CardDto dto) {
            SessionCard entity = ModelMapper.Map<SessionCard>(dto);
            this.service.Add(entity);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]CardDto dto) {
            SessionCard entity = ModelMapper.Map<SessionCard>(dto);
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
