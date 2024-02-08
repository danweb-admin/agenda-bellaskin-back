using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Data.Mappings
{
    public class AttributeTypesMapping : IEntityTypeConfiguration<AttributeTypes>
    {
        public void Configure(EntityTypeBuilder<AttributeTypes> builder)
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

