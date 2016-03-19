using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class AccountRepositoryTests {
        private IRepository<Account> accounts;
        private Account account;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            this.account = new Account("testemail", "testname", "testsurname", "testpicture", "testsecret");
        }

        [SetUp]
        public void SetUp() {
            ContextFactory.Refresh(new FakeContext());
            accounts = new AccountRepository(ContextFactory.GetContext());
            this.account = this.accounts.Create(account);
        }

        [Test]
        public void ShouldAddAndReadEntity() {
            Assert.AreEqual(this.accounts.Read(this.account.Id), this.account);
        }

        [Test]
        public void ShouldReadWithCollections() {
            ICollection<Account> eagerLoadedAccounts = this.accounts.Read(eager: true).ToList();

            foreach (Account account in eagerLoadedAccounts) {
                Assert.NotNull(account.ChatMessages);
                Assert.NotNull(account.InvitedSessions);
                Assert.NotNull(account.Organisations);
                Assert.NotNull(account.OrganisedSessions);
                Assert.NotNull(account.ParticipatingSessions);
                Assert.NotNull(account.Subthemes);
                Assert.NotNull(account.Themes);
            }
        }
    }
}
