namespace Trabalho.API;
public class ClienteDetalhado
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Lote> Lotes { get; set; }
    public bool Ativo { get; set; }
}