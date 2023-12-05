using ChallengeN.Application.Services.MessageBroker.Enums;
using ChallengeN.Domain.Enums;
using ChallengeN.Domain.Interfaces;
using Contracts;
using MassTransit;

namespace ChallengeN.Application.Services;

public class MessageBrokerProducerService : IMessageBrokerProducerService
{
    private readonly IBus _bus;

    public MessageBrokerProducerService(IBus bus)
    {
        _bus = bus;
    }

    public void EntityAsync(OperationTypeEnum nameOperation)
    {
        _bus.Publish(new EntityContract
        {
            NameOperation = nameOperation,
        });
    }
}
