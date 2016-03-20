using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class SessionCardRepositoryTests {
        private IRepository<Session> sessions;
        private IRepository<SessionCard> sessioncards;

        private Session session;
        private SessionCard sessioncard;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.sessions = new SessionRepository(context);
            this.sessioncards = new SessionCardRepository(context);

            // all other objects than 'sessioncard' are available thanks to a migration test database seed
            this.session = this.sessions.Read(1);

            this.sessioncard = new SessionCard("testimage", this.session.Id, "some text");
            this.sessioncard = this.sessioncards.Create(sessioncard);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.sessioncards.Read(this.sessioncard.Id), this.sessioncard);
        }

        [Test]
        public void ShouldUpdate() {
            this.sessioncard = this.sessioncards.Read(this.sessioncard.Id);

            string image = "changedimage";
            string text = "changedtext";

            this.sessioncard.Image = image;
            this.sessioncard.Text = text;

            this.sessioncards.Update(sessioncard);
            this.sessioncard = this.sessioncards.Read(this.sessioncard.Id);

            Assert.AreEqual(this.sessioncard.Image, image);
            Assert.AreEqual(this.sessioncard.Text, text);
        }

        [Test]
        public void ShouldDelete() {
            SessionCard sessioncard = new SessionCard("new testimage", this.session.Id, "some more text");
            sessioncard = this.sessioncards.Create(sessioncard);

            this.sessioncards.Delete(sessioncard.Id);

            sessioncard = this.sessioncards.Read(sessioncard.Id);

            Assert.Null(sessioncard);
        }

        [TearDown]
        public void TearDown() {
            this.sessioncards.Delete(this.sessioncard.Id);
        }
    }
}
