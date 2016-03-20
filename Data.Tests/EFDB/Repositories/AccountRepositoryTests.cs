using System.Collections.Generic;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class AccountRepositoryTests {
        private IRepository<Account> accounts;
        private Account account;

        [SetUp]
        public void SetUp() {
            this.account = new Account("testemail", "testname", "testsurname", "testpicture", "testsecret");
            this.accounts = new AccountRepository(new FakeContext());
            this.account = this.accounts.Create(account);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.accounts.Read(this.account.Id), this.account);
        }

        [Test]
        public void ShouldReadSingleAccountWithCollections() {
            int[] ids = { this.account.Id, 1 };

            foreach (int id in ids) {
                Account account = this.accounts.Read(id, eager: true);

                Assert.NotNull(account.ChatMessages);
                Assert.NotNull(account.InvitedSessions);
                Assert.NotNull(account.Organisations);
                Assert.NotNull(account.OrganisedSessions);
                Assert.NotNull(account.ParticipatingSessions);
                Assert.NotNull(account.Subthemes);
                Assert.NotNull(account.Themes);
            }
        }

        [Test]
        public void ShouldReadSingleAccountWithoutCollections() {
            int[] ids = { this.account.Id, 1 };

            foreach (int id in ids) {
                Account account = this.accounts.Read(id, eager: false);

                Assert.Null(account.ChatMessages);
                Assert.Null(account.InvitedSessions);
                Assert.Null(account.Organisations);
                Assert.Null(account.OrganisedSessions);
                Assert.Null(account.ParticipatingSessions);
                Assert.Null(account.Subthemes);
                Assert.Null(account.Themes);
            }
        }

        [Test]
        public void ShouldReadWithCollections() {
            IEnumerable<Account> accounts = this.accounts.Read(eager: true);

            foreach (Account account in accounts) {
                Assert.NotNull(account.ChatMessages);
                Assert.NotNull(account.InvitedSessions);
                Assert.NotNull(account.Organisations);
                Assert.NotNull(account.OrganisedSessions);
                Assert.NotNull(account.ParticipatingSessions);
                Assert.NotNull(account.Subthemes);
                Assert.NotNull(account.Themes);
            }
        }

        [Test]
        public void ShouldReadWithoutCollections() {
            IEnumerable<Account> accounts = this.accounts.Read(eager: false);

            foreach (Account account in accounts) {
                Assert.Null(account.ChatMessages);
                Assert.Null(account.InvitedSessions);
                Assert.Null(account.Organisations);
                Assert.Null(account.OrganisedSessions);
                Assert.Null(account.ParticipatingSessions);
                Assert.Null(account.Subthemes);
                Assert.Null(account.Themes);
            }
        }

        [Test]
        public void ShouldUpdate() {
            this.account = this.accounts.Read(this.account.Id);

            string name = "changedname";
            string picture = "changedpicture";
            string surname = "changedsurname";

            this.account.Name = name;
            this.account.Picture = picture;
            this.account.Surname = surname;

            string unchangedEmail = this.account.Email;

            this.accounts.Update(account);
            this.account = this.accounts.Read(this.account.Id);

            Assert.AreEqual(this.account.Name, name);
            Assert.AreEqual(this.account.Picture, picture);
            Assert.AreEqual(this.account.Surname, surname);
            Assert.AreEqual(this.account.Email, unchangedEmail);
        }

        [Test]
        public void ShouldDelete() {
            Account account = new Account("delete@delete.com", "del", "del", "del", "del");
            account = this.accounts.Create(account);

            this.accounts.Delete(account.Id);

            account = this.accounts.Read(account.Id);

            Assert.Null(account);
        }

        [TearDown]
        public void TearDown() {
            this.accounts.Delete(this.account.Id);
        }
    }
}
