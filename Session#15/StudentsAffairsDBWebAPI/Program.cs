using Microsoft.AspNetCore.Cors.Infrastructure;
using StudentsAffairsWebAPI;
WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

//List<Teacher>? teachers = new List<Teacher>();
//builder.Services.AddSingleton(teachers);

// SQL Server
//const string connectingString = "Data Source=172.30.136.6;Initial Catalog=StudentsAffairsDB;User Id=root;Password=root;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;";

// Mysql
const string connectingString = "Server=172.30.136.6;Database=StudentsAffairsDB;User=windows;Password=root;Connect Timeout=60;";

builder.Services.AddDbContext<StudentsAffairsDbContext>(options =>
    options.UseMySql(connectingString, new MySqlServerVersion(new Version(8, 0, 25)))
           .EnableServiceProviderCaching()
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .EnableThreadSafetyChecks());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


const string corsPolicy = "AllowLocalhost";
builder.Services
       .AddCors(corsOptions => corsOptions
       .AddPolicy(corsPolicy, corsPolicyBuilder => corsPolicyBuilder
       .AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod()));

WebApplication? app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
