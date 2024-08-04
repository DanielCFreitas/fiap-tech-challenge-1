using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.DTO.Request;
using TechChallenge.Api.Services.Interfaces;
using TechChallenge.Domain.Enum;

namespace TechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContatoController : GenericController
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

            if (!resultado.IsValid) AdicionarErro(resultado);

            return BaseResponse();
        }

        [HttpPut("{contatoId}")]
        public async Task<IActionResult> Put(Guid contatoId, [FromBody] AtualizarContatoRequest request)
        {
            var resultado = await _contatoServices.AtualizarContato(contatoId, request);

            if (!resultado.IsValid) AdicionarErro(resultado);

            return BaseResponse();
        }

        [HttpGet("{ddd:int}")]
        public async Task<IActionResult> BuscarPorDDD(int ddd)
        {
            var contatos = await _contatoServices.BuscarPorDDD(ddd);

            return BaseResponse(contatos);
        }

        [HttpGet("{estado}")]
        public async Task<IActionResult> BuscarPorEstado(string estado)
        {
            var converteuEstado = Enum.TryParse<Estado>(estado, true, out var estadoEnum);

            if (!converteuEstado)
            {
                AdicionarErro("Estado inválido");
                return BaseResponse();
            }

            var contatos = await _contatoServices.BuscarPorEstado(estadoEnum);

            return BaseResponse(contatos);
        }

        [HttpGet("{estado}/{ddd:int}")]
        public async Task<IActionResult> BuscarPorRegiao(string estado, int ddd)
        {
            var response = await _contatoServices.BuscarPorRegiao(estado, ddd);

            if (!response.ValidationResult.IsValid) AdicionarErro(response.ValidationResult);

            return BaseResponse(response.Contatos);
        }

        [HttpDelete("{contatoId}")]
        public async Task<IActionResult> Delete(Guid contatoId)
        {
            var resultado = await _contatoServices.ExcluirContato(contatoId);

            if (!resultado.IsValid) AdicionarErro(resultado);

            return BaseResponse();
        }
    }
}
