using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinStatus.Server.Migrations
{
    public partial class Statistik2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE VIEW dbo.Kapacitetsstatus AS 
WITH CTE AS(
SELECT 
	Vårdgivare.VårdgivareId,
	Vårdgivare.Namn,
	Kapacitet.KapacitetDoser,
	Kapacitet.Kapacitetsdatum,
	ROW_NUMBER() OVER (PARTITION BY Vårdgivare.VårdgivareId ORDER BY Kapacitet.Kapacitetsdatum DESC) NR
FROM dbo.Vårdgivare Vårdgivare
LEFT JOIN dbo.Kapacitet Kapacitet
ON Vårdgivare.VårdgivareId = Kapacitet.VårdgivareId AND CONVERT(DATE,Kapacitet.Kapacitetsdatum) <= GETDATE()	
)
SELECT
	CTE.VårdgivareId,
	CTE.Namn Vårdgivare,
	CTE.KapacitetDoser,
	CONVERT(DATE,CTE.Kapacitetsdatum) Kapacitetsdatum
FROM CTE 
WHERE 
	NR = 1
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.Kapacitetsstatus");
        }
    }
}
