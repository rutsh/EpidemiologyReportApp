

using DAL;
using DAL.Models;
using EpedimiologyReport.Services;
using EpidemiologyReport.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Templates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddDbContext<ReportContext>(options =>
options.UseSqlServer("Server =DESKTOP-6S5T98O\\SQLEXPRESS; Database = Report; Trusted_Connection = True; "));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new ExpressionTemplate(
          "[{@t:HH:mm:ss} {@l:u3} {SourceContext}] {@m}\n{@x}"), "C:/Users/user1/Documents/Projects/EpidemiologyReport/Log.txt"));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseAuthorization();
app.UseMiddleware<ErrorLoggingMiddleware>();
app.MapControllers();

app.Run();

public partial class Program { }