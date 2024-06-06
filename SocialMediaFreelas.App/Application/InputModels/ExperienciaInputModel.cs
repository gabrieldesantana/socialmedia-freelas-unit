public class ExperienciaInputModel 
{
    public string Projeto { get; set; }
    public string Empresa { get; set; }
    public string Tecnologia { get; set; }
    public double Valor { get; set; }
    public int Avaliacao { get; set; }
    public int FreelancerId { get; set; }
    public int FreelancerIdByString { get; set; }

    public string? TenantIdOwner { get; set; }

    public List<FreelancerViewModel>? Freelancers { get; set; }
}