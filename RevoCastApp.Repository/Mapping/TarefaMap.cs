using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.prazo).IsRequired();
            builder.Property(t => t.descricao).IsRequired().HasMaxLength(150);
            builder.Property(t => t.data_conclusao);
            builder.Property(t => t.status).IsRequired();


            builder.HasOne(t => t.etapa).WithMany()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.episodio)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.membro)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}