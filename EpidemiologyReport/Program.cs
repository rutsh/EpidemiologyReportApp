

using DAL;
using EpedimiologyReport.Services;
using EpidemiologyReport.Controllers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("C:/Users/user1/Documents/Projects/EpidemiologyReport/Log.txt"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }