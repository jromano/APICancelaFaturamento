using System.Text.Json;
using APICancelaFaturamento.DTOs;

namespace APICancelaFaturamento.Services;

public class JsonExampleService
{
    private readonly string _jsonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "JSON");

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
        var resposta = JsonSerializer.Deserialize<RespostaApiDto>(exemplo) ?? new RespostaApiDto();

        resposta.CompanhiaSolicitante = payload.CompanhiaSolicitante;
        resposta.AreaSolicitante = payload.AreaSolicitante;
        resposta.IdJde = payload.IdJde;
        resposta.NomeSolicitante = payload.NomeSolicitante;
        resposta.MotivoCancelamento = payload.MotivoCancelamento;
        resposta.OrigemCancelamento = payload.OrigemCancelamento;
        resposta.TipoLoja = payload.TipoLoja;
        resposta.Loja = payload.Loja;
        resposta.CnpjLoja = payload.CnpjLoja;
        resposta.CpfLoja = payload.CpfLoja;
        resposta.Luc = payload.Luc;
        resposta.TipoFaturamento = payload.TipoFaturamento;
        resposta.Companhia = payload.Companhia;
        resposta.CodigoCompanha = payload.CodigoCompanha;
        resposta.CnpjCompanhia = payload.CnpjCompanhia;
        resposta.AbrevCompanhia = payload.AbrevCompanhia;
        resposta.GridCancelar = payload.GridCancelar;
        resposta.TodosAnexos = payload.TodosAnexos;
        resposta.RbClausula = payload.RbClausula;
        resposta.TipoInconsistencia = payload.TipoInconsistencia;
        resposta.DataCancelamento = payload.DataCancelamento;
        resposta.AjusteConsideracoes = payload.AjusteConsideracoes;
        resposta.CodigoProcesso = payload.CodigoProcesso;
        resposta.CodigoEtapa = payload.CodigoEtapa;
        resposta.CodigoCiclo = payload.CodigoCiclo;

        return resposta;
    }
}
