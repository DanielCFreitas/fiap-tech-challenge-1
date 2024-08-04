using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TechChallenge.Api.Controllers
{
    [ApiController]
    public abstract class GenericController : ControllerBase
    {
        private ValidationResult validationResult = new ValidationResult();

        protected IActionResult BaseResponse()
        {
            if (RequisicaoValida())
                return Ok();
            return RetornarBadRequest();
        }

        protected IActionResult BaseResponse(object? resultado)
        {
            if (RequisicaoValida())
                return Ok(resultado);
            return RetornarBadRequest();
        }

        protected void AdicionarErro(ValidationResult validationResultRequest)
        {
            validationResultRequest.Errors.ForEach(validationResult.Errors.Add);
        }

        protected void AdicionarErro(string erro)
        {
            var validationFailure = new ValidationFailure("Erro", erro);
            validationResult.Errors.Add(validationFailure);
        }

        private IActionResult RetornarBadRequest()
        {
            var mensagensDeErro = MensagensDeErro();
            return BadRequest(mensagensDeErro);
        }

        private bool RequisicaoValida() => validationResult.IsValid;

        private IEnumerable<string> MensagensDeErro() => validationResult.Errors.Select(erro => erro.ErrorMessage);
    }
}
