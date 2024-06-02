using System.ComponentModel.DataAnnotations;

public class FreelancerViewModel : IDefaultEntity
{
    public int Id { get; set; }
    public string NumeroDocumento { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Sobre { get; set; }
    public double PretensaoSalarial { get; set; }
    public List<Experiencia> Experiencias { get; set; }
}
