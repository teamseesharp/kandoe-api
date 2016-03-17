using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/chat-messages")]
    public class ChatMessageController : ApiController {
        private readonly IService<ChatMessage> service;

        public ChatMessageController() {
            this.service = new ChatMessageService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            throw new NotSupportedException();
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            ChatMessage entity = this.service.Get(id);
            ChatMessageDto dto = ModelMapper.Map<ChatMessageDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]ChatMessageDto dto) {
            dto.Timestamp = dto.Timestamp ?? DateTime.Now;

            ChatMessage entity = ModelMapper.Map<ChatMessage>(dto);

            this.service.Add(entity);
            dto = ModelMapper.Map<ChatMessageDto>(entity);

            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]ChatMessageDto dto) {
            ChatMessage entity = ModelMapper.Map<ChatMessage>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-session/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySession(int id) {
            IEnumerable<ChatMessage> entities = this.service.Get(cm => cm.SessionId == id);
            IEnumerable<ChatMessageDto> dtos = ModelMapper.Map<IEnumerable<ChatMessage>, IEnumerable<ChatMessageDto>>(entities);
            return Ok(dtos);
        }
    }
}
