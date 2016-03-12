using System;
using System.Collections.Generic;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters.Authorization;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/organisations")]
    public class OrganisationController : ApiController {
        private readonly IService<Account> accounts;
        private readonly IService<Organisation> organisations;

        public OrganisationController() {
            this.accounts = new AccountService();
            this.organisations = new OrganisationService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Organisation> entities = this.organisations.Get(collections: false);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Organisation entity = this.organisations.Get(id, collections: false);
            OrganisationDto dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.organisations.Add(entity);
            dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }

        [OrganisationAuthorize]
        [Route("")]
        public IHttpActionResult Put([FromBody]OrganisationDto dto) {
            Organisation entity = ModelMapper.Map<Organisation>(dto);
            this.organisations.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-organiser/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganiser(int id) {
            IEnumerable<Organisation> entities = this.organisations.Get(o => o.OrganiserId == id);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/organisations")]
        [HttpGet]
        public IHttpActionResult GetVerbose() {
            IEnumerable<Organisation> entities = this.organisations.Get(collections: true);
            IEnumerable<OrganisationDto> dtos = ModelMapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/organisations/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerbose(int id) {
            Organisation entity = this.organisations.Get(id, collections: true);
            OrganisationDto dto = ModelMapper.Map<OrganisationDto>(entity);
            return Ok(dto);
        }
    }
}
