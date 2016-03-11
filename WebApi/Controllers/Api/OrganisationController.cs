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
    //[Authorize]
    [RoutePrefix("api/organisations")]
    public class OrganisationController : ApiController {
        private readonly IService<Organisation> service;

        public OrganisationController() {
            this.service = new OrganisationService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Organisation> entities = this.service.Get(collections: false);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Organisation entity = this.service.Get(id, collections: false);
            OrganisationDto dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.service.Remove(id);
            return Ok();
        }

        [Route("by-organiser/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganiser(int id) {
            IEnumerable<Organisation> entities = this.service.Get(o => o.OrganiserId == id);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/organisations")]
        [HttpGet]
        public IHttpActionResult GetVerbose() {
            IEnumerable<Organisation> entities = this.service.Get(collections: true);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/organisations/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerbose(int id) {
            Organisation entity = this.service.Get(id, collections: true);
            OrganisationDto dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }
    }
}
