using BlazorApp.model;

namespace BlazorApp.Pages
{
    public partial class AccordionPage
    {
        AccordionData? accordion1;

        protected override async Task OnInitializedAsync()
        {
            List<AccordionItem> items1 = new()
            {
                new AccordionItem(1, "Introduction", "Welcome to the first section of the accordion."),
                new AccordionItem(2, "Features", "<strong>Features:</strong> This section describes the features."),
                new AccordionItem(3, "Installation", "Instructions on how to install the application."),
                new AccordionItem(4, "Usage", "<em>Usage:</em> Details on how to use the application effectively."),
                new AccordionItem(5, "Support", "Information on how to get support and assistance.")
            };
            accordion1 = new(items1, alwaysOpen: true);
        }
    }
}