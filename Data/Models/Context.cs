using Microsoft.EntityFrameworkCore;

namespace TesteProspeccaoClientes.Data.Models
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
            modelBuilder.Entity<ClienteServicoModel>().HasKey(m => new { m.ClienteId, m.ServicoId });
            modelBuilder.Entity<ClienteServicoModel>().HasOne(m => m.Cliente).WithMany(e => e.ClienteServico).HasForeignKey(m => m.ClienteId);
            modelBuilder.Entity<ClienteServicoModel>().HasOne(m => m.Servico).WithMany(e => e.ClienteServico).HasForeignKey(m => m.ServicoId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
        public DbSet<ClienteServicoModel> ClientesServicos { get; set; }
    }
}