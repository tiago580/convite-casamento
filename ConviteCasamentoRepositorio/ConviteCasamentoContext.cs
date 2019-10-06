using ConviteCasamentoDominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace ConviteCasamentoRepositorio
{
    public class ConviteCasamentoContext: DbContext
    {
        public ConviteCasamentoContext(DbContextOptions<ConviteCasamentoContext> options): base(options)
        {

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Convidado> Convidados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .Property(e => e.Id)
                .HasColumnName("EVENTO_ID");

            modelBuilder.Entity<Evento>()
                .HasKey(e => e.Id)
                .HasName("EVENTO_ID");

            modelBuilder.Entity<Convidado>()
                .Property(e => e.Id)
                .HasColumnName("CONVIDADO_ID");

            modelBuilder.Entity<Convidado>()
                .HasKey(e => e.Id)
                .HasName("CONVIDADO_ID");

            modelBuilder.Entity<Evento>()
                .HasMany(u => u.Convidados)
                .WithOne(n => n.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Convidado>()
                .HasOne(n => n.Evento)
                .WithMany(u => u.Convidados)
                .HasForeignKey(n => n.EventoId)
                .IsRequired();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tiago\source\repos\ConviteCasamento\database\convite-casamento.mdf;Integrated Security=True;Connect Timeout=30");
    }
}
