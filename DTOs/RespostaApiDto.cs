namespace APICancelaFaturamento.DTOs;

public class RespostaApiDto
{
    public string? CompanhiaSolicitante { get; set; }
    public string? AreaSolicitante { get; set; }
    public string? IdJde { get; set; }
    public string? NomeSolicitante { get; set; }
    public string? MotivoCancelamento { get; set; }
    public string? OrigemCancelamento { get; set; }
    public string? TipoLoja { get; set; }
    public string? Loja { get; set; }
    public string? CnpjLoja { get; set; }
    public string? CpfLoja { get; set; }
    public string? Luc { get; set; }
    public string? TipoFaturamento { get; set; }
    public string? Companhia { get; set; }
    public string? CodigoCompanha { get; set; }
    public string? CnpjCompanhia { get; set; }
    public string? AbrevCompanhia { get; set; }
    public List<GridCancelarDto>? GridCancelar { get; set; } = new();
    public List<TodosAnexosDto>? TodosAnexos { get; set; } = new();
    public string? RbClausula { get; set; }
    public string? TipoInconsistencia { get; set; }
    public DateTime? DataCancelamento { get; set; }
    public string? AjusteConsideracoes { get; set; }
    public string? CodigoProcesso { get; set; }
    public string? CodigoEtapa { get; set; }
    public string? CodigoCiclo { get; set; }
}
