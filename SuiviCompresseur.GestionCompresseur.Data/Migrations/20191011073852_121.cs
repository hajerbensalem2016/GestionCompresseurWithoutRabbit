using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviCompresseur.GestionCompresseur.Data.Migrations
{
    public partial class _121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TSécheurC",
                table: "Fiche_Suivis",
                newName: "TSecheurC");

            migrationBuilder.RenameColumn(
                name: "FréquenceEentretienDeshuileur",
                table: "Fiche_Suivis",
                newName: "FrequenceEentretienDeshuileur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TSecheurC",
                table: "Fiche_Suivis",
                newName: "TSécheurC");

            migrationBuilder.RenameColumn(
                name: "FrequenceEentretienDeshuileur",
                table: "Fiche_Suivis",
                newName: "FréquenceEentretienDeshuileur");
        }
    }
}
