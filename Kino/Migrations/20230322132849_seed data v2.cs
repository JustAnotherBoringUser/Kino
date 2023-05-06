using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class seeddatav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Filmy_FilmIdFilm",
                table: "Seanse");

            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Sale_SalaIdSala",
                table: "Seanse");

            migrationBuilder.RenameColumn(
                name: "SalaIdSala",
                table: "Seanse",
                newName: "IdSala");

            migrationBuilder.RenameColumn(
                name: "FilmIdFilm",
                table: "Seanse",
                newName: "IdFilm");

            migrationBuilder.RenameIndex(
                name: "IX_Seanse_SalaIdSala",
                table: "Seanse",
                newName: "IX_Seanse_IdSala");

            migrationBuilder.RenameIndex(
                name: "IX_Seanse_FilmIdFilm",
                table: "Seanse",
                newName: "IX_Seanse_IdFilm");

            migrationBuilder.InsertData(
                table: "Seanse",
                columns: new[] { "IdSeans", "Data", "IdFilm", "IdSala", "WersjaJez" },
                values: new object[] { 1, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "PL" });

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Filmy_IdFilm",
                table: "Seanse",
                column: "IdFilm",
                principalTable: "Filmy",
                principalColumn: "IdFilm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Sale_IdSala",
                table: "Seanse",
                column: "IdSala",
                principalTable: "Sale",
                principalColumn: "IdSala",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Filmy_IdFilm",
                table: "Seanse");

            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Sale_IdSala",
                table: "Seanse");

            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "IdSala",
                table: "Seanse",
                newName: "SalaIdSala");

            migrationBuilder.RenameColumn(
                name: "IdFilm",
                table: "Seanse",
                newName: "FilmIdFilm");

            migrationBuilder.RenameIndex(
                name: "IX_Seanse_IdSala",
                table: "Seanse",
                newName: "IX_Seanse_SalaIdSala");

            migrationBuilder.RenameIndex(
                name: "IX_Seanse_IdFilm",
                table: "Seanse",
                newName: "IX_Seanse_FilmIdFilm");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Filmy_FilmIdFilm",
                table: "Seanse",
                column: "FilmIdFilm",
                principalTable: "Filmy",
                principalColumn: "IdFilm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Sale_SalaIdSala",
                table: "Seanse",
                column: "SalaIdSala",
                principalTable: "Sale",
                principalColumn: "IdSala",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
