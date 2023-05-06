using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    IdFilm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzasTrawania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPremiery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rezyseria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obsada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jezyk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrWiekowe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisDlugi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisKrotki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DostepneWersje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plakat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.IdFilm);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer = table.Column<int>(type: "int", nullable: false),
                    IloscRzedow = table.Column<int>(type: "int", nullable: false),
                    IloscMiejsc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Seanse",
                columns: table => new
                {
                    IdSeans = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmIdFilm = table.Column<int>(type: "int", nullable: false),
                    SalaIdSala = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WersjaJez = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanse", x => x.IdSeans);
                    table.ForeignKey(
                        name: "FK_Seanse_Filmy_FilmIdFilm",
                        column: x => x.FilmIdFilm,
                        principalTable: "Filmy",
                        principalColumn: "IdFilm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seanse_Sale_SalaIdSala",
                        column: x => x.SalaIdSala,
                        principalTable: "Sale",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miejsca",
                columns: table => new
                {
                    IdMiejsce = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rzad = table.Column<int>(type: "int", nullable: false),
                    CzyZajete = table.Column<bool>(type: "bit", nullable: false),
                    SeansIdSeans = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca", x => x.IdMiejsce);
                    table.ForeignKey(
                        name: "FK_Miejsca_Seanse_SeansIdSeans",
                        column: x => x.SeansIdSeans,
                        principalTable: "Seanse",
                        principalColumn: "IdSeans",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platnosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeansIdSeans = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienie);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Seanse_SeansIdSeans",
                        column: x => x.SeansIdSeans,
                        principalTable: "Seanse",
                        principalColumn: "IdSeans",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilety",
                columns: table => new
                {
                    IdBilet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    MiejsceIdMiejsce = table.Column<int>(type: "int", nullable: false),
                    ZamowienieIdZamowienie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilety", x => x.IdBilet);
                    table.ForeignKey(
                        name: "FK_Bilety_Miejsca_MiejsceIdMiejsce",
                        column: x => x.MiejsceIdMiejsce,
                        principalTable: "Miejsca",
                        principalColumn: "IdMiejsce",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilety_Zamowienia_ZamowienieIdZamowienie",
                        column: x => x.ZamowienieIdZamowienie,
                        principalTable: "Zamowienia",
                        principalColumn: "IdZamowienie",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilety_MiejsceIdMiejsce",
                table: "Bilety",
                column: "MiejsceIdMiejsce");

            migrationBuilder.CreateIndex(
                name: "IX_Bilety_ZamowienieIdZamowienie",
                table: "Bilety",
                column: "ZamowienieIdZamowienie");

            migrationBuilder.CreateIndex(
                name: "IX_Miejsca_SeansIdSeans",
                table: "Miejsca",
                column: "SeansIdSeans");

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_FilmIdFilm",
                table: "Seanse",
                column: "FilmIdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_SalaIdSala",
                table: "Seanse",
                column: "SalaIdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_SeansIdSeans",
                table: "Zamowienia",
                column: "SeansIdSeans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilety");

            migrationBuilder.DropTable(
                name: "Miejsca");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Seanse");

            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
