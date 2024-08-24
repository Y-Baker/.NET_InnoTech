namespace BlazorApp.Models
{
    public class AccordionData
    {
        public string Id { get; set; }
        public List<AccordionItem> Items { get; set; }
        public bool AlwaysOpen { get; set; }

        public AccordionData(List<AccordionItem> items, bool alwaysOpen = false) 
        {
            this.Id = $"accordion-{Guid.NewGuid().ToString()}";
            this.Items = items;
            this.AlwaysOpen = alwaysOpen;
        }
    }
}
