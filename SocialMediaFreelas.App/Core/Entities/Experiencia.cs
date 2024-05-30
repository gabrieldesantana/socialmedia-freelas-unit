public class Experiencia : BaseEntity
{
    public Experiencia(string projeto, string empresa, string tecnologia, double valor, int avaliacao, int freelancerId = 0)
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
    public double Valor { get; private set; }
    public int Avaliacao { get; private set; }
}