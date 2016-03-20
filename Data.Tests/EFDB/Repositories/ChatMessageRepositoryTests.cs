using System;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class ChatMessageRepositoryTests {
        private IRepository<Account> accounts;
        private IRepository<ChatMessage> messages;
        private IRepository<Session> sessions;

        private Account account;
        private ChatMessage message;
        private Session session;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.accounts = new AccountRepository(context);
            this.messages = new ChatMessageRepository(context);
            this.sessions = new SessionRepository(context);

            // all other objects than 'message' are available thanks to a migration test database seed
            this.account = this.accounts.Read(1);
            this.session = this.sessions.Read(1);

            this.message = new ChatMessage(account.Id, session.Id, "some message", DateTime.Now);
            this.message = this.messages.Create(message);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.messages.Read(this.message.Id), this.message);
        }

        [Test]
        public void ShouldUpdate() {
            this.message = this.messages.Read(this.message.Id);

            string text = "more text!";

            this.message.Text = text;

            this.messages.Update(message);
            this.message = this.messages.Read(this.message.Id);

            Assert.AreEqual(this.message.Text, text);
        }

        [Test]
        public void ShouldDelete() {
            ChatMessage message = new ChatMessage(this.account.Id, this.session.Id, "some other message", DateTime.Now);
            message = this.messages.Create(message);

            this.messages.Delete(message.Id);

            message = this.messages.Read(message.Id);

            Assert.Null(message);
        }

        [TearDown]
        public void TearDown() {
            this.messages.Delete(this.message.Id);
        }
    }
}
