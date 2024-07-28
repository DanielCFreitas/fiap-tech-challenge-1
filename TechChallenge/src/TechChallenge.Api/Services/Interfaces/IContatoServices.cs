using FluentValidation.Results;
using TechChallenge.Api.DTO.Request;

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
    }
}
