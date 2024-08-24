using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Components
{
    public partial class Accordion
    {
        [Parameter] public AccordionData? accordionData { get; set; }

        internal string? accordionId;
        internal List<AccordionItem>? accordionItems;
        internal bool alwaysOpen;
        internal bool firstItem = true;
        const string accordionFunctionName = "startAccordion";
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            // Console.WriteLine("Render Method", "****");
            if (firstRender)
            {
                object[] parms = { accordionData!.Id };
                await _jsRuntime.InvokeVoidAsync(accordionFunctionName, parms);
            }
        }
        protected override void OnParametersSet()
        {
            // Console.WriteLine("Parameter Set Method", "%%%%");
            if (accordionData == null)
            {
                List<AccordionItem> items = new();
                items.Add(new AccordionItem(1, "Accordion Item", "<strong>Description 1</strong>"));
                items.Add(new AccordionItem(2, "Accordion Item", "<strong>This is the second item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow."));
                items.Add(new AccordionItem(3, "Accordion Item", "Description 3"));
                accordionData = new(items);
            }
            accordionId = accordionData.Id;
            accordionItems = accordionData.Items;
            alwaysOpen = accordionData.AlwaysOpen;
        }
    }
}