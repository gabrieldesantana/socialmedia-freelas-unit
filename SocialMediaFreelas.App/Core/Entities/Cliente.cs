using System.ComponentModel.DataAnnotations;

public class Cliente : BaseEntity
{
    public Cliente(string numeroDocumento, string nome, string sobre, DateTime dataNascimento, string email, string telefone)
    {
        Nome = nome;
        NumeroDocumento = numeroDocumento;
        DataNascimento = dataNascimento;
        Email = email;
        Telefone = telefone;
        Vagas = new List<Vaga>();
        Sobre = sobre;
    }

    public string NumeroDocumento { get; private set; }
    public string Nome { get; private set; }

    public string Sobre { get; private set; }

    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Senha { get; private set; }

    public List<Vaga>? Vagas { get; private set; }

    public bool ValidPassword(string senha)
    {
        return Senha == senha.GenerateHash();
    }

    public void SetPasswordHash(string senha)
    {
        Senha = senha.GenerateHash();
    }
}