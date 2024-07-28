namespace TechChallenge.SharedKernel.Data
{
    public interface IUnitOfWork
    {
        Task<bool> ConfirmarTransacao();
    }
}
