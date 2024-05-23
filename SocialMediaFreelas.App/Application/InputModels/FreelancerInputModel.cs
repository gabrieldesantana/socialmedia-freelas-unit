using System.ComponentModel.DataAnnotations;

public class FreelancerInputModel 
{
    public string NumeroDocumento { get; set; }
    public string Nome { get; set; }
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public decimal PretensaoSalarial { get; set; }
}
