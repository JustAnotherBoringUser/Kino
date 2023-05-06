using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class poprawkidotabelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_Zamowienia_ZamowienieIdZamowienie",
                table: "Miejsca");

            migrationBuilder.RenameColumn(
                name: "ZamowienieIdZamowienie",
                table: "Miejsca",
                newName: "IdZamowienie");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_ZamowienieIdZamowienie",
                table: "Miejsca",
                newName: "IX_Miejsca_IdZamowienie");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_Zamowienia_IdZamowienie",
                table: "Miejsca",
                column: "IdZamowienie",
                principalTable: "Zamowienia",
                principalColumn: "IdZamowienie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_Zamowienia_IdZamowienie",
                table: "Miejsca");

            migrationBuilder.RenameColumn(
                name: "IdZamowienie",
                table: "Miejsca",
                newName: "ZamowienieIdZamowienie");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_IdZamowienie",
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
    }
}
