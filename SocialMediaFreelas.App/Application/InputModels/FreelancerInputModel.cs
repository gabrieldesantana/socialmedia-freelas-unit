using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class FreelancerInputModel 
{
    [Required(ErrorMessage = "Campo obrigátorio")]
    [DisplayName("CPF")]
    public string? NumeroDocumento { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio")]
    [DisplayName("Nome Completo")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio")]
    [DisplayName("Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio")]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio")]
    public string? Senha { get; set; }

    public double PretensaoSalarial { get; set; }
}
