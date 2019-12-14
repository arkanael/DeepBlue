using DeepBlue.Domain.Entities;
using DeepBlue.Infraestructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DeepBlue.Infraestructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
