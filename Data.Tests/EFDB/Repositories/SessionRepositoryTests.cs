using System;
using System.Collections.Generic;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class SessionRepositoryTests {
        private IRepository<Organisation> organisations;
        private IRepository<Session> sessions;
        private IRepository<Subtheme> subthemes;

        private Organisation organisation;
        private Session session;
        private Subtheme subtheme;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.organisations = new OrganisationRepository(context);
            this.sessions = new SessionRepository(context);
            this.subthemes = new SubthemeRepository(context);

            // all other objects than 'session' are available thanks to a migration test database seed
            this.organisation = this.organisations.Read(1);
            this.subtheme = this.subthemes.Read(1);

            this.session = new Session(true, 0, "NUnitMasterRace", false, 10, 10, this.organisation.Id, 1, this.subtheme.Id, DateTime.Now, DateTime.Now.AddDays(2));
            this.session = this.sessions.Create(session);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.sessions.Read(this.session.Id), this.session);
        }

        [Test]
        public void ShouldReadSingleOrganisationWithCollections() {
            int[] ids = { this.session.Id, 1 };

            foreach (int id in ids) {
                Session session = this.sessions.Read(this.session.Id, eager: true);

                Assert.NotNull(session.ChatMessages);
                Assert.NotNull(session.Invitees);
                Assert.NotNull(session.Organisers);
                Assert.NotNull(session.Participants);
                Assert.NotNull(session.SessionCards);
            }

        }

        [Test]
        public void ShouldReadSingleOrganisationWithoutCollections() {
            int[] ids = { this.session.Id, 1 };

            foreach (int id in ids) {
                Session session = this.sessions.Read(this.session.Id, eager: false);

                Assert.Null(session.ChatMessages);
                Assert.Null(session.Invitees);
                Assert.Null(session.Organisers);
                Assert.Null(session.Participants);
                Assert.Null(session.SessionCards);
            }
        }

        [Test]
        public void ShouldReadWithCollections() {
            IEnumerable<Session> sessions = this.sessions.Read(eager: true);

            foreach (Session session in sessions) {
                Assert.NotNull(session.ChatMessages);
                Assert.NotNull(session.Invitees);
                Assert.NotNull(session.Organisers);
                Assert.NotNull(session.Participants);
                Assert.NotNull(session.SessionCards);
            }
        }

        [Test]
        public void ShouldReadWithoutCollections() {
            IEnumerable<Session> sessions = this.sessions.Read(eager: false);

            foreach (Session session in sessions) {
                Assert.Null(session.ChatMessages);
                Assert.Null(session.Invitees);
                Assert.Null(session.Organisers);
                Assert.Null(session.Participants);
                Assert.Null(session.SessionCards);
            }
        }

        [Test]
        public void ShouldUpdate() {
            this.session = this.sessions.Read(this.session.Id);

            bool cardCreationAllowed = false;
            int currentPlayerIndex = 1;
            bool isFinished = true;
            int maxCardsToChoose = 11;
            int maxParticipants = 11;


            this.session.CardCreationAllowed = cardCreationAllowed;
            this.session.CurrentPlayerIndex = currentPlayerIndex;
            this.session.IsFinished = isFinished;
            this.session.MaxCardsToChoose = maxCardsToChoose;
            this.session.MaxParticipants = maxParticipants;

            string unchangedDescription = this.session.Description;
            int unchangedRound = this.session.Round;

            this.sessions.Update(session);
            this.session = this.sessions.Read(this.session.Id);

            Assert.AreEqual(this.session.CardCreationAllowed, cardCreationAllowed);
            Assert.AreEqual(this.session.CurrentPlayerIndex, currentPlayerIndex);
            Assert.AreEqual(this.session.Description, unchangedDescription);
            Assert.AreEqual(this.session.IsFinished, isFinished);
            Assert.AreEqual(this.session.MaxCardsToChoose, maxCardsToChoose);
            Assert.AreEqual(this.session.MaxParticipants, maxParticipants);
            Assert.AreEqual(this.session.Round, unchangedRound);
        }

        [Test]
        public void ShouldDelete() {
            Session session = new Session(true, 0, "new and shiny", false, 10, 10, this.organisation.Id, 1, this.subtheme.Id, DateTime.Now, DateTime.Now.AddDays(1));
            session = this.sessions.Create(session);

            this.sessions.Delete(session.Id);

            session = this.sessions.Read(session.Id);

            Assert.Null(session);
        }

        [TearDown]
        public void TearDown() {
            this.sessions.Delete(this.session.Id);
        }
    }
}
