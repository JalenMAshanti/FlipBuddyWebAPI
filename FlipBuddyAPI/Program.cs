using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Implementation;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Dependencies
builder.Services.AddScoped<IOrchestrator, Orchestrator>();
builder.Services.AddScoped<IHandlerFactory, HandlerFactory>();
builder.Services.AddTransient<ITypeActivator, TypeActivator>();
builder.Services.AddScoped<IHandlerDictionary, HandlerDictionary>();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddScoped<IDbConnectionFactory, MySqlConnectionFactory>(sp =>
{
	var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	return new MySqlConnectionFactory(connectionString!);
});
builder.Services.AddScoped<APIService, ExternalAPIService>();
builder.Services.AddScoped<ClientFactory>();
builder.Services.AddScoped<ExternalAPIService>();


var app = builder.Build();

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
