namespace BlazorApp.Models
{
    public class CardData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? LinkRout {  get; set; }
        public string? LinkText { get; set; }
        public string? ImgSrc { get; set; }

        public CardData(string title, string? descr = null, string? linkRout = null, string? linkText = null, string? ImgSrc = null)
        {
            this.Id = $"card-{Guid.NewGuid().ToString()}";
            this.Title = title;
            this.Description = descr;
            this.LinkRout = linkRout;
            this.LinkText = linkText;
            this.ImgSrc = ImgSrc;
        }
    }
}
