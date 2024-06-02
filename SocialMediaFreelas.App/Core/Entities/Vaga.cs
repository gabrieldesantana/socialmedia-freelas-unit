public class Vaga : BaseEntity
{
    public Vaga(string titulo, string descricao, string cargo, string tipo, string localizacao, string status, double remuneracao, int clienteId = 0)
    {
        Titulo = titulo;
        Descricao = descricao;
        Cargo = cargo;
        Tipo = tipo;
        Localizacao = localizacao;
        Status = status;
        Remuneracao = remuneracao;
        ClienteId = clienteId;
        Freelancers = new List<Freelancer?>();
    }

    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Cargo { get; private set; }
    public string Tipo { get; private set; }
    public string Localizacao { get; private set; }
    public string Status { get; private set; }
    public double Remuneracao { get ; private set; }
    public int ClienteId { get; private set; }
    public virtual List<Freelancer?> Freelancers { get; set; }
    public virtual Cliente Cliente { get; private set; }

    public void CadastrarFreelancer(Freelancer freelancer) 
    {
        Freelancers.Add(freelancer);
    }
}