using Contracts;
using global::MassTransit;
using Microsoft.Extensions.Logging;

namespace ChallengeN.Application.Services.MessageBroker.Consumers;

public class EntityConsumer : IConsumer<EntityContract>
{
    readonly ILogger<EntityConsumer> _logger;

    public EntityConsumer(ILogger<EntityConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<EntityContract> context)
    {
        _logger.LogInformation("{Text}", context.Message.NameOperation);
        return Task.CompletedTask;
    }
}
