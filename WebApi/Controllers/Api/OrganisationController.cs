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
    [RoutePrefix("api/organisations")]
    public class OrganisationController : ApiController {
        private readonly Service<Organisation> organisationService;
        private readonly Service<Session> sessionService;

        public OrganisationController() {
            this.organisationService = new OrganisationService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Organisation> entities = this.organisationService.Get();
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Organisation entity = this.organisationService.Get(id);
            OrganisationDto dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.organisationService.Add(entity);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.organisationService.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.organisationService.Remove(id);
            return Ok();
        }
    }
}
