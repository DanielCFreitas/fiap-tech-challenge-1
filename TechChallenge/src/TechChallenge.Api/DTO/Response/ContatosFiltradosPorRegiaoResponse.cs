using FluentValidation.Results;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Api.DTO.Response
{
    public class ContatosFiltradosPorRegiaoResponse
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();
        public IEnumerable<Contato> Contatos { get; set; } = new List<Contato>();
    }
}
