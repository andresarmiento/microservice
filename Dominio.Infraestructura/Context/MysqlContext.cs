using Dominio.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Infraestructura.Context
{
    public class MysqlContext : DbContext
    {
        public DbSet<user> user { get; set; }
        private readonly string _connectionString;

        public MysqlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
            .HasKey(p => p.Id);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseMySQL(_connectionString);
            }
        }

        public bool Validate()
        {
            return this.Database.CanConnect();
        }

    }
}
