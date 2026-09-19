namespace APICancelaFaturamento.Models;

public class PayloadRecebimento
{
    public string? IdPedido { get; set; }
    public string? Documento { get; set; }
    public string? NomeCliente { get; set; }
    public decimal? ValorTotal { get; set; }
    public string? Observacao { get; set; }
    public List<ItemPedido>? Itens { get; set; } = new();
}

public class ItemPedido
{
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}
