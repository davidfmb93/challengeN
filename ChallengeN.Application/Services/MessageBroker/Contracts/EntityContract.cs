using ChallengeN.Domain.Enums;

namespace Contracts;

public record EntityContract
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public OperationTypeEnum NameOperation { get; init; }
}
