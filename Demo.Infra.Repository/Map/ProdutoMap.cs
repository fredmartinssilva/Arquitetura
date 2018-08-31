using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Demo.Infra.Repository.Map
{
    public class ProdutoMap: EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("produto");

            Property(x => x.Id).HasColumnName("id");
            HasKey(x => x.Id);            
            Property(x => x.Nome).IsRequired().HasColumnName("nome").HasMaxLength(100);
            Property(x => x.Preco).IsRequired().HasColumnName("preco").HasPrecision(10, 2);
        }
    }
}
