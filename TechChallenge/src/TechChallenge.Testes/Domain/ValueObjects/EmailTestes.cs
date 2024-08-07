using TechChallenge.Domain.ValueObjects;
using TechChallenge.SharedKernel.Validations;

namespace TechChallenge.Testes.Domain.ValueObjects
{
    public class EmailTestes
    {
        [Theory]
        [InlineData("teste@contato.com")]
        [InlineData("teste@contato.com.br")]
        [InlineData("teste@contato.edu.br")]
        [Trait("Email", "Deve conseguir criar e-mail válido")]
        public void Email_Construtor_DeveConseguirCriarValueObjectDeEmail(string enderecoDeEmail)
        {
            // Arrange
            var email = new Email(enderecoDeEmail);

            // Act & Assert
            Assert.NotNull(email);
        }

        [Theory]
        [InlineData("")]
        [InlineData("email")]
        [InlineData("emailcontato.com.br")]
        [InlineData("email@contato")]
        [Trait("Email", "Deve enviar erro de que o email esta invalido")]
        public void Email_Construtor_DeveEstourarExcecaoDeEmailInvalido(string enderecoDeEmail)
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new Email(enderecoDeEmail));
        }
    }
}
