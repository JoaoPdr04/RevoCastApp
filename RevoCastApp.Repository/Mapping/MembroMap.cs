using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Mapping
{
    public class MembroMap : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membro");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.nome).IsRequired().HasMaxLength(150);
            builder.Property(m => m.curso).IsRequired().HasMaxLength(100);
            builder.Property(m => m.prontuario).IsRequired().HasMaxLength(20);
        }
    }
}
