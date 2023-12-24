using AdessoCodeChallenge.API.Helper;
using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCommonCore.CustomClass;
using AdessoCodeChallenge.ServiceCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<AdessoCodeChallengeDBContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("AdessoCodeChallengeDBContext"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServiceRegistration.AddInfrastructure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

var scope = builder.Services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetServices<AdessoCodeChallengeDBContext>().FirstOrDefault();

SeedDB.Initialize(dbContext);

var webHostEnvironment = scope.ServiceProvider.GetServices<IWebHostEnvironment>().FirstOrDefault();
var logFactory = new LoggerFactory();
logFactory.AddProvider(new LoggerProvider(webHostEnvironment));
LogProvider.LogFactoryValue = logFactory;

app.Run();
