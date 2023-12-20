using ChallengeN.Configuration;
using ChallengeN.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddMediatorRegistration(builder.Configuration);
builder.Services.AddRepositoryRegistration(builder.Configuration);
builder.Services.AddDatabaseConfig(builder.Configuration);
builder.Services.AddElasticsearchConfig(builder.Configuration);
builder.Services.AddSerilogConfig(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Console.WriteLine("Creating migrations");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CNDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        Console.WriteLine("With migrations");
        context.Database.Migrate();
    }else{
        Console.WriteLine("Without migrations");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }