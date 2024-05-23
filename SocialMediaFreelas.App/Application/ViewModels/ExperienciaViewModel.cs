public class ExperienciaViewModel : IDefaultEntity
{
    public int Id { get; set; }
    public int FreelancerId { get; set; }
    public string Projeto { get; set; }
    public string Empresa { get; set; }
    public string Tecnologia { get; set; }
    public decimal Valor { get; set; }
    public int Avaliacao { get; set; }
}