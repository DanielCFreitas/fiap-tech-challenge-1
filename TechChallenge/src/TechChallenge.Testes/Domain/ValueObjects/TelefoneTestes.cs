using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Testes.Domain.ValueObjects
{
    public class TelefoneTestes
    {
        [Fact]
        [Trait("Telefone", "Deve conseguir criar telefone normalmente")]
        public void Telefone_Construtor_DeveConseguirInstanciarTelefoneNormalmente()
        {
            // Arrange
            var telefone = new Telefone("1111-1111");

            // Act & Assert
            Assert.NotNull(telefone);
        }

        [Theory]
        [InlineData("")]
        [InlineData("11111111")]
        [InlineData("abcd-abcd")]
        [Trait("Telefone", "Deve dar erro ao criar o telefone")]
        public void Telefone_Construtor_DeveDarErroAoRealizarInstanciaDeTelefone(string numeroTelefone)
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new Telefone(numeroTelefone));
        }
    }
}
