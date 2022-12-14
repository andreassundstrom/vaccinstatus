// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccinStatus.Server.Database;

#nullable disable

namespace VaccinStatus.Server.Migrations
{
    [DbContext(typeof(VaccinStatusContext))]
    [Migration("20221016114313_Statistik-2")]
    partial class Statistik2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VaccinStatus.Shared.Beställning", b =>
                {
                    b.Property<int>("BeställningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BeställningId"), 1L, 1);

                    b.Property<DateTime>("Beställningsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("GlnMottagare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KvantitetDos")
                        .HasColumnType("int");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ÖnskatLeveransdatum")
                        .HasColumnType("datetime2");

                    b.HasKey("BeställningId");

                    b.HasIndex("VårdgivareId");

                    b.ToTable("Beställning");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Förbrukning", b =>
                {
                    b.Property<int>("FörbrukningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FörbrukningId"), 1L, 1);

                    b.Property<DateTime>("Förburkningsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KvantitetVial")
                        .HasColumnType("int");

                    b.Property<int>("LeverantörId")
                        .HasColumnType("int");

                    b.Property<string>("RegistreradAv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistreradDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.HasKey("FörbrukningId");

                    b.HasIndex("LeverantörId");

                    b.HasIndex("VårdgivareId");

                    b.ToTable("Förbrukning");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Inleverans", b =>
                {
                    b.Property<int>("InleveransId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InleveransId"), 1L, 1);

                    b.Property<string>("GlnMottagare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KvantitetVial")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Leveransdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeverantörId")
                        .HasColumnType("int");

                    b.Property<bool?>("Levererad")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PlaneratLeveransdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.HasKey("InleveransId");

                    b.HasIndex("VårdgivareId");

                    b.ToTable("Inleverans");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Kapacitet", b =>
                {
                    b.Property<int>("KapacitetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KapacitetId"), 1L, 1);

                    b.Property<int>("KapacitetDoser")
                        .HasColumnType("int");

                    b.Property<DateTime>("Kapacitetsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.HasKey("KapacitetId");

                    b.HasIndex("VårdgivareId");

                    b.ToTable("Kapacitet");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Lagersaldo", b =>
                {
                    b.Property<int>("LagersaldoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LagersaldoId"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KvantitetDos")
                        .HasColumnType("int");

                    b.Property<int>("KvantitetVial")
                        .HasColumnType("int");

                    b.Property<int>("LeverantörId")
                        .HasColumnType("int");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.HasKey("LagersaldoId");

                    b.HasIndex("LeverantörId");

                    b.HasIndex("VårdgivareId");

                    b.ToTable("Lagersaldo");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Leverantör", b =>
                {
                    b.Property<int>("LeverantörId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeverantörId"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeverantörId");

                    b.ToTable("Leverantör");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Statistik.Rapporteringsöversikt", b =>
                {
                    b.Property<int>("Beställning")
                        .HasColumnType("int");

                    b.Property<int>("Förbrukning")
                        .HasColumnType("int");

                    b.Property<int>("Inleverans")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<int>("Lagersaldo")
                        .HasColumnType("int");

                    b.Property<string>("Vårdgivare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VårdgivareId")
                        .HasColumnType("int");

                    b.ToView("Rapporteringsöversikt");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Vårdgivare", b =>
                {
                    b.Property<int>("VårdgivareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VårdgivareId"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VårdgivareId");

                    b.ToTable("Vårdgivare");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Beställning", b =>
                {
                    b.HasOne("VaccinStatus.Shared.Vårdgivare", "Vårdgivare")
                        .WithMany()
                        .HasForeignKey("VårdgivareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vårdgivare");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Förbrukning", b =>
                {
                    b.HasOne("VaccinStatus.Shared.Leverantör", "Leverantör")
                        .WithMany()
                        .HasForeignKey("LeverantörId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccinStatus.Shared.Vårdgivare", "Vårdgivare")
                        .WithMany()
                        .HasForeignKey("VårdgivareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leverantör");

                    b.Navigation("Vårdgivare");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Inleverans", b =>
                {
                    b.HasOne("VaccinStatus.Shared.Vårdgivare", "Vårdgivare")
                        .WithMany()
                        .HasForeignKey("VårdgivareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vårdgivare");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Kapacitet", b =>
                {
                    b.HasOne("VaccinStatus.Shared.Vårdgivare", "Vårdgivare")
                        .WithMany()
                        .HasForeignKey("VårdgivareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vårdgivare");
                });

            modelBuilder.Entity("VaccinStatus.Shared.Lagersaldo", b =>
                {
                    b.HasOne("VaccinStatus.Shared.Leverantör", "Leverantör")
                        .WithMany()
                        .HasForeignKey("LeverantörId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccinStatus.Shared.Vårdgivare", "Vårdgivare")
                        .WithMany()
                        .HasForeignKey("VårdgivareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leverantör");

                    b.Navigation("Vårdgivare");
                });
#pragma warning restore 612, 618
        }
    }
}
