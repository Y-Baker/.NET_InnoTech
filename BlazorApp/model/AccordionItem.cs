namespace BlazorApp.Models;

public class AccordionItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public AccordionItem(int id, string? title = null, string? description = null)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
    }
}
