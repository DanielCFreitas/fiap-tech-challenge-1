using TechChallenge.SharedKernel.DomainObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private const string RegexFormatoDoEmail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        public Email(string enderecoDeEmail)
        {
            EnderecoDeEmail = enderecoDeEmail;

            Validar();
        }

        public string EnderecoDeEmail { get; private set; }

        public override void Validar()
        {
            Validacoes.ExcecaoSeNaoSeguirPadraoDaExpressaoRegular(EnderecoDeEmail, RegexFormatoDoEmail, "O E-mail não está seguindo o padrão correto");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EnderecoDeEmail;
        }
    }
}
