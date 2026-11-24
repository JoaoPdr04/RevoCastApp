using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class ConvidadoMap : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.ToTable("Convidado");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.nome).IsRequired().HasMaxLength(100);
            //da pra pensar em outras formas de contato...
            builder.Property(c => c.email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.especialidade).HasMaxLength(50);
            builder.Property(c => c.vinculo_institucional).HasMaxLength(100);
        }
    }
}
