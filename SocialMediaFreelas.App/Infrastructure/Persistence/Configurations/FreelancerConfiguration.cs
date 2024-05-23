using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
{
    public void Configure(EntityTypeBuilder<Freelancer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("TB_Freelancers");
        builder.Property(x => x.NumeroDocumento).IsRequired();
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.DataNascimento).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Telefone).IsRequired();
        builder.Property(x => x.Senha).IsRequired();
        builder.Property(x => x.PretensaoSalarial);

        // public List<Experiencia>? Experiencias { get; private set; }

        // builder.HasMany(x => x.Experiencias)
        // .WithOne()
        // .HasForeignKey(x => x.Id)
        // .OnDelete(DeleteBehavior.Cascade);
    }
}