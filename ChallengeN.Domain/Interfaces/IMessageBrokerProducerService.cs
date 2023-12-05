using ChallengeN.Domain.Enums;

namespace ChallengeN.Domain.Interfaces;
public interface IMessageBrokerProducerService
{
    public void EntityAsync(OperationTypeEnum record);
}
