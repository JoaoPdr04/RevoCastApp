using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class EpisodioMap : IEntityTypeConfiguration<Episodio>
    {
        public void Configure(EntityTypeBuilder<Episodio> builder)
        {
            builder.ToTable("Episodio");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.numero_ep).IsRequired();
            builder.Property(e => e.titulo).IsRequired().HasMaxLength(150);
            builder.Property(e => e.descricao).HasMaxLength(500);
            builder.Property(e => e.formato).IsRequired().HasMaxLength(50);
            builder.Property(e => e.status).IsRequired().HasMaxLength(50);
            builder.Property(e => e.data_gravacao).IsRequired();

            builder.HasMany(x => x.EquipeEpisodios)
                 .WithOne(x => x.episodio)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}