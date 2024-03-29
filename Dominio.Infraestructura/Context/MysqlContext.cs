using Dominio.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Infraestructura.Context
{
    public class MysqlContext:DbContext 
    {
        public DbSet<user> user { get; set; }

        public MysqlContext(DbContextOptions<MysqlContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
            .HasKey(p => p.Id);
        }

    }
}
