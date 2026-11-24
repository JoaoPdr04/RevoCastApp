using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class CorteMap : IEntityTypeConfiguration<Corte>
    {
        public void Configure(EntityTypeBuilder<Corte> builder)
        {
            builder.ToTable("Corte");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.titulo).IsRequired().HasMaxLength(150);
            builder.Property(c => c.status).IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.episodio)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.membro).WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
