using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace ChallengeN.Configuration;
public static class ElasticsearchConfig
{
    public static IServiceCollection AddElasticsearchConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var uri = new Uri(configuration["Elasticsearch:ServerUrl"]);
        var indexName = configuration["Elasticsearch:IndexName"];
        var apiKey = configuration["Elasticsearch:ApiKey"];

        //var client = new ElasticsearchClient(uri, new ApiKey(apiKey));

        //services.AddSingleton<IElasticClient>(client); // Register ElasticClient as a singleton

        return services;
    }
}
