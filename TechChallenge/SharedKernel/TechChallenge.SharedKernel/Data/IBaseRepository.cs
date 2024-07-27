namespace TechChallenge.SharedKernel.Data
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
