using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class Altermiejsceaddzamowieniecol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_Seanse_SeansIdSeans",
                table: "Miejsca");

            migrationBuilder.RenameColumn(
                name: "SeansIdSeans",
                table: "Miejsca",
                newName: "ZamowienieIdZamowienie");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_SeansIdSeans",
                table: "Miejsca",
                newName: "IX_Miejsca_ZamowienieIdZamowienie");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_Zamowienia_ZamowienieIdZamowienie",
                table: "Miejsca",
                column: "ZamowienieIdZamowienie",
                principalTable: "Zamowienia",
                principalColumn: "IdZamowienie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_Zamowienia_ZamowienieIdZamowienie",
                table: "Miejsca");

            migrationBuilder.RenameColumn(
                name: "ZamowienieIdZamowienie",
                table: "Miejsca",
                newName: "SeansIdSeans");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_ZamowienieIdZamowienie",
                table: "Miejsca",
                newName: "IX_Miejsca_SeansIdSeans");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_Seanse_SeansIdSeans",
                table: "Miejsca",
                column: "SeansIdSeans",
                principalTable: "Seanse",
                principalColumn: "IdSeans",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
