using Demo.Domain.Entities;
using Demo.Infra.Repository.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace Demo.Infra.Repository
{
    public class ArquiteturaContext: DbContext
    {
        public ArquiteturaContext() : base("Arquiterura") {
            Debug.WriteLine("Contexto Criado: " + GetHashCode());
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("Contexto Excluído: " + GetHashCode());
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Entity<Produto>().ToTable("produto");
            modelBuilder.Configurations.Add(new ProdutoMap());
            
            //O banco de dados PostgresSQL não teme auto-increment, tem SEQUENCES
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();

            //Remover a pluralização padrão do EF
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
