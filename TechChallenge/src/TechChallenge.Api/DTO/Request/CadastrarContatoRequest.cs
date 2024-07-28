using FluentValidation;
using FluentValidation.Results;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Api.DTO.Request
{
    public record CadastrarContatoRequest
    {
        public ValidationResult? ValidationResult { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public int DDD { get; set; }

        public bool RequisicaoEstaValida()
        {
            ValidationResult = new CadastrarContatoRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarContatoRequestValidation : AbstractValidator<CadastrarContatoRequest>
    {
        public CadastrarContatoRequestValidation()
        {
            RuleFor(request => request.Nome)
                .NotEmpty().WithMessage("O nome precisa ser informado");

            RuleFor(request => request.Telefone)
                .NotEmpty().WithMessage("O telefone precisa ser informado")
                .MaximumLength(9).WithMessage("O telefone deve ter no máximo 9 caracteres")
                .Matches(Telefone.RegexFormatoDoTelefone).WithMessage("O telefone não está no formato correto");

            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("O e-mail precisa ser informado")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres")
                .Matches(Email.RegexFormatoDoEmail).WithMessage("O email não está no formato correto");

            RuleFor(request => request.Estado)
                .NotEmpty().WithMessage("O estado precisa ser informado")
                .Length(2).WithMessage("O estado deve possuir 2 caracteres")
                .IsEnumName(typeof(Estado)).WithMessage("O estado está inválido")
                .Must(DDDValidoParaARegiao).WithMessage("O DDD não faz parte desta regiao");

            RuleFor(request => request.DDD)
                .NotEmpty().WithMessage("O ddd precisa ser informado");
        }

        public bool DDDValidoParaARegiao(CadastrarContatoRequest request, string estado)
        {
            var resultado = Enum.TryParse<Estado>(estado, true, out var estadoEnum);
            if (!resultado) return false;

            var dddEstaValido = estadoEnum.DDDEstaValido(request.DDD);
            return dddEstaValido;
        }
    }
}
