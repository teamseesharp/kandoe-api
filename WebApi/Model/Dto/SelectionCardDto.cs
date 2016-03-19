namespace Kandoe.Web.Model.Dto {
    public class SelectionCardDto {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public int ThemeId { get; set; }
        public int? SubthemeId { get; set; }
    }
}