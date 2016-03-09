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
    [RoutePrefix("api/subthemes")]
    public class SubthemeController : ApiController {
        private readonly IService<Subtheme> service;

        public SubthemeController() {
            this.service = new SubthemeService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Subtheme> entities = this.service.Get();
            IEnumerable<SubthemeDto> dtos = ModelMapper.Map<IEnumerable<Subtheme>, IEnumerable<SubthemeDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Subtheme entity = this.service.Get(id);
            SubthemeDto dto = ModelMapper.Map<SubthemeDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]SubthemeDto dto) {
            Subtheme entity = ModelMapper.Map<Subtheme>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<SubthemeDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]SubthemeDto dto) {
            Subtheme entity = ModelMapper.Map<Subtheme>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.service.Remove(id);
            return Ok();
        }

        [Route("by-theme/{id}")]
        public IHttpActionResult GetByTheme(int id) {
            IEnumerable<Subtheme> entities = this.service.Get(subtheme => subtheme.ThemeId == id);
            IEnumerable<SubthemeDto> dtos = ModelMapper.Map<IEnumerable<Subtheme>, IEnumerable<SubthemeDto>>(entities);
            return Ok(dtos);
        }
    }
}
