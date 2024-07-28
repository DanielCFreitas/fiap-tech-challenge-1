using FluentValidation.Results;
using TechChallenge.Api.DTO.Request;
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
    }
}
