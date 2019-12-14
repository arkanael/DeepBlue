using DeepBlue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepBlue.Infraestructure.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(75)")
                .IsRequired();

            builder.Property(x => x.Sobrenome)
               .HasColumnName("Sobrenome")
               .HasColumnType("varchar(75)")
               .IsRequired();


        }
    }
}
