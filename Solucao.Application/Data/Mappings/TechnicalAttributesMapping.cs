using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Data.Mappings
{
    public class TechnicalAttributesMapping : IEntityTypeConfiguration<TechnicalAttributes>
    {
        public void Configure(EntityTypeBuilder<TechnicalAttributes> builder)
        {
            builder.HasNoKey();

            builder.Property(c => c.Key)
                .HasColumnName("key")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnName("value")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}

