using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("TB_Vagas");

        builder.Property(x => x.Titulo).IsRequired();
        builder.Property(x => x.Descricao).IsRequired();
        builder.Property(x => x.Cargo).IsRequired();
        builder.Property(x => x.Tipo).IsRequired();
        builder.Property(x => x.Remuneracao).IsRequired();

        //public int FreelancerId { get; private set; }
        //public int ClienteId { get; private set; }

        builder
        .HasMany(x => x.Freelancers)
        .WithMany(x => x.Vagas);

        builder.HasOne(x => x.Cliente)
        .WithMany(x => x.Vagas)
        .HasForeignKey(x => x.ClienteId)
        .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(e => e.Freelancers)
        //.WithMany(e => e.Vagas)
        //.UsingEntity(
        //    "VagaFreelancer",
        //    l => l.HasOne(typeof(Freelancer)).WithMany().HasForeignKey("FreelancersId").HasPrincipalKey(nameof(Freelancer.Id)),
        //    r => r.HasOne(typeof(Vaga)).WithMany().HasForeignKey("VagasId").HasPrincipalKey(nameof(Vaga.Id)),
        //    j => j.HasKey("VagasId", "FreelancersId"));
    }
}