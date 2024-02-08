using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Data.Mappings
{
    public class ModelMapping : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.ModelFileName)
                .HasColumnType("varchar(50)")
                .HasColumnName("modelFileName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.EquipamentId)
                .HasColumnName("equipamentId");

            builder.Property(c => c.Active)
                .HasColumnType("bit")
                .HasColumnName("active")
                .IsRequired();
        }
    }
}

