public class Experiencia : BaseEntity
{
    public Experiencia(int freelancerId, string projeto, string empresa, string tecnologia, decimal valor, int avaliacao)
    {
        FreelancerId = freelancerId;
        Projeto = projeto;
        Empresa = empresa;
        Tecnologia = tecnologia;
        Valor = valor;
        Avaliacao = avaliacao;
    }

    public int FreelancerId { get; private set; }
    public virtual Freelancer Freelancer { get; private set; }
    public string Projeto { get; private set; }
    public string Empresa { get; private set; }
    public string Tecnologia { get; private set; }
    public decimal Valor { get; private set; }
    public int Avaliacao { get; private set; }
}