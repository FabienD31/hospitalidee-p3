using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospitalidée_CRM_Back_End.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniteLegale",
                columns: table => new
                {
                    UniteLegaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prenom_usuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomenclature_activité_principale = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteLegale", x => x.UniteLegaleId);
                });

            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    EtablissementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    denomination_usuelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activite_principale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelle_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelle_commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniteLegaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.EtablissementId);
                    table.ForeignKey(
                        name: "FK_Etablissements_UniteLegale_UniteLegaleId",
                        column: x => x.UniteLegaleId,
                        principalTable: "UniteLegale",
                        principalColumn: "UniteLegaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etablissements_UniteLegaleId",
                table: "Etablissements",
                column: "UniteLegaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etablissements");

            migrationBuilder.DropTable(
                name: "UniteLegale");
        }
    }
}
