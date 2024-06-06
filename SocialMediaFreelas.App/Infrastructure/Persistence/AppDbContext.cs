

using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Experiencia> Experiencias { get; set; }
    public DbSet<Vaga> Vagas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SocialMediaFreelas.db");
    }
}