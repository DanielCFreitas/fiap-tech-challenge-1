using FluentValidation.Results;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.DTO.Response;
using TechChallenge.Domain.Enum;

namespace TechChallenge.Api.Services.Interfaces
{
    public interface IContatoServices
    {
        /// <summary>
        /// Faz o cadastro de um novo contato 
        /// </summary>
        /// <param name="request">Requisicao enviada para realizar o cadastro de contato</param>
        /// <returns></returns>
        Task<ValidationResult> CadastrarContato(CadastrarContatoRequest request);

        /// <summary>
        /// Busca contato por id
        /// </summary>
        /// <param name="ddd">DDD do contato</param>
        /// <returns></returns>
        Task<IEnumerable<ContatoResponse>> BuscarPorDDD(int ddd);

        /// <summary>
        /// Busca contato por estado
        /// </summary>
        /// <param name="estado">Estado do contato</param>
        /// <returns></returns>
        Task<IEnumerable<ContatoResponse>> BuscarPorEstado(Estado estado);

        /// <summary>
        /// Busca os contatos por sua regiao
        /// </summary>
        /// <param name="estado">Estado que esta o contato</param>
        /// <param name="ddd">ddd do contato</param>
        /// <returns></returns>
        Task<ContatosFiltradosPorRegiaoResponse> BuscarPorRegiao(string estado, int ddd);
    }
}
