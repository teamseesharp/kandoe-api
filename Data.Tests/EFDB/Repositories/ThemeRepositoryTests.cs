using System;
using System.Collections.Generic;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class ThemeRepositoryTests {
        private IRepository<Account> accounts;
        private IRepository<Organisation> organisations;
        private IRepository<Theme> themes;

        private Account account;
        private Organisation organisation;
        private Theme theme;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.accounts = new AccountRepository(context);
            this.organisations = new OrganisationRepository(context);
            this.themes = new ThemeRepository(context);

            // all other objects than 'theme' are available thanks to a migration test database seed
            this.account = this.accounts.Read(1);
            this.organisation = this.organisations.Read(1);

            this.theme = new Theme("testname", "descr", this.organisation.Id, this.account.Id, "tags;tag;ta;t");
            this.theme = this.themes.Create(theme);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.themes.Read(this.theme.Id), this.theme);
        }

        [Test]
        public void ShouldReadSingleOrganisationWithCollections() {
            int[] ids = { this.theme.Id, 1 };

            foreach (int id in ids) {
                Theme theme = this.themes.Read(this.theme.Id, eager: true);

                Assert.NotNull(theme.SelectionCards);
                Assert.NotNull(theme.Subthemes);
            }

        }

        [Test]
        public void ShouldReadSingleOrganisationWithoutCollections() {
            int[] ids = { this.theme.Id, 1 };

            foreach (int id in ids) {
                Theme theme = this.themes.Read(this.theme.Id, eager: false);

                Assert.Null(theme.SelectionCards);
                Assert.Null(theme.Subthemes);
            }
        }

        [Test]
        public void ShouldReadWithCollections() {
            IEnumerable<Theme> themes = this.themes.Read(eager: true);

            foreach (Theme theme in themes) {
                Assert.NotNull(theme.SelectionCards);
                Assert.NotNull(theme.Subthemes);
            }
        }

        [Test]
        public void ShouldReadWithoutCollections() {
            IEnumerable<Theme> themes = this.themes.Read(eager: false);

            foreach (Theme theme in themes) {
                Assert.Null(theme.SelectionCards);
                Assert.Null(theme.Subthemes);
            }
        }

        [Test]
        public void ShouldUpdate() {
            this.theme = this.themes.Read(this.theme.Id);

            string name = "new name";
            string tags = "new;tags;yo";

            this.theme.Name = name;
            this.theme.Tags = tags;

            this.themes.Update(theme);
            this.theme = this.themes.Read(this.theme.Id);

            Assert.AreEqual(this.theme.Name, name);
            Assert.AreEqual(this.theme.Tags, tags);
        }

        [Test]
        public void ShouldDelete() {
            Theme theme = new Theme("delname", "deldescr", this.organisation.Id, this.account.Id, "del;de;d");
            theme = this.themes.Create(theme);

            this.themes.Delete(theme.Id);

            theme = this.themes.Read(theme.Id);

            Assert.Null(theme);
        }

        [TearDown]
        public void TearDown() {
            this.themes.Delete(this.theme.Id);
        }
    }
}
