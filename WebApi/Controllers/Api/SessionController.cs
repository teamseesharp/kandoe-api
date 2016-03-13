using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly SelectionCardService selectionCardService;
        private readonly IService<Session> sessionService;
        private readonly IService<SessionCard> sessionCardService;

        public SessionController() {
            this.accountService = new AccountService();
            this.selectionCardService = new SelectionCardService();
            this.sessionService = new SessionService();
            this.sessionCardService = new SessionCardService();
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
        // also update the organiser! will receive it in dto.Organisers.first()
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
            throw new NotSupportedException();
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
            IEnumerable<Session> entities = this.sessionService.Get(session => session.Start.Date == date.Date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-end-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByEndDate(DateTime date) {
            IEnumerable<Session> entities = this.sessionService.Get(session => session.End.Date == date.Date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}/end")]
        [HttpPatch]
        // auth organiser
        public IHttpActionResult PatchEnd(int id) {
            Session entity = this.sessionService.Get(id);

            entity.End = DateTime.Now;
            entity.IsFinished = true;

            this.sessionService.Change(entity);

            return Ok();
        }

        [Route("{id}/join")]
        [HttpPatch]
        public IHttpActionResult PatchJoin(int id, [FromBody] AccountDto dto) {
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

        [Route("{id}/select-cards")]
        [HttpPatch]
        public IHttpActionResult PatchSelectCards(int id, [FromBody]ICollection<CardDto> dtos) {
            IEnumerable<SessionCard> sessionCards = this.sessionCardService.Get(sc => sc.SessionId == id);

            foreach (CardDto dto in dtos) {
                SelectionCard slc = this.selectionCardService.Get(dto.Id);

                if (!sessionCards.Any(sc => sc.Text == slc.Text)) {
                    SessionCard sc = new SessionCard(slc.Image, id, slc.Text);
                    this.sessionCardService.Add(sc);
                }
            }

            return Ok();
        }

        [Route("{sessionId}/level-up-card/{cardId}")]
        [HttpPatch]
        // auth: checken of de call van een participant komt
        public IHttpActionResult PatchSessionCardLevel(int sessionId, int cardId) {
            Session session = this.sessionService.Get(sessionId, collections: true);
            SessionCard sessionCard = this.sessionCardService.Get(cardId);

            int index = session.CurrentPlayerIndex;
            int participantsAmount = session.Participants.Count;

            --sessionCard.SessionLevel;
            session.CurrentPlayerIndex = ((index + 1) % participantsAmount == 0) ? 0 : index + 1;

            this.sessionService.Change(session);
            this.sessionCardService.Change(sessionCard);

            return Ok();
        }


        /*(route("~/api/verbose/sessions")]
        [HttpGet]
        public IHttpActionResult GetVerbose() {
            IEnumerable<Session> entities = this.sessionService.Get(collections: true);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);

            foreach (SessionDto dto in dtos) {
                foreach (AccountDto participant in dto.Participants) {
                    participant.OrganisedSessions = null;
                    participant.ParticipatingSessions = null;
                }

                foreach (AccountDto organiser in dto.Organisers) {
                    organiser.OrganisedSessions = null;
                    organiser.ParticipatingSessions = null;
                }
            }

            return Ok(dtos);
        }//
        */

        [Route("~/api/verbose/sessions/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerbose(int id) {
            Session entity = this.sessionService.Get(id, collections: true);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);

            foreach (AccountDto participant in dto.Participants) {
                participant.OrganisedSessions = null;
                participant.ParticipatingSessions = null;
            }

            foreach (AccountDto organiser in dto.Organisers) {
                organiser.OrganisedSessions = null;
                organiser.ParticipatingSessions = null;
            }

            return Ok(dto); 
        }
    }
}
