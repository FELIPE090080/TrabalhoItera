using Trabalho.API.Trabalho.Dominio;

public class Cliente : EntidadeBase
{
    #region Atributos
    private string _nome;
    private string _email;
    private string _senha;
    #endregion

    #region Propriedades
    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Nome Inválido");
            }

            _nome = value;
        }
    }
    public string Senha
    {
        get { return _senha; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Senha Inválida");
            }

            _senha = value;
        }
    }
    public string Email
    {
        get { return _email; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Email Inválido");
            }

            _email = value;
        }
    }

    public List<Lote> Lotes { get; set; }
    public bool Ativo { get; set; }
    #endregion

    #region Construtores
    public Cliente() { }
    public Cliente(string nome, string email, string senha)
    {
        _nome = nome;
        _email = email;
        _senha = senha;
        Ativo = true;
    }
    #endregion

    #region Metodos
    public void AlterarSenha(string novaSenha)
    {
        Senha = novaSenha;
    }
    public void Deletar()
    {
        Ativo = false;
    }
    public void Restaurar()
    {
        Ativo = true;
    }
    #endregion
}