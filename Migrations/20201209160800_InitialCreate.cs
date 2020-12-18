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
                    uniteLegaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prenom_usuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomenclature_activité_principale = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteLegale", x => x.uniteLegaleId);
                });

            migrationBuilder.CreateTable(
                name: "Etablissement",
                columns: table => new
                {
                    etablissementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    denomination_usuelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activite_principale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelle_voie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelle_commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unite_legaleuniteLegaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissement", x => x.etablissementId);
                    table.ForeignKey(
                        name: "FK_Etablissement_UniteLegale_unite_legaleuniteLegaleId",
                        column: x => x.unite_legaleuniteLegaleId,
                        principalTable: "UniteLegale",
                        principalColumn: "uniteLegaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etablissement_unite_legaleuniteLegaleId",
                table: "Etablissement",
                column: "unite_legaleuniteLegaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etablissement");

            migrationBuilder.DropTable(
                name: "UniteLegale");
        }
    }
}
