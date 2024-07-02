
using Trabalho.API.Trabalho.Dominio;

public class LoteCliente : EntidadeBase
{
    public required Lote Lote { get; set; }
    public int LoteId { get; set; }
    public required Cliente Cliente { get; set; }
    public int ClienteId { get; set; }
}