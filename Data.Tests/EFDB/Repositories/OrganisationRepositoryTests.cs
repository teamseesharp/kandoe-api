using System.Collections.Generic;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class OrganisationRepositoryTests {
        private IRepository<Account> accounts;
        private IRepository<Organisation> organisations;

        private Account account;
        private Organisation organisation;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.accounts = new AccountRepository(context);
            this.organisations = new OrganisationRepository(context);

            // all other objects than 'organisation' are available thanks to a migration test database seed
            this.account = this.accounts.Read(1);

            this.organisation = new Organisation("NUnitMasterRace", this.account.Id);
            this.organisation = this.organisations.Create(organisation);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.organisations.Read(this.organisation.Id), this.organisation);
        }

        [Test]
        public void ShouldReadSingleAccountWithCollections() {
            int[] ids = { this.organisation.Id, 1 };

            foreach (int id in ids) {
                Organisation organisation = this.organisations.Read(this.organisation.Id, eager: true);

                Assert.NotNull(organisation.Sessions);
                Assert.NotNull(organisation.Themes);
            }

        }

        [Test]
        public void ShouldReadSingleAccountWithoutCollections() {
            int[] ids = { this.organisation.Id, 1 };

            foreach (int id in ids) {
                Organisation organisation = this.organisations.Read(this.organisation.Id, eager: false);

                Assert.Null(organisation.Sessions);
                Assert.Null(organisation.Themes);
            }
        }

        [Test]
        public void ShouldReadWithCollections() {
            IEnumerable<Organisation> organisations = this.organisations.Read(eager: true);

            foreach (Organisation organisation in organisations) {
                Assert.NotNull(organisation.Sessions);
                Assert.NotNull(organisation.Themes);
            }
        }

        [Test]
        public void ShouldReadWithoutCollections() {
            IEnumerable<Organisation> organisations = this.organisations.Read(eager: false);

            foreach (Organisation organisation in organisations) {
                Assert.Null(organisation.Sessions);
                Assert.Null(organisation.Themes);
            }
        }

        [Test]
        public void ShouldUpdate() {
            this.organisation = this.organisations.Read(this.organisation.Id);

            string name = "changedname";

            this.organisation.Name = name;

            this.organisations.Update(organisation);
            this.organisation = this.organisations.Read(this.organisation.Id);

            Assert.AreEqual(this.organisation.Name, name);
        }

        [Test]
        public void ShouldDelete() {
            Organisation organisation = new Organisation("new and shiny", this.account.Id);
            organisation = this.organisations.Create(organisation);

            this.organisations.Delete(organisation.Id);

            organisation = this.organisations.Read(organisation.Id);

            Assert.Null(organisation);
        }

        [TearDown]
        public void TearDown() {
            this.organisations.Delete(this.organisation.Id);
        }
    }
}
