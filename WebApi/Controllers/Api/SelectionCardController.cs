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
    [RoutePrefix("api/selection-cards")]
    public class SelectionCardController : ApiController {
        private readonly IService<SelectionCard> service;

        public SelectionCardController() {
            this.service = new SelectionCardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<SelectionCard> entities = this.service.Get();
            IEnumerable<CardDto> dtos = ModelMapper.Map<IEnumerable<SelectionCard>, IEnumerable<CardDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            SelectionCard entity = this.service.Get(id);
            CardDto dto = ModelMapper.Map<CardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CardDto dto) {
            SelectionCard entity = ModelMapper.Map<SelectionCard>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<CardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]CardDto dto) {
            SelectionCard entity = ModelMapper.Map<SelectionCard>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.service.Remove(id);
            return Ok();
        }

        [Route("by-subtheme-ID/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySubtheme(int id)
        {
            IEnumerable<SelectionCard> entities = this.service.Get(selectionCard => selectionCard.SubthemeId == id);
            IEnumerable<CardDto> dtos = ModelMapper.Map<IEnumerable<SelectionCard>, IEnumerable<CardDto>>(entities);
            return Ok(dtos);
        }
    }
}
