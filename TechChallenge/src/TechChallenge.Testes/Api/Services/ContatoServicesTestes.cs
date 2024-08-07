using Moq;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.Services;
using TechChallenge.Domain.Repository;

namespace TechChallenge.Testes.Api.Services
{
    public class ContatoServicesTestes
    {
        [Fact]
        [Trait("ContatoService", "Deve retrnar que a requisicao nao esta valida")]
        public async void ContatoService_AtualizarContato_DeveRetornarRequisicaoInvalida()
        {
            // Arrange
            var contatoRepository = new Mock<IContatoRepository>();

            var request = new AtualizarContatoRequest()
            {
                Nome = string.Empty,
                Telefone = "11111111",
                Email = "daniel123",
                Estado = "SP",
                DDD = 31
            };

            var contatoServices = new ContatoServices(contatoRepository.Object);

            // Act
            var validationResult = await contatoServices.AtualizarContato(Guid.NewGuid(), request);

            // Assert
            Assert.Equal(4, validationResult.Errors.Count);
            Assert.False(validationResult.IsValid);
        }
    }
}
