using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinStatus.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leverantör",
                columns: table => new
                {
                    LeverantörId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverantör", x => x.LeverantörId);
                });

            migrationBuilder.CreateTable(
                name: "Vårdgivare",
                columns: table => new
                {
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vårdgivare", x => x.VårdgivareId);
                });

            migrationBuilder.CreateTable(
                name: "Beställning",
                columns: table => new
                {
                    BeställningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beställningsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÖnskatLeveransdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KvantitetDos = table.Column<int>(type: "int", nullable: false),
                    GlnMottagare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beställning", x => x.BeställningId);
                    table.ForeignKey(
                        name: "FK_Beställning_Vårdgivare_VårdgivareId",
                        column: x => x.VårdgivareId,
                        principalTable: "Vårdgivare",
                        principalColumn: "VårdgivareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Förbrukning",
                columns: table => new
                {
                    FörbrukningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeverantörId = table.Column<int>(type: "int", nullable: false),
                    KvantitetVial = table.Column<int>(type: "int", nullable: false),
                    Förburkningsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistreradDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistreradAv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Förbrukning", x => x.FörbrukningId);
                    table.ForeignKey(
                        name: "FK_Förbrukning_Leverantör_LeverantörId",
                        column: x => x.LeverantörId,
                        principalTable: "Leverantör",
                        principalColumn: "LeverantörId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Förbrukning_Vårdgivare_VårdgivareId",
                        column: x => x.VårdgivareId,
                        principalTable: "Vårdgivare",
                        principalColumn: "VårdgivareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inleverans",
                columns: table => new
                {
                    InleveransId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneratLeveransdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Leveransdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Levererad = table.Column<bool>(type: "bit", nullable: true),
                    LeverantörId = table.Column<int>(type: "int", nullable: false),
                    KvantitetVial = table.Column<int>(type: "int", nullable: false),
                    GlnMottagare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inleverans", x => x.InleveransId);
                    table.ForeignKey(
                        name: "FK_Inleverans_Vårdgivare_VårdgivareId",
                        column: x => x.VårdgivareId,
                        principalTable: "Vårdgivare",
                        principalColumn: "VårdgivareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kapacitet",
                columns: table => new
                {
                    KapacitetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kapacitetsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KapacitetDoser = table.Column<int>(type: "int", nullable: false),
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kapacitet", x => x.KapacitetId);
                    table.ForeignKey(
                        name: "FK_Kapacitet_Vårdgivare_VårdgivareId",
                        column: x => x.VårdgivareId,
                        principalTable: "Vårdgivare",
                        principalColumn: "VårdgivareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lagersaldo",
                columns: table => new
                {
                    LagersaldoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeverantörId = table.Column<int>(type: "int", nullable: false),
                    KvantitetVial = table.Column<int>(type: "int", nullable: false),
                    KvantitetDos = table.Column<int>(type: "int", nullable: false),
                    VårdgivareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagersaldo", x => x.LagersaldoId);
                    table.ForeignKey(
                        name: "FK_Lagersaldo_Leverantör_LeverantörId",
                        column: x => x.LeverantörId,
                        principalTable: "Leverantör",
                        principalColumn: "LeverantörId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lagersaldo_Vårdgivare_VårdgivareId",
                        column: x => x.VårdgivareId,
                        principalTable: "Vårdgivare",
                        principalColumn: "VårdgivareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beställning_VårdgivareId",
                table: "Beställning",
                column: "VårdgivareId");

            migrationBuilder.CreateIndex(
                name: "IX_Förbrukning_LeverantörId",
                table: "Förbrukning",
                column: "LeverantörId");

            migrationBuilder.CreateIndex(
                name: "IX_Förbrukning_VårdgivareId",
                table: "Förbrukning",
                column: "VårdgivareId");

            migrationBuilder.CreateIndex(
                name: "IX_Inleverans_VårdgivareId",
                table: "Inleverans",
                column: "VårdgivareId");

            migrationBuilder.CreateIndex(
                name: "IX_Kapacitet_VårdgivareId",
                table: "Kapacitet",
                column: "VårdgivareId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagersaldo_LeverantörId",
                table: "Lagersaldo",
                column: "LeverantörId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagersaldo_VårdgivareId",
                table: "Lagersaldo",
                column: "VårdgivareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beställning");

            migrationBuilder.DropTable(
                name: "Förbrukning");

            migrationBuilder.DropTable(
                name: "Inleverans");

            migrationBuilder.DropTable(
                name: "Kapacitet");

            migrationBuilder.DropTable(
                name: "Lagersaldo");

            migrationBuilder.DropTable(
                name: "Leverantör");

            migrationBuilder.DropTable(
                name: "Vårdgivare");
        }
    }
}
