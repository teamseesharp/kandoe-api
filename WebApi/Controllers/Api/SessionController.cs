using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters.Authorization;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/sessions")]
    public class SessionController : ApiController {
        private readonly IService<Account> accounts;
        private readonly SelectionCardService selectionCards;
        private readonly IService<Session> sessions;
        private readonly IService<SessionCard> sessionCards;

        public SessionController() {
            this.accounts = new AccountService();
            this.selectionCards = new SelectionCardService();
            this.sessions = new SessionService();
            this.sessionCards = new SessionCardService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Session> entities = this.sessions.Get();
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Session entity = this.sessions.Get(id);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto);
        }

        [AuthorizeOrganiser]
        [Route("")]
        public IHttpActionResult Post([FromBody]SessionDto dto) {
            Session entity = ModelMapper.Map<Session>(dto);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account organiser = this.accounts.Get(a => a.Secret == secret, collections: true).First();

            organiser.OrganisedSessions.Add(entity);
            entity.Organisers = new List<Account>();
            entity.Organisers.Add(organiser);

            this.accounts.Change(organiser);
            this.sessions.Add(entity);

            dto = ModelMapper.Map<SessionDto>(entity);

            return Ok(dto);
        }

        [AuthorizeOrganiser]
        [Route("")]
        public IHttpActionResult Put([FromBody]SessionDto dto) {
            Session entity = ModelMapper.Map<Session>(dto);
            this.sessions.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetByOrganisation(int id) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.OrganisationId == id);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-subtheme/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySubtheme(int id) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.SubthemeId == id);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-user/{id}")]
        [HttpGet]
        public IHttpActionResult GetByUser(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> entities = this.sessions.Get(session => session.Participants.Contains(account), collections: true);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-start-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByStartDate(DateTime date) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.Start.Date == date.Date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-end-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByEndDate(DateTime date) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.End.Date == date.Date);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}/end")]
        [HttpPatch]
        // auth organiser
        public IHttpActionResult PatchEnd(int id) {
            Session entity = this.sessions.Get(id);

            entity.End = DateTime.Now;
            entity.IsFinished = true;

            this.sessions.Change(entity);

            return Ok();
        }

        [Route("{id}/join")]
        [HttpPatch]
        // see if already joined?..
        public IHttpActionResult PatchJoin(int id) {
            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account account = this.accounts.Get(a => a.Secret == secret, collections: true).First();
            Session session = this.sessions.Get(id, collections: true);

            if (session.Participants.Count >= session.MaxParticipants) {
                return BadRequest();
            }

            session.Participants.Add(account);
            account.ParticipatingSessions.Add(session);

            this.sessions.Change(session);
            this.accounts.Change(account);

            return Ok();
        }

        [Route("{id}/select-cards")]
        [HttpPatch]
        public IHttpActionResult PatchSelectCards(int id, [FromBody]ICollection<CardDto> dtos) {
            IEnumerable<SessionCard> sessionCards = this.sessionCards.Get(sc => sc.SessionId == id);

            foreach (CardDto dto in dtos) {
                SelectionCard slc = this.selectionCards.Get(dto.Id);

                if (!sessionCards.Any(sc => sc.Text == slc.Text)) {
                    SessionCard sc = new SessionCard(slc.Image, id, slc.Text);
                    this.sessionCards.Add(sc);
                }
            }

            return Ok();
        }

        [Route("{sessionId}/level-up-card/{cardId}")]
        [HttpPatch]
        // auth: checken of de call van een participant komt en dat het de huidige speler is
        public IHttpActionResult PatchSessionCardLevel(int sessionId, int cardId) {
            Session session = this.sessions.Get(sessionId, collections: true);
            SessionCard sessionCard = this.sessionCards.Get(cardId);

            int index = session.CurrentPlayerIndex;
            int participantsAmount = session.Participants.Count;

            --sessionCard.SessionLevel;
            session.CurrentPlayerIndex = ((index + 1) % participantsAmount == 0) ? 0 : index + 1;

            this.sessions.Change(session);
            this.sessionCards.Change(sessionCard);

            return Ok();
        }

        [Route("~/api/verbose/sessions/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerbose(int id) {
            Session entity = this.sessions.Get(id, collections: true);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto); 
        }
    }
}
