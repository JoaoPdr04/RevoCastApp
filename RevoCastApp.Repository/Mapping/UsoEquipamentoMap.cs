using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class UsoEquipamentoMap : IEntityTypeConfiguration<UsoEquipamento>
    {
        public void Configure(EntityTypeBuilder<UsoEquipamento> builder)
        {
            builder.ToTable("UsoDeEquipamento");
            builder.HasKey(ue => ue.Id);

            builder.Property(ue => ue.observacao).HasMaxLength(150);

            builder.HasOne(ue => ue.equipamento)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ue => ue.episodio)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
