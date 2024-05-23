using System.ComponentModel.DataAnnotations;

public class ClienteUpdateModel
{
    public string Nome { get; set; }
    public string NumeroDocumento { get; set; }
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}