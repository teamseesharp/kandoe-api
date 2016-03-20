using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/sessions")]
    public class SessionController : ApiController {
        private readonly IService<Account> accounts;
        private readonly IService<SelectionCard> selectionCards;
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
            IEnumerable<Session> entities = this.sessions.Get(collections: false);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Session entity = this.sessions.Get(id, collections: false);
            SessionDto dto = ModelMapper.Map<SessionDto>(entity);
            return Ok(dto);
        }

        [AuthorizeOrganiser]
        [Route("")]
        public IHttpActionResult Post([FromBody]SessionDto dto) {
            Session entity = ModelMapper.Map<Session>(dto);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account organiser = this.accounts.Get(a => a.Secret == secret, collections: true).First();

            entity.Organisers.Add(organiser);
            organiser.OrganisedSessions.Add(entity);

            this.sessions.Add(entity);
            this.accounts.Change(organiser);

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

        [Route("by-subtheme/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySubtheme(int id) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.SubthemeId == id, collections: false);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-user/{id}")]
        [HttpGet]
        public IHttpActionResult GetByUser(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> invitedSessions = this.sessions.Get(session => session.Invitees.Contains(account), collections: false);
            IEnumerable<Session> participatingSessions = this.sessions.Get(session => session.Participants.Contains(account), collections: false);
            IEnumerable<Session> entities = invitedSessions.Concat(participatingSessions).Distinct();
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-user/{id}/finished")]
        [HttpGet]
        public IHttpActionResult GetByUserAndFinished(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> entities = this.sessions.Get(
                session => session.Participants.Contains(account),
                session => session.IsFinished,
                collections: true
            );
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-user/{id}/ongoing")]
        [HttpGet]
        public IHttpActionResult GetByUserByAndOngoing(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> entities = this.sessions.Get(
                session => session.Participants.Contains(account),
                session => !session.IsFinished,
                session => session.Start < DateTime.Now,
                collections: true
            );
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-user/{id}/planned")]
        [HttpGet]
        public IHttpActionResult GetByUserAndPlanned(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> entities = this.sessions.Get(
                session => session.Participants.Contains(account),
                session => !session.IsFinished,
                session => session.Start > DateTime.Now,
                collections: true
            );
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-start-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByStartDate(DateTime date) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.Start.Date == date.Date, collections: false);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("by-end-date/{date}")]
        [HttpGet]
        public IHttpActionResult GetByEndDate(DateTime date) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.End.Date == date.Date, collections: false);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}/snapshot")]
        [HttpGet]
        public IHttpActionResult GetSessionSnapshot(int id) {
            Session session = this.sessions.Get(id, collections: true);
            SessionDto sessionDto = ModelMapper.Map<SessionDto>(session);
            SnapshotDto snapshotDto = ModelMapper.Map<SnapshotDto>(sessionDto);
            return Ok(snapshotDto);
        }

        //[AuthorizeOrganiser]
        [Route("{id}/end")]
        [HttpPatch]
        public IHttpActionResult PatchEnd(int id) {
            Session entity = this.sessions.Get(id, collections: false);

            entity.End = DateTime.Now;
            entity.IsFinished = true;

            this.sessions.Change(entity);

            return Ok();
        }

        //[AuthorizeOrganiser]
        [Route("{id}/invite")]
        [HttpPatch]
        public IHttpActionResult PatchInvite(int id, [FromBody]ICollection<string> emails) {
            Session session = this.sessions.Get(id, collections: true);

            emails = emails.Distinct().ToList();

            foreach (string email in emails) {
                Account account = this.accounts.Get(a => a.Email == email, collections: true).First();

                bool exists = account != null;
                bool isInvited = session.Invitees.Contains(account);

                if (exists && !isInvited) {
                    session.Invitees.Add(account);
                    account.InvitedSessions.Add(session);
                }
            }

            this.sessions.Change(session);

            return Ok();
        }

        //[AuthorizeInvitee]
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

        [AuthorizeInvitee]
        [Route("{id}/select-cards")]
        [HttpPatch]
        // valid cards?
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

        //[AuthorizeParticipant]
        [Route("{sessionId}/level-up-card/{cardId}")]
        [HttpPatch]
        // validation: dat het de huidige speler is
        // mss beter als businesslogica...
        public IHttpActionResult PatchSessionCardLevel(int id, int cardId) {
            Session session = this.sessions.Get(id, collections: true);
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

        [Route("~/api/verbose/sessions/by-organisation/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerboseByOrganisation(int id) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.OrganisationId == id, collections: true);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/sessions/by-subtheme/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerboseBySubtheme(int id) {
            IEnumerable<Session> entities = this.sessions.Get(session => session.SubthemeId == id, collections: true);
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }

        [Route("~/api/verbose/sessions/by-user/{id}")]
        [HttpGet]
        public IHttpActionResult GetVerboseByUser(int id) {
            Account account = this.accounts.Get(id);
            IEnumerable<Session> invitedSessions = this.sessions.Get(session => session.Invitees.Contains(account), collections: true);
            IEnumerable<Session> participatingSessions = this.sessions.Get(session => session.Participants.Contains(account), collections: true);
            IEnumerable<Session> entities = (invitedSessions.Concat(participatingSessions)).Distinct();
            IEnumerable<SessionDto> dtos = ModelMapper.Map<IEnumerable<Session>, IEnumerable<SessionDto>>(entities);
            return Ok(dtos);
        }
    }
}
