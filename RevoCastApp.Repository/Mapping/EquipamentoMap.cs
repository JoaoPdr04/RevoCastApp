using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("Equipamento");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.nome).IsRequired().HasMaxLength(100);
            builder.Property(e => e.categoria).IsRequired().HasMaxLength(50);
            builder.Property(e => e.local_armazenamento).IsRequired().HasMaxLength(50);
            builder.Property(e => e.patrimonio).HasMaxLength(50);
            //talvez não precise deste item...
            builder.Property(e => e.status).HasMaxLength(50);

        }
    }
}
