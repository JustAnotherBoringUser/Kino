using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "IdFilm", "CzasTrawania", "DataPremiery", "DostepneWersje", "Gatunek", "Jezyk", "Kraj", "Obsada", "OgrWiekowe", "OpisDlugi", "OpisKrotki", "Plakat", "Rezyseria", "Tytul" },
                values: new object[] { 1, "02:00:00", new DateTime(2008, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "dsfds", "Wojenny", "Ang", "USA", "ssdsd", "PEGI", "Fdsfsdfdsfsd", "fdfdfddf", "dfjsfdsfds", "Ktos tam", "Za linią wroga" });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "IdSala", "IloscMiejsc", "IloscRzedow", "Numer" },
                values: new object[,]
                {
                    { 1, 30, 5, 1 },
                    { 2, 100, 30, 2 },
                    { 3, 80, 28, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 3);
        }
    }
}
