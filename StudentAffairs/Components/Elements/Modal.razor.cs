namespace StudentAffairs;

public partial class Modal
{
    [Parameter] public Guid Id { get; set; }
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Message { get; set; }
    [Parameter] public EventCallback OnSave { get; set; }
    [Inject] private IJSRuntime? _jsRuntime { get; set; }

    public const string showFunctionName = "ModalShow";
    public const string closeFunctionName = "ModalClose";

    public async Task ShowModal()
    {
        ArgumentNullException.ThrowIfNull(_jsRuntime);
        object[] parms = { Id };
        await _jsRuntime.InvokeVoidAsync(showFunctionName, parms);
    }
    private async void SaveChanges()
    {
        ArgumentNullException.ThrowIfNull(_jsRuntime);
        object[] parms = { Id };
        await _jsRuntime.InvokeVoidAsync(closeFunctionName, parms);
        
        await OnSave.InvokeAsync();
    }

}