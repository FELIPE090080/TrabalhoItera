using Trabalho.API.Trabalho.Dominio;

public class Lote : EntidadeBase
{
    #region Atributos
    private string _rua;
    private int _numero;
    private decimal _valor;
    private int _tamanho;
    #endregion

    #region Propriedades
    public string Rua 
    {
        get { return _rua; }
        set 
        {
            if( string.IsNullOrEmpty(value) == null )
            {
                throw new Exception("Nome da Rua Inválido");
            }

            _rua = value;
        }
    }

    public int Tamanho
    {
        get { return _tamanho; }
        set
        {
            if (_tamanho <= 0)
            {
                throw new Exception("Tamanho Inválido");
            }

            _tamanho = value;
        }
    }
    public int Numero 
    {
        get { return _numero; }
        set
        {
            if (_numero < 0)
            {
                throw new Exception("Número Inválido");
            }

            _numero = (int)value;
        }
    }
    public decimal Valor 
    {
        get { return _valor; }
        set
        {
            if (_valor <= 0)
            {
                throw new Exception("Valor Inválido");
            }

            _valor = value;
        }
    }
    public bool Disponivel { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    #endregion

    #region Construtores
    public Lote() {}

    public Lote( string rua, int numero, decimal valor, int tamanho )
    {
        _rua = rua;
        _numero = numero;
        _valor = valor;
        _tamanho = tamanho;
        Disponivel = true;
    }
    #endregion

    #region Metodos
    public void AlterarValor(decimal novoValor)
    {
        Valor = novoValor;
    }

    public void DeletarDisponibilidade()
    {
        Disponivel = false;
    }

    public void RestaurarDisponibilidade()
    {
        Disponivel = true;
    }
    #endregion
}