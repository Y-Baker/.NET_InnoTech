namespace StudentAffairs;

public partial class CultureSelector
{
    [Inject] private IConfiguration? configuration { get; set; }
    List<CultureInfo> cultures = new();

    protected override void OnInitialized()
    {
        List<string> culturesFromConfig = configuration?.GetSection("SupportedCultures").Get<List<string>>() ?? new List<string> { "en-US" };
        foreach (string culture in culturesFromConfig)
        {
            cultures.Add(new CultureInfo(culture));
        }
        SelectedCulture = CultureInfo.CurrentCulture;
    }

    private CultureInfo SelectedCulture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                string? uri = new Uri(_navManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                string? cultureEscaped = Uri.EscapeDataString(value.Name);
                string? uriEscaped = Uri.EscapeDataString(uri);

                _navManager.NavigateTo($"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}", forceLoad: true);
            }
        }
    }
}