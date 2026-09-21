using System.Text.Json.Serialization;

namespace APICancelaFaturamento.DTOs;

public class RespostaApiDto
{
    [JsonPropertyName("chamado_id")]
    public string? ChamadoId { get; set; }

    [JsonPropertyName("resultados")]
    public List<ResultadoDto>? Resultados { get; set; } = new();

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("score")]
    public double? Score { get; set; }

    [JsonPropertyName("aprovado")]
    public bool? Aprovado { get; set; }

    [JsonPropertyName("documentos_extraidos")]
    public List<DocumentoExtraidoDto>? DocumentosExtraidos { get; set; } = new();

    [JsonPropertyName("sugestao_melhoria")]
    public SugestaoMelhoriaDto? SugestaoMelhoria { get; set; }
}

public class ResultadoDto
{
    [JsonPropertyName("numero_recibo")]
    public string? NumeroRecibo { get; set; }

    [JsonPropertyName("boleto_encontrado_vs")]
    public bool? BoletoEncontradoVs { get; set; }

    [JsonPropertyName("vs_indisponivel")]
    public bool? VsIndisponivel { get; set; }

    [JsonPropertyName("divergencias_vs")]
    public List<string>? DivergenciasVs { get; set; } = new();

    [JsonPropertyName("motor_de_regras")]
    public MotorDeRegrasDto? MotorDeRegras { get; set; }
}

public class MotorDeRegrasDto
{
    [JsonPropertyName("motivo_codigo")]
    public string? MotivoCodigo { get; set; }

    [JsonPropertyName("origem_codigo")]
    public string? OrigemCodigo { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("score")]
    public double? Score { get; set; }

    [JsonPropertyName("aprovado")]
    public bool? Aprovado { get; set; }

    [JsonPropertyName("detalhes")]
    public List<DetalheDto>? Detalhes { get; set; } = new();

    [JsonPropertyName("justificativa_pendencia")]
    public string? JustificativaPendencia { get; set; }
}

public class DetalheDto
{
    [JsonPropertyName("criterio")]
    public string? Criterio { get; set; }

    [JsonPropertyName("resultado")]
    public bool? Resultado { get; set; }

    [JsonPropertyName("peso")]
    public double? Peso { get; set; }

    [JsonPropertyName("origem")]
    public string? Origem { get; set; }

    [JsonPropertyName("justificativa")]
    public string? Justificativa { get; set; }

    [JsonPropertyName("documento")]
    public string? Documento { get; set; }

    [JsonPropertyName("pagina")]
    public int? Pagina { get; set; }
}

public class DocumentoExtraidoDto
{
    [JsonPropertyName("nome_arquivo")]
    public string? NomeArquivo { get; set; }

    [JsonPropertyName("paginas")]
    public List<string>? Paginas { get; set; } = new();
}

public class SugestaoMelhoriaDto
{
    [JsonPropertyName("mensagem")]
    public string? Mensagem { get; set; }

    [JsonPropertyName("pontuacao_conformidade")]
    public double? PontuacaoConformidade { get; set; }
}
