public class Vaga : BaseEntity
{
    public Vaga(string titulo, string descricao, string cargo, string tipo, decimal remuneracao, int clienteId = 0, int freelancerId = 0)
    {
        Titulo = titulo;
        Descricao = descricao;
        Cargo = cargo;
        Tipo = tipo;
        Remuneracao = remuneracao;
        FreelancerId = freelancerId;
        ClienteId = clienteId;
    }

    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Cargo { get; private set; }
    public string Tipo { get; private set; }
    public decimal Remuneracao { get; private set; }
    public int FreelancerId { get; private set; }
    public int ClienteId { get; private set; }
    public virtual Freelancer Freelancer { get; private set; }
    public virtual Cliente Cliente { get; private set; }
}