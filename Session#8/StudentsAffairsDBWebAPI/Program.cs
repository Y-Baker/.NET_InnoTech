using StudentsAffairsWebAPI;
WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//List<Teacher>? teachers = new List<Teacher>();
//builder.Services.AddSingleton(teachers);

// SQL Server
//string connectingString = "Data Source=172.30.136.6;Initial Catalog=StudentsAffairsDB;User Id=root;Password=root;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;";

// Mysql
string connectingString = "Server=172.30.136.6;Database=StudentsAffairsDB;User=windows;Password=root;Connect Timeout=60;";


builder.Services.AddDbContext<StudentsAffairsDbContext>(options =>
    options.UseMySql(connectingString, new MySqlServerVersion(new Version(8, 0, 25)))
           .EnableServiceProviderCaching()
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .EnableThreadSafetyChecks());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
