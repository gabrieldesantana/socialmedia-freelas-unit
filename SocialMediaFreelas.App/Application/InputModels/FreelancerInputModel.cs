using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class FreelancerInputModel 
{
    [Required(ErrorMessage = "Campo obrig�torio")]
    [DisplayName("CPF")]
    public string? NumeroDocumento { get; set; }

    [Required(ErrorMessage = "Campo obrig�torio")]
    [DisplayName("Nome Completo")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrig�torio")]
    [DisplayName("Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Campo obrig�torio")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Campo obrig�torio")]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrig�torio")]
    public string? Senha { get; set; }

    public double PretensaoSalarial { get; set; }
}
