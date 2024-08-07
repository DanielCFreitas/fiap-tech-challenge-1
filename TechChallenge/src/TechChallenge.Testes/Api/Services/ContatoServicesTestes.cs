using Moq;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.Services;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repository;
using TechChallenge.Testes.Api.Services.Fixtures;
using static TechChallenge.Testes.Api.Services.Fixtures.ContatoServicesTestesFixture;

namespace TechChallenge.Testes.Api.Services
{
    [Collection(nameof(ContatoServicesTestesCollection))]
    public class ContatoServicesTestes
    {
        private readonly ContatoServicesTestesFixture _contatoServicesTestesFixture;

        public ContatoServicesTestes(ContatoServicesTestesFixture contatoServicesTestesFixture)
        {
            _contatoServicesTestesFixture = contatoServicesTestesFixture;
        }

        [Fact]
        [Trait("ContatoServices", "Deve retrnar que a requisicao nao esta valida")]
        public async void ContatoServices_AtualizarContato_DeveRetornarRequisicaoInvalida()
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

        [Fact]
        [Trait("ContatoServices", "Deve retornar que o contato não existe ao tentar realizar atualização")]
        public async void ContatoServices_AtualizarContato_DeveRetornarErroDeContatoInexistente()
        {
            // Arrange
            var contatoRepository = new Mock<IContatoRepository>();
            contatoRepository
                .Setup(repository => repository.BuscarPorId(It.IsAny<Guid>()))
                .ReturnsAsync((Contato?)null);


            var request = new AtualizarContatoRequest()
            {
                Nome = "Daniel",
                Telefone = "1111-1111",
                Email = "daniel@email.com.br",
                Estado = "SP",
                DDD = 11
            };

            var contatoServices = new ContatoServices(contatoRepository.Object);

            // Act
            var validationResult = await contatoServices.AtualizarContato(Guid.NewGuid(), request);

            // Assert
            Assert.Single(validationResult.Errors);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        [Trait("ContatoServices", "Deve retornar que nao conseguiu persistir a atualização no banco de dados")]
        public async void ContatoServices_AtualizarContato_DeveRetornarErroDePersistenciaNoBanco()
        {
            // Arrange
            var contatoRepository = new Mock<IContatoRepository>();
            contatoRepository
                .Setup(repository => repository.BuscarPorId(It.IsAny<Guid>()))
                .ReturnsAsync(_contatoServicesTestesFixture.CriaContatoValido());

            contatoRepository
                .Setup(repository => repository.UnitOfWork.ConfirmarTransacao())
                .ReturnsAsync(false);

            var request = new AtualizarContatoRequest()
            {
                Nome = "Daniel",
                Telefone = "1111-1111",
                Email = "daniel@email.com.br",
                Estado = "SP",
                DDD = 11
            };

            var contatoServices = new ContatoServices(contatoRepository.Object);

            // Act
            var validationResult = await contatoServices.AtualizarContato(Guid.NewGuid(), request);

            // Assert
            Assert.Single(validationResult.Errors);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        [Trait("ContatoServices", "Deve retornar que conseguiu atualizar contato com sucesso")]
        public async void ContatoServices_AtualizarContato_DeveConseguirAtualizarContatoComSucesso()
        {
            // Arrange
            var contatoRepository = new Mock<IContatoRepository>();
            contatoRepository
                .Setup(repository => repository.BuscarPorId(It.IsAny<Guid>()))
                .ReturnsAsync(_contatoServicesTestesFixture.CriaContatoValido());

            contatoRepository
                .Setup(repository => repository.UnitOfWork.ConfirmarTransacao())
                .ReturnsAsync(true);

            var request = new AtualizarContatoRequest()
            {
                Nome = "Daniel",
                Telefone = "1111-1111",
                Email = "daniel@email.com.br",
                Estado = "SP",
                DDD = 11
            };

            var contatoServices = new ContatoServices(contatoRepository.Object);

            // Act
            var validationResult = await contatoServices.AtualizarContato(Guid.NewGuid(), request);

            // Assert
            Assert.Empty(validationResult.Errors);
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        [Trait("ContatoServices", "Deve retornar que a requisicao nao esta valida")]
        public async void ContatoServices_CadastrarContato_DeveRetornarErroDeValidacaoDaRequisicao()
        {
            // Arrange
            var contatoRepository = new Mock<IContatoRepository>();

            var request = new CadastrarContatoRequest()
            {
                Nome = string.Empty,
                Telefone = "11111111",
                Email = "daniel123",
                Estado = "SP",
                DDD = 31
            };

            var contatoServices = new ContatoServices(contatoRepository.Object);

            // Act
            var validationResult = await contatoServices.CadastrarContato(request);

            // Assert
            Assert.Equal(4, validationResult.Errors.Count);
            Assert.False(validationResult.IsValid);
        }
    }
}
