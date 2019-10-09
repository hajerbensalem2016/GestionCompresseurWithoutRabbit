using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviCompresseur.GestionFournisseur.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurID = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}
