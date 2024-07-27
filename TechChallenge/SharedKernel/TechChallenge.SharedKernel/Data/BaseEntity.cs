namespace TechChallenge.SharedKernel.Data
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; } = null;

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }
}
