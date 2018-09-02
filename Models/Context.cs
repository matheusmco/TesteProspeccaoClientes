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

        // private static bool _created = false;
        // public Context()
        // {
        //     if (!_created)
        //     {
        //         _created = true;
        //         Database.EnsureDeleted();
        //         Database.EnsureCreated();
        //     }
        // }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        // {
        //     optionbuilder.UseSqlite(@"Data Source=d:\Sample.db");
        // }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ServicoModel> ServicoModel { get; set; }
    }
}