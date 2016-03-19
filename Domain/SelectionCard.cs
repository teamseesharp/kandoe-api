namespace Kandoe.Business.Domain {
    public class SelectionCard : Entity {
        protected SelectionCard() { }

        public SelectionCard(string image, string text, int themeId, int? subthemeId = null) {
            this.Image = image;
            this.SubthemeId = subthemeId;
            this.Text = text;
            this.ThemeId = themeId;
        }

        public string Image { get;  set; }
        public string Text { get; set; }
        public int ThemeId { get; set; }

        public int? SubthemeId { get; protected set; }
    }
}
