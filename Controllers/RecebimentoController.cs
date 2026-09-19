using APICancelaFaturamento.DTOs;
using APICancelaFaturamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICancelaFaturamento.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecebimentoController : ControllerBase
{
    private readonly JsonExampleService _jsonExampleService;

    public RecebimentoController(JsonExampleService jsonExampleService)
    {
        _jsonExampleService = jsonExampleService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(RespostaApiDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<RespostaApiDto> Post([FromBody] RecebimentoRequestDto payload)
    {
        if (payload == null)
        {
            return BadRequest(new { erro = "O corpo da requisição é obrigatório." });
        }

        var resposta = _jsonExampleService.ConstruirResposta(payload);
        return Ok(resposta);
    }

    [HttpGet("exemplo-entrada")]
    public ActionResult<string> ObterExemploEntrada()
    {
        return Ok(_jsonExampleService.LerExemploEntrada());
    }

    [HttpGet("exemplo-resposta")]
    public ActionResult<string> ObterExemploResposta()
    {
        return Ok(_jsonExampleService.LerExemploResposta());
    }
}
