using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Testes.Api.Services.Fixtures
{
    public class ContatoServicesTestesFixture : IDisposable
    {
        [CollectionDefinition(nameof(ContatoServicesTestesCollection))]
        public class ContatoServicesTestesCollection : ICollectionFixture<ContatoServicesTestesFixture> { }

        public Contato CriaContatoValido()
        {
            var telefone = new Telefone("1111-1111");
            var email = new Email("daniel@email.com");
            var regiao = new Regiao(Estado.SP, 11);

            return new Contato("Daniel", telefone, email, regiao);
        }

        public void Dispose() { }
    }
}
