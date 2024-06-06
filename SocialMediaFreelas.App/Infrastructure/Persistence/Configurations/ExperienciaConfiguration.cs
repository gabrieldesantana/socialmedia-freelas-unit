using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExperienciaConfiguration : IEntityTypeConfiguration<Experiencia>
{
    public void Configure(EntityTypeBuilder<Experiencia> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("TB_Experiencias");

        builder.Property(x => x.Projeto).IsRequired();
        builder.Property(x => x.Empresa).IsRequired();
        builder.Property(x => x.Tecnologia).IsRequired();
        builder.Property(x => x.Valor).IsRequired();
        builder.Property(x => x.Avaliacao).IsRequired();

        builder.HasOne(x => x.Freelancer)
        .WithMany(f => f.Experiencias)
        .HasForeignKey(x => x.FreelancerId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}