namespace APICancelaFaturamento.Models;

public class PayloadResposta
{
    public string Status { get; set; } = "sucesso";
    public string Mensagem { get; set; } = "Requisição recebida com sucesso.";
    public string CodigoOperacao { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpperInvariant();
    public DateTime DataProcessamento { get; set; } = DateTime.UtcNow;
    public string Origem { get; set; } = "APICancelaFaturamento";
    public PayloadRecebimento? DadosRecebidos { get; set; }
}
