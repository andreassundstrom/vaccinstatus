using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinStatus.Server.Migrations
{
    public partial class Statistik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.Rapporteringsöversikt AS
SELECT 
	Vårdgivare.VårdgivareId,
	Vårdgivare.Namn Vårdgivare,
	COUNT(DISTINCT Beställning.BeställningId) [Beställning],
	COUNT(DISTINCT Förbrukning.FörbrukningId) [Förbrukning],
	COUNT(DISTINCT Inleverans.InleveransId) [Inleverans],
	COUNT(DISTINCT Kapacitet.KapacitetId) Kapacitet,
	COUNT(DISTINCT Lagersaldo.LagersaldoId) Lagersaldo
FROM dbo.Vårdgivare Vårdgivare
LEFT JOIN dbo.Beställning Beställning
ON Beställning.VårdgivareId = Vårdgivare.VårdgivareId
LEFT JOIN dbo.Förbrukning Förbrukning
ON Vårdgivare.VårdgivareId = Förbrukning.VårdgivareId
LEFT JOIN dbo.Inleverans Inleverans
ON Inleverans.VårdgivareId = Vårdgivare.VårdgivareId
LEFT JOIN dbo.Kapacitet Kapacitet
ON Kapacitet.VårdgivareId = Vårdgivare.VårdgivareId
LEFT JOIN dbo.Lagersaldo Lagersaldo
ON Lagersaldo.VårdgivareId = Vårdgivare.VårdgivareId
GROUP BY Vårdgivare.VårdgivareId,Vårdgivare.Namn
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.Rapporteringsöversikt");
        }
    }
}
