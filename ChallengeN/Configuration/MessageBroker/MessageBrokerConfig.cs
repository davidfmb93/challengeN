using ChallengeN.Application.Services.MessageBroker.Consumers;
using Contracts;
using MassTransit;
using System.Reflection;

namespace ChallengeN.Configuration.MessageBroker;

public static class MessageBrokerConfig
{

    private static string? KafkaUrl = "";
    public static IServiceCollection AddMessageBrokerConfig(this IServiceCollection services, IConfiguration configuration)
    {
        KafkaUrl = configuration.GetConnectionString("KafkaConnection");

        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);


            x.AddRider(rider =>
            {
                rider.AddConsumer<EntityConsumer>();

                rider.UsingKafka((context, k) =>
                {
                    k.Host(KafkaUrl);

                    k.TopicEndpoint<EntityContract>("entity-operation", "consumer-entities", e =>
                    {
                        e.ConfigureConsumer<EntityConsumer>(context);
                    });
                });
            });

        });

        return services;
    }
}
