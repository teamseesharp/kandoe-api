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
    [RoutePrefix("api/themes")]
    public class ThemeController : ApiController {
        private readonly Service<Theme> service;

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

        [Route("")]
        public IHttpActionResult Post([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
            this.service.Add(entity);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]ThemeDto dto) {
            Theme entity = ModelMapper.Map<Theme>(dto);
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
