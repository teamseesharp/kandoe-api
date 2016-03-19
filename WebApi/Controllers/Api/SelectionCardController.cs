﻿using System;
using System.Collections.Generic;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/selection-cards")]
    public class SelectionCardController : ApiController {
        private readonly IService<SelectionCard> service;

        public SelectionCardController() {
            this.service = new SelectionCardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<SelectionCard> entities = this.service.Get();
            IEnumerable<SelectionCardDto> dtos = ModelMapper.Map<IEnumerable<SelectionCard>, IEnumerable<SelectionCardDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            SelectionCard entity = this.service.Get(id);
            SelectionCardDto dto = ModelMapper.Map<SelectionCardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]SelectionCardDto dto) {
            SelectionCard entity = ModelMapper.Map<SelectionCard>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<SelectionCardDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]SelectionCardDto dto) {
            SelectionCard entity = ModelMapper.Map<SelectionCard>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-subtheme/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySubtheme(int id) {
            IEnumerable<SelectionCard> entities = this.service.Get(selectionCard => selectionCard.SubthemeId == id);
            IEnumerable<SelectionCardDto> dtos = ModelMapper.Map<IEnumerable<SelectionCard>, IEnumerable<SelectionCardDto>>(entities);
            return Ok(dtos);
        }
    }
}
