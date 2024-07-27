using TechChallenge.Domain.Enum;
using TechChallenge.Domain.Exceptions;
using TechChallenge.SharedKernel.DomainObjects;

namespace TechChallenge.Domain.ValueObjects
{
    public class Regiao : ValueObject
    {
        public Regiao(Estado estado, int ddd)
        {
            Estado = estado;
            DDD = ddd;
        }

        public Estado Estado { get; private set; }
        public int DDD { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Estado;
            yield return DDD;
        }

        public override void Validar()
        {
            if (!Estado.DDDEstaValido(DDD))
                throw new RegiaoComDDDInvalidoException($"O DDD {DDD} não pertence ao estado {Estado}");
        }
    }
}
