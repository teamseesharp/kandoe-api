using NUnit.Framework;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;
using Kandoe.Data.Tests.Fakes;

namespace Kandoe.Data.Tests.EFDB.Repositories {
    [TestFixture]
    public class SelectionCardRepositoryTests {
        private IRepository<Theme> themes;
        private IRepository<SelectionCard> selectioncards;

        private Theme theme;
        private SelectionCard selectioncard;

        [SetUp]
        public void SetUp() {
            FakeContext context = new FakeContext();

            this.themes = new ThemeRepository(context);
            this.selectioncards = new SelectionCardRepository(context);

            // all other objects than 'selectioncard' are available thanks to a migration test database seed
            this.theme = this.themes.Read(1);

            this.selectioncard = new SelectionCard("testimage", "some text", this.theme.Id);
            this.selectioncard = this.selectioncards.Create(selectioncard);
        }

        [Test]
        public void ShouldCreateAndReadEntity() {
            Assert.AreEqual(this.selectioncards.Read(this.selectioncard.Id), this.selectioncard);
        }

        [Test]
        public void ShouldUpdate() {
            this.selectioncard = this.selectioncards.Read(this.selectioncard.Id);

            string image = "changedimage";
            string text = "changedtext";

            this.selectioncard.Image = image;
            this.selectioncard.Text = text;

            this.selectioncards.Update(selectioncard);
            this.selectioncard = this.selectioncards.Read(this.selectioncard.Id);

            Assert.AreEqual(this.selectioncard.Image, image);
            Assert.AreEqual(this.selectioncard.Text, text);
        }

        [Test]
        public void ShouldDelete() {
            SelectionCard selectioncard = new SelectionCard("new testimage", "some more text", this.theme.Id);
            selectioncard = this.selectioncards.Create(selectioncard);

            this.selectioncards.Delete(selectioncard.Id);

            selectioncard = this.selectioncards.Read(selectioncard.Id);

            Assert.Null(selectioncard);
        }

        [TearDown]
        public void TearDown() {
            this.selectioncards.Delete(this.selectioncard.Id);
        }
    }
}
