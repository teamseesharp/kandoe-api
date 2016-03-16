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
        private readonly IService<Theme> themes;

        public ThemeController() {
            this.themes = new ThemeService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Theme> entities = this.themes.Get();
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Theme entity = this.themes.Get(id);
            ThemeDto dto = ModelMapper.Map<ThemeDto>(entity);
            return Ok(dto);
        }

        [AuthorizeThemeOrganiser]
        [Route("")]
        public IHttpActionResult Post([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
            this.themes.Add(entity);
            dto = ModelMapper.Map<ThemeDto>(entity);
            return Ok(dto);
        }

        [AuthorizeThemeOrganiser]
        [Route("")]
        public IHttpActionResult Put([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
            this.themes.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-user/{id}")]
        [HttpGet]
        public IHttpActionResult GetByUser(int id) {
            IEnumerable<Theme> entities = this.themes.Get(theme => theme.OrganiserId == id);
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganisation(int id) {
            IEnumerable<Theme> entities = this.themes.Get(theme => theme.OrganisationId == id);
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-tag/{tag}")]
        [HttpGet]
        public IHttpActionResult GetByTag(string tag) {
            IEnumerable<Theme> entities = this.themes.Get(theme => theme.Tags.Contains(tag));
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/themes/by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerboseByOrganisation(int id)
        {
            IEnumerable<Theme> entities = this.themes.Get(theme => theme.OrganisationId == id, collections:true);
            IEnumerable<ThemeDto> dtos = ModelMapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDto>>(entities);
            return Ok(dtos);
        }
    }
}
