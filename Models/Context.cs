using Microsoft.EntityFrameworkCore;

namespace TesteTria.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().HasKey(m => m.ClienteId);
            modelBuilder.Entity<ServicoModel>().HasKey(m => m.ServicoId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ServicoModel> ServicoModel { get; set; }
    }
}