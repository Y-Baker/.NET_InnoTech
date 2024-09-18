namespace StudentAffairs;

public partial class Carousel
{
    [Inject] private IJSRuntime? _jsRuntime { get; set; }

    string carouselName = Guid.NewGuid().ToString();
    const string carouselFunctionName = "startCarousel";
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(_jsRuntime);
            object[] parms = { carouselName };
            await _jsRuntime.InvokeVoidAsync(carouselFunctionName, parms);
        }
    }
}
