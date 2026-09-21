using System.Text.Json;
using APICancelaFaturamento.DTOs;

namespace APICancelaFaturamento.Services;

public class JsonExampleService
{
    private readonly string _jsonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "JSON");

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public string LerExemploEntrada()
    {
        var arquivo = Path.Combine(_jsonDirectory, "payloadRecebimento.json");

        if (File.Exists(arquivo))
        {
            return File.ReadAllText(arquivo);
        }

        return "{}";
    }

    public string LerExemploResposta()
    {
        var arquivo = Path.Combine(_jsonDirectory, "payloadResposta.json");

        if (File.Exists(arquivo))
        {
            return File.ReadAllText(arquivo);
        }

        return "{}";
    }

    public RespostaApiDto ConstruirResposta(RecebimentoRequestDto payload)
    {
        var exemplo = LerExemploResposta();
        var resposta = JsonSerializer.Deserialize<RespostaApiDto>(exemplo, _jsonOptions) ?? new RespostaApiDto();

        return resposta;
    }
}
