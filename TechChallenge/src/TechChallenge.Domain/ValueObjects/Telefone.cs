using TechChallenge.SharedKernel.DomainObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Domain.ValueObjects
{
    public class Telefone : ValueObject
    {
        public const string RegexFormatoDoTelefone = "^[0-9]{4}-[0-9]{4}$";

        public Telefone(string numero)
        {
            Numero = numero;

            Validar();
        }

        protected Telefone() { }

        public string Numero { get; private set; }

        public override void Validar()
        {
            Validacoes.ExcecaoSeNaoSeguirPadraoDaExpressaoRegular(Numero, RegexFormatoDoTelefone, "O Telefone não está seguindo o padrão correto");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Numero;
        }
    }
}
