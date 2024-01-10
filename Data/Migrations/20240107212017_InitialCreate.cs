using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMediiProgramare.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarTel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Masina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducatorID = table.Column<int>(type: "int", nullable: true),
                    An = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LocatieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Masina_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Masina_Locatie_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locatie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Masina_Producator_ProducatorID",
                        column: x => x.ProducatorID,
                        principalTable: "Producator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Inchiriere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    MasinaID = table.Column<int>(type: "int", nullable: true),
                    DataProgramarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inchiriere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inchiriere_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Inchiriere_Masina_MasinaID",
                        column: x => x.MasinaID,
                        principalTable: "Masina",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inchiriere_ClientID",
                table: "Inchiriere",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Inchiriere_MasinaID",
                table: "Inchiriere",
                column: "MasinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Masina_CategorieID",
                table: "Masina",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Masina_LocatieID",
                table: "Masina",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Masina_ProducatorID",
                table: "Masina",
                column: "ProducatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inchiriere");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Masina");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Locatie");

            migrationBuilder.DropTable(
                name: "Producator");
        }
    }
}
