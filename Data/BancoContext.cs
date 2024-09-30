using Microsoft.EntityFrameworkCore;
using projeto_cinema.Models;

namespace projeto_cinema.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<LocaisModel> Locais { get; set; } 
        public DbSet<EventosModel> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventosModel>()
                .HasOne(e => e.Local)
                .WithMany(l => l.Eventos)
                .HasForeignKey(e => e.LocalId)
                .IsRequired(); // Define o relacionamento como obrigatório
        }
    }
}
