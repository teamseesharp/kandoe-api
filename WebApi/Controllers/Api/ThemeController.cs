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
    [RoutePrefix("api/themes")]
    public class ThemeController : ApiController {
        private readonly IService<Theme> service;

        public ThemeController() {
            this.service = new ThemeService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Theme> entities = this.service.Get();
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Theme entity = this.service.Get(id);
            ThemeDto dto = ModelMapper.Map<ThemeDto>(entity);
            return Ok(dto);
        }

        [ThemeAuthorize]
        [Route("")]
        public IHttpActionResult Post([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<ThemeDto>(entity);
            return Ok(dto);
        }

        [ThemeAuthorize]
        [Route("")]
        public IHttpActionResult Put([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganisation(int id) {
            IEnumerable<Theme> entities = this.service.Get(theme => theme.OrganisationId == id);
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-tag/{tag}")]
        [HttpGet]
        public IHttpActionResult GetByTag(string tag) {
            IEnumerable<Theme> entities = this.service.Get(theme => theme.Tags.Contains(tag));
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }
    }
}
