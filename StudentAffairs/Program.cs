WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

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
string[] supportedCultures = webApplicationBuilder.Configuration.GetSection("SupportedCultures").Get<string[]>() ?? new string[] { "en-US" };
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

webApplicationBuilder.Services.AddControllers();
webApplicationBuilder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

webApplicationBuilder.Services.AddScoped<IService, Service>();
webApplicationBuilder.Services.AddScoped<IEmailService, EmailService>();
webApplicationBuilder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
webApplicationBuilder.Services.AddScoped<IStudentsUnitOfWork, StudentsUnitOfWork>();
webApplicationBuilder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
webApplicationBuilder.Services.AddScoped<IDoctorsUnitOfWork, DoctorsUnitOfWork>();
webApplicationBuilder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
webApplicationBuilder.Services.AddScoped<ICoursesUnitOfWork, CoursesUnitOfWork>();

WebApplication webApplication = webApplicationBuilder.Build();

webApplication.UseRequestLocalization(localizationOptions);

if (!webApplication.Environment.IsDevelopment())
{
    webApplication.UseExceptionHandler("/Error", createScopeForErrors: true);
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();
webApplication.UseStaticFiles();
webApplication.UseAntiforgery();

webApplication.MapControllers();

webApplication.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

webApplication.Run();
 