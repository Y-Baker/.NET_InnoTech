using StudentAffairs;

WebApplicationBuilder? webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services
                     .AddRazorComponents()
                     .AddInteractiveServerComponents();


webApplicationBuilder.Services.AddDbContext<StudentsAffairsDbContext>(options =>
{
    ConnectionStrings? connectionStrings = webApplicationBuilder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
    ArgumentNullException.ThrowIfNull(connectionStrings);
    options.UseMySql(connectionStrings.MySQL, ServerVersion.AutoDetect(connectionStrings.MySQL))
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
           .EnableServiceProviderCaching()
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .EnableThreadSafetyChecks();
});

WebApplication? webApplication = webApplicationBuilder.Build();

if (!webApplication.Environment.IsDevelopment())
{
    webApplication.UseExceptionHandler("/Error", createScopeForErrors: true);
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();

webApplication.UseStaticFiles();
webApplication.UseAntiforgery();
    
webApplication.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

webApplication.Run();
