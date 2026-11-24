using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class ParticipacaoConvidadoMap : IEntityTypeConfiguration<ParticipacaoConvidado>
    {
        public void Configure(EntityTypeBuilder<ParticipacaoConvidado> builder)
        {
            builder.ToTable("ParticipacaoDoConvidado");
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.confirmado).IsRequired();
            builder.Property(pc => pc.status).IsRequired();
            builder.Property(pc => pc.tema_abordado).IsRequired().HasMaxLength(100);

            builder.HasOne(pc => pc.episodio)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.convidado)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
