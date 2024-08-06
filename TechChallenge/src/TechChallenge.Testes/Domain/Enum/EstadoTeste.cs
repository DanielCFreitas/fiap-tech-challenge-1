using TechChallenge.Domain.Enum;

namespace TechChallenge.Testes.Domain.Enum
{
    public class EstadoTeste
    {
        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [Trait("Estado", "Deve validar o DDD como correto para região")]
        public void Estado_ValidaEstado_DeveTerDDDValidoParaOEstado(int ddd)
        {
            // Arrange
            var estado = Estado.SP;

            // Act & Assert
            Assert.True(estado.DDDEstaValido(ddd));
        }

        [Theory]
        [InlineData(31)]
        [InlineData(51)]
        [InlineData(95)]
        [InlineData(0)]
        [InlineData(44)]
        [Trait("Estado", "Deve validar o DDD como correto para região")]
        public void Estado_ValidaEstado_DeveTerDDDInvalidoParaOEstado(int ddd)
        {
            // Arrange
            var estado = Estado.SP;

            // Act & Assert
            Assert.False(estado.DDDEstaValido(ddd));
        }
    }
}
