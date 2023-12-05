namespace ChallengeN.Domain.Interfaces;
public interface IRepository<T>
{
    T? Get(Guid employeeId);
    T? Add(T employee);
    T? Update(T employee);
}
