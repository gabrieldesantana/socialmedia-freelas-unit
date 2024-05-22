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

        builder.HasOne(x => x.Freelancer)
        .WithOne()
        .HasForeignKey<Vaga>(x => x.FreelancerId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Cliente)
        .WithOne()
        .HasForeignKey<Vaga>(x => x.ClienteId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}