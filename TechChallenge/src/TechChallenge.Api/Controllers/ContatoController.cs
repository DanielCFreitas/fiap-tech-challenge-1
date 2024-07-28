using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.Services.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServices _contatoServices;

        public ContatoController(IContatoServices contatoServices)
        {
            _contatoServices = contatoServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarContatoRequest request)
        {
            var resultado = await _contatoServices.CadastrarContato(request);

            if (!resultado.IsValid)
            {
                var errosEncontrados = resultado.Errors.Select(erro => erro.ErrorMessage);
                return BadRequest(errosEncontrados);
            }

            return Ok();
        }
    }
}
