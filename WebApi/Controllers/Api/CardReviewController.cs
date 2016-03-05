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

namespace Kandoe.Web.Controllers.Api {
    [Authorize]
    [RoutePrefix("api/card-reviews")]
    public class CardReviewController : ApiController {
        private readonly IService<CardReview> service;

        public CardReviewController() {
            this.service = new CardReviewService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<CardReview> entities = this.service.Get();
            IEnumerable<CardReviewDto> dtos = ModelMapper.Map<IEnumerable<CardReview>, IEnumerable<CardReviewDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            CardReview entity = this.service.Get(id);
            CardReviewDto dto = ModelMapper.Map<CardReviewDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CardReviewDto dto) {
            CardReview entity = ModelMapper.Map<CardReview>(dto);
            this.service.Add(entity);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]CardReviewDto dto) {
            CardReview entity = ModelMapper.Map<CardReview>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.service.Remove(id);
            return Ok();
        }

        [Route("by-card/{id}")]
        [HttpGet]
        public IHttpActionResult GetByCard(int id) {
            IEnumerable<CardReview> entities = this.service.Get(cr => cr.CardId == id);
            IEnumerable<CardReviewDto> dtos = ModelMapper.Map<IEnumerable<CardReview>, IEnumerable<CardReviewDto>>(entities);
            return Ok(dtos);
        }
    }
}
