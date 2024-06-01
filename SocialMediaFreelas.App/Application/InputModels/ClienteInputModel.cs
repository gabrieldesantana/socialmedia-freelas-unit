using System.ComponentModel.DataAnnotations;

public class ClienteInputModel 
{
    public string Nome { get; set; }
    public string NumeroDocumento { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
}