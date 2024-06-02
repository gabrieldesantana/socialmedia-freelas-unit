public class Freelancer : BaseEntity
{
    public Freelancer(string nome, string numeroDocumento, DateTime dataNascimento, string email, string telefone, string sobre, double pretensaoSalarial)
    {
        Nome = nome;
        NumeroDocumento = numeroDocumento;
        DataNascimento = dataNascimento;
        Email = email;
        Telefone = telefone;
        Sobre = sobre;
        PretensaoSalarial = pretensaoSalarial;
        Experiencias = new List<Experiencia>();
        Vagas = new List<Vaga>();
    }

    public string NumeroDocumento { get; private set; }
    public string Nome { get; private set; }

    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Senha { get; private set; }

    public string Sobre { get; private set; }

    public double PretensaoSalarial { get; private set; }

    public List<Vaga> Vagas { get; private set; }
    public List<Experiencia>? Experiencias { get; private set; }

    public bool ValidPassword(string senha)
    {
        return Senha == senha.GenerateHash();
    }

    public void SetPasswordHash(string senha)
    {
        Senha = senha.GenerateHash();
    }
}