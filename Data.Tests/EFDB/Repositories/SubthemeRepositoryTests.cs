using System.Collections.Generic;

using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class SubthemeRepositoryTests {
        private IRepository<Organisation> organisations;
        private IRepository<Subtheme> subthemes;
        private IRepository<Theme> themes;

        private Organisation organisation;
        private Subtheme subtheme;
        private Theme theme;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.organisations = new OrganisationRepository(context);
            this.subthemes = new SubthemeRepository(context);
            this.themes = new ThemeRepository(context);

            // all other objects than 'subtheme' are available thanks to a migration test database seed
            this.organisation = this.organisations.Read(1);
            this.theme = this.themes.Read(1);

            this.subtheme = new Subtheme("NUnitMasterRace", this.organisation.Id, this.theme.Id);
            this.subtheme = this.subthemes.Create(subtheme);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.subthemes.Read(this.subtheme.Id), this.subtheme);
        }

        [Test]
        public void ShouldReadSingleOrganisationWithCollections() {
            int[] ids = { this.subtheme.Id, 1 };

            foreach (int id in ids) {
                Subtheme subtheme = this.subthemes.Read(this.subtheme.Id, eager: true);

                Assert.NotNull(subtheme.SelectionCards);
                Assert.NotNull(subtheme.Sessions);
            }

        }

        [Test]
        public void ShouldReadSingleOrganisationWithoutCollections() {
            int[] ids = { this.subtheme.Id, 1 };

            foreach (int id in ids) {
                Subtheme subtheme = this.subthemes.Read(this.subtheme.Id, eager: false);

                Assert.Null(subtheme.SelectionCards);
                Assert.Null(subtheme.Sessions);
            }
        }

        [Test]
        public void ShouldReadWithCollections() {
            IEnumerable<Subtheme> subthemes = this.subthemes.Read(eager: true);

            foreach (Subtheme subtheme in subthemes) {
                Assert.NotNull(subtheme.SelectionCards);
                Assert.NotNull(subtheme.Sessions);
            }
        }

        [Test]
        public void ShouldReadWithoutCollections() {
            IEnumerable<Subtheme> subthemes = this.subthemes.Read(eager: false);

            foreach (Subtheme subtheme in subthemes) {
                Assert.Null(subtheme.SelectionCards);
                Assert.Null(subtheme.Sessions);
            }
        }

        [Test]
        public void ShouldUpdate() {
            this.subtheme = this.subthemes.Read(this.subtheme.Id);

            string name = "updatedname";

            this.subtheme.Name = name;

            this.subthemes.Update(subtheme);
            this.subtheme = this.subthemes.Read(this.subtheme.Id);

            Assert.AreEqual(this.subtheme.Name, name);
        }

        [Test]
        public void ShouldDelete() {
            Subtheme subtheme = new Subtheme("shouldbedeleted", this.organisation.Id, this.theme.Id);
            subtheme = this.subthemes.Create(subtheme);

            this.subthemes.Delete(subtheme.Id);

            subtheme = this.subthemes.Read(subtheme.Id);

            Assert.Null(subtheme);
        }

        [TearDown]
        public void TearDown() {
            this.subthemes.Delete(this.subtheme.Id);
        }
    }
}
