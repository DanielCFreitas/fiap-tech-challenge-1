using TechChallenge.Domain.Enum;
using TechChallenge.Domain.Exceptions;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Testes.Domain.ValueObjects
{
    public class RegiaoTestes
    {
        [Fact]
        [Trait("Regiao", "Deve conseguir criar região normalmente")]
        public void Regiao_InstanciaRegiao_DeveConseguirCriarRegiaoComSucesso()
        {
            // Arrange
            var regiao = new Regiao(Estado.SP, 11);

            // Act & Assert
            Assert.NotNull(regiao);
        }

        [Theory]
        [InlineData(Estado.SP, 31)]
        [InlineData(Estado.RJ, 11)]
        [Trait("Regiao", "Deve dar erro por região com DDD inválido")]
        public void Regiao_InstanciaRegiao_DeveDarErroPorRegiaoComDDDInvalido(Estado estado, int ddd)
        {
            // Arrange, Act & Assert
            Assert.Throws<RegiaoComDDDInvalidoException>(() => new Regiao(estado, ddd));
        }
    }
}
