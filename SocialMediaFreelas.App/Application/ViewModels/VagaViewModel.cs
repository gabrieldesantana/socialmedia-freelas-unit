public class VagaViewModel : IDefaultEntity
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Cargo { get; set; }
    public string Tipo { get; set; }
    public string Localizacao { get; set; }
    public string Status { get; set; }
    public double Remuneracao { get; set; }
    //public int FreelancerId { get; set; }

    public List<Freelancer>? Freelancers { get; set; }
    public int ClienteId { get; set; }
    public int UserId { get; set; }
}