using System;
using System.Collections.Generic;
using System.Web.Http;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;
using Kandoe.Web.Results;

namespace Kandoe.Web.Controllers.Api {
    //[Authorize]
    [RoutePrefix("api/sessions")]
    public class SessionController : ApiController {
        private readonly IService<Account> accountService;
        private readonly IService<Session> sessionService;

        public SessionController() {
            this.accountService = new AccountService();
            this.sessionService = new SessionService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Session> entities = this.sessionService.Get();
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Session entity = this.sessionService.Get(id);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]SessionDto dto) {
            Session entity = ModelMapper.Map<Session>(dto);
            this.sessionService.Add(entity);
            dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]SessionDto dto) {
            Session entity = ModelMapper.Map<Session>(dto);
            this.sessionService.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            this.sessionService.Remove(id);
            return Ok();
        }

        [Route("by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganisation(int id) {
            IEnumerable<Session> entities = this.sessionService.Get(session => session.OrganisationId == id);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-subtheme/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySubtheme(int id) {
            IEnumerable<Session> entities = this.sessionService.Get(session => session.SubthemeId == id);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-start-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByStartDate(DateTime date) {
            IEnumerable<Session> entities = this.sessionService.Get(session => session.Start.Date == date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-end-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByEndDate(DateTime date) {
            IEnumerable<Session> entities = this.sessionService.Get(session => session.End.Date == date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}/join")]
        [HttpPost]
        public IHttpActionResult PostJoin(int id, [FromBody] AccountDto dto) {
            Account account = this.accountService.Get(dto.Id, collections: true);
            Session session = this.sessionService.Get(id, collections: true);

            if (session.Participants.Count >= session.MaxParticipants) {
                return BadRequest();
            }

            session.Participants.Add(account);
            account.ParticipatingSessions.Add(session);

            this.sessionService.Change(session);
            this.accountService.Change(account);

            return Ok();
        }

        [Route("~/api/verbose/sessions/{id}")]
        public IHttpActionResult GetVerbose(int id)
        {
            Session entity = this.sessionService.Get(id, collections: true);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto); 
        }
    }
}
