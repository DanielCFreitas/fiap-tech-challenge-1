using FluentValidation.Results;

namespace TechChallenge.Api.DTO.Response
{
    public record ContatosFiltradosPorRegiaoResponse
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();
        public IEnumerable<ContatoResponse> Contatos { get; set; } = new List<ContatoResponse>();
    }

    public record ContatoResponse
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }
}
