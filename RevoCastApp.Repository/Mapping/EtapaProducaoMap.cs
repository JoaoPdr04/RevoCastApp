using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class EtapaProducaoMap : IEntityTypeConfiguration<EtapaProducao>
    {
        public void Configure(EntityTypeBuilder<EtapaProducao> builder)
        {
            builder.ToTable("EtapaDeProducao");
            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.etapa).IsRequired().HasMaxLength(50);
            builder.Property(ep => ep.ordem).IsRequired();
        }
    }
}
