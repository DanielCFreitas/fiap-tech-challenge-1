using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.DomainObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Domain.Entities
{
    public class Contato : Entity
    {
        public Contato(string nome, Telefone telefone, Email email, Regiao regiao)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Regiao = regiao;

            ValidarEntidade();
        }

        protected Contato() { }

        public string Nome { get; private set; }
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public Regiao Regiao { get; private set; }

        public string TelefoneFormatado() => $"({Regiao.DDD}) {Telefone.Numero}";

        public void AtualizarContato(string nome, Telefone telefone, Email email, Regiao regiao)
        {
            Validacoes.ExcecaoSeVazioOuNulo(nome, "O nome precisa ser informado");
            Validacoes.ExcecaoSeNulo(telefone, "O telefone precisa ser informado");
            Validacoes.ExcecaoSeNulo(email, "O email precisa ser informado");
            Validacoes.ExcecaoSeNulo(regiao, "A regiao precisa ser informada");

            Nome = nome;
            Telefone = telefone;
            Email = email;
            Regiao = regiao;

            AtualizarDataDeAtualizacao();
        }

        public override void ValidarEntidade()
        {
            Validacoes.ExcecaoSeVazioOuNulo(Nome, "O nome precisa ser informado");
            Validacoes.ExcecaoSeNulo(Telefone, "O telefone precisa ser informado");
            Validacoes.ExcecaoSeNulo(Email, "O email precisa ser informado");
            Validacoes.ExcecaoSeNulo(Regiao, "A regiao precisa ser informada");
        }
    }
}
