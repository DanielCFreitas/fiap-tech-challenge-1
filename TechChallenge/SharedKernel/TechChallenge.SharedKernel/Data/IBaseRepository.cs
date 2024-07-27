using TechChallenge.SharedKernel.DomainObjects;

namespace TechChallenge.SharedKernel.Data
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
