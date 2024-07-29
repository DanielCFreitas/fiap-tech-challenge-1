using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.Services.Interfaces;
using TechChallenge.Domain.Enum;
using TechChallenge.Domain.Repository;

namespace TechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServices _contatoServices;
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoServices contatoServices, IContatoRepository contatoRepository)
        {
            _contatoServices = contatoServices;
            _contatoRepository = contatoRepository;
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

        [HttpGet("{ddd:int}")]
        public async Task<IActionResult> BuscarPorDDD(int ddd)
        {
            var contatos = await _contatoRepository.BuscarPorDDD(ddd);

            return Ok(contatos);
        }

        [HttpGet("{estado}")]
        public async Task<IActionResult> BuscarPorEstado(string estado)
        {
            var converteuEstado = Enum.TryParse<Estado>(estado, true, out var estadoEnum);

            if (!converteuEstado) return BadRequest("Estado inválido");

            var contatos = await _contatoRepository.BuscarPorEstado(estadoEnum);

            return Ok(contatos);
        }

        [HttpGet("{estado}/{ddd:int}")]
        public async Task<IActionResult> BuscarPorRegiao(string estado, int ddd)
        {
            var response = await _contatoServices.BuscarPorRegiao(estado, ddd);

            if (!response.ValidationResult.IsValid)
            {
                var errosEncontrados = response.ValidationResult.Errors.Select(erro => erro.ErrorMessage);
                return BadRequest(errosEncontrados);
            }

            return Ok(response.Contatos);
        }
    }
}
