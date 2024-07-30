using FluentValidation.Results;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.DTO.Response;
using TechChallenge.Api.Services.Interfaces;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.Repository;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Api.Services
{
    public class ContatoServices : IContatoServices
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoServices(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<ValidationResult> CadastrarContato(CadastrarContatoRequest request)
        {
            if (!request.RequisicaoEstaValida())
                return request.ValidationResult!;

            var estado = Enum.Parse<Estado>(request.Estado);

            var telefone = new Telefone(request.Telefone);
            var email = new Email(request.Email);
            var regiao = new Regiao(estado, request.DDD);
            var contato = new Contato(request.Nome, telefone, email, regiao);

            _contatoRepository.Cadastrar(contato);
            var cadastradoComSucesso = await _contatoRepository.UnitOfWork.ConfirmarTransacao();

            if (!cadastradoComSucesso)
                return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Banco de Dados", "Não conseguiu persistir o contato no banco de dados") });

            return request.ValidationResult!;
        }


        public async Task<ContatosFiltradosPorRegiaoResponse> BuscarPorRegiao(string estado, int ddd)
        {
            var response = new ContatosFiltradosPorRegiaoResponse();

            var estadoEstaValido = Enum.TryParse<Estado>(estado, true, out var estadoEnum);
            if (!estadoEstaValido)
            {
                var validationFailure = new ValidationFailure("Estado", "Estado está inválido");
                response.ValidationResult.Errors.Add(validationFailure);
                return response;
            }

            var dddEstaValido = estadoEnum.DDDEstaValido(ddd);
            if (!dddEstaValido)
            {
                var validationFailure = new ValidationFailure("DDD", $"DDD está inválido para o estado {estado}");
                response.ValidationResult.Errors.Add(validationFailure);
                return response;
            }

            var regiao = new Regiao(estadoEnum, ddd);
            var contatos = await _contatoRepository.BuscarPorRegiao(regiao);
            response.Contatos = MapearParaContatoResponse(contatos);
            return response;
        }

        /// <summary>
        /// Mapeia o contato para ContatoResponse
        /// </summary>
        /// <param name="contatos">Contatos conforme vem do banco de dados</param>
        /// <returns></returns>
        private IEnumerable<ContatoResponse> MapearParaContatoResponse(IEnumerable<Contato> contatos)
        {
            return contatos.Select(contato => new ContatoResponse()
            {
                Nome = contato.Nome,
                Email = contato.Email.EnderecoDeEmail,
                Estado = contato.Regiao.Estado.ToString(),
                Telefone = contato.TelefoneFormatado()
            });
        }
    }
}
