using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("TB_Clientes");

        builder.Property(x => x.NumeroDocumento).IsRequired();
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.DataNascimento).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Telefone).IsRequired();
        builder.Property(x => x.Senha).IsRequired();
        builder.Property(x => x.Sobre);

        //public List<Vaga>? Vagas { get; private set; }

        // builder.HasMany(x => x.Vagas)
        // .WithOne()
        // .HasForeignKey(x => x.Id)
        // .OnDelete(DeleteBehavior.Cascade);
    }
}