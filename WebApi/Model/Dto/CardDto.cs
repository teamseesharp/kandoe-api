namespace Kandoe.Web.Model.Dto {
    public class CardDto {
        public int Id { get; set; }

        public int SessionId { get; set; }
        public int SessionLevel { get; set; }

        public string Image { get; set; }
        public string Text { get; set; }

        public int ThemeId { get; set; }
        public int? SubthemeId { get; set; }
    }
}