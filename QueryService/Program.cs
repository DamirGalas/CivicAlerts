using QueryService.Application.Handlers;
using CivicAlerts.Data;

var builder = WebApplication.CreateBuilder(args);

// Read ConnectionStrings from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// For more information about configuring Swagger/OpenAPI, visit https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(connectionString);

builder.Services.AddScoped<GetIncidentsHandler>();
builder.Services.AddScoped<GetIncidentByIdHandler>();

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
