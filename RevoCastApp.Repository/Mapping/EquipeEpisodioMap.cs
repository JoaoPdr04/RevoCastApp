using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class EquipeEpisodioMap : IEntityTypeConfiguration<EquipeEpisodio>
    {
        public void Configure(EntityTypeBuilder<EquipeEpisodio> builder)
        {
            builder.ToTable("EquipeDoEpisodio");
            builder.HasKey(ee => ee.Id);

            builder.Property(ee => ee.funcao).IsRequired().HasMaxLength(50);

            builder.HasOne(ee => ee.episodio)
                   .WithMany(e => e.EquipeEpisodios)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ee => ee.membro)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}