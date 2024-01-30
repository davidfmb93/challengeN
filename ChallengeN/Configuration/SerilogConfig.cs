using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace ChallengeN.Configuration;
public static class SerilogConfig
{
    public static WebApplicationBuilder AddSerilogConfig(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var enviroment = "Dev";

        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{enviroment}.json", optional: true
            ).Build();

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureElasticSink(configurationBuilder, enviroment))
            .Enrich.WithProperty("Environment", enviroment)
            .ReadFrom.Configuration(configurationBuilder)
            .CreateLogger();

        builder.Host.UseSerilog();
        return builder;
    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configurationBuilder, string enviroment)
    {
        return new ElasticsearchSinkOptions(new Uri(configurationBuilder["ElasticConfiguration:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{enviroment.ToLower()}-{DateTime.UtcNow:yyyyy-MM}",
            NumberOfReplicas = 1,
            NumberOfShards = 2,
        };
    }
}
