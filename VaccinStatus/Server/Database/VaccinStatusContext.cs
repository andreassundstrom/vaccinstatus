using Microsoft.EntityFrameworkCore;
using VaccinStatus.Shared;
using VaccinStatus.Shared.Statistik;

namespace VaccinStatus.Server.Database
{
    public class VaccinStatusContext : DbContext
    {
        public VaccinStatusContext(DbContextOptions<VaccinStatusContext> options)
            : base(options)
        {

        }

        public DbSet<Leverantör> Leverantörer { get; set; }
        public DbSet<Förbrukning> Förbrukning { get; set; }
        public DbSet<Inleverans> Inleverans { get; set; }
        public DbSet<Leverantör> Leverantör { get; set; }
        public DbSet<Beställning> Beställning { get; set; }
        public DbSet<Lagersaldo> Lagersaldo { get; set; }
        public DbSet<Kapacitet> Kapacitet { get; set; }
        public DbSet<Vårdgivare> Vårdgivare { get; set; }
        public DbSet<Rapporteringsöversikt> Rapporteringsöversikt { get; set; }
        public DbSet<Kapacitetsstatus> Kapacitetsstatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rapporteringsöversikt>().HasNoKey();
            modelBuilder.Entity<Rapporteringsöversikt>().ToView("Rapporteringsöversikt");

            modelBuilder.Entity<Kapacitetsstatus>().HasNoKey();
            modelBuilder.Entity<Kapacitetsstatus>().ToView("Kapacitetsstatus");
        }
    }
}
