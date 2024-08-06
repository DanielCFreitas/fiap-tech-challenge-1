using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Testes.Domain
{
    public class ContatoTestes
    {
        [Fact]
        [Trait("Contato", "Deve criar contato com sucesso")]
        public void Contato_CriarContato_DeveCriarComSucesso()
        {
            // Arrange
            var telefone = new Telefone("1111-1111");
            var email = new Email("contato@teste.com.br");
            var regiao = new Regiao(Estado.SP, 12);

            // Act
            var contato = new Contato("Contato", telefone, email, regiao);

            // Assert
            Assert.NotNull(contato);
        }

        [Fact]
        [Trait("Contato", "Deve estourar erro pois criou contato inválido")]
        public void Contato_CriarContato_DeveEstourarErroDeContatoInvalido()
        {
            // Arrange
            var telefone = new Telefone("1111-1111");
            var email = new Email("contato@teste.com.br");
            var regiao = new Regiao(Estado.SP, 11);

            // Act & Assert
            Assert.Throws<DomainException>(() => new Contato(string.Empty, telefone, email, regiao));
        }

        [Fact]
        [Trait("Contato", "Deve atualizar contato com sucesso")]
        public void Contato_AtualizarContato_DeveConseguirAtualizarContato()
        {
            // Arrange
            var telefone = new Telefone("1111-1111");
            var email = new Email("contato@teste.com.br");
            var regiao = new Regiao(Estado.SP, 12);
            var contato = new Contato("Contato", telefone, email, regiao);

            // Act
            var nomeContato = "Contato Atualizado";
            contato.AtualizarContato(nomeContato, telefone, email, regiao);

            // Assert
            Assert.Equal(contato.Nome, nomeContato);
        }
    }
}
