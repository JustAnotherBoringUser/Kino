using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class poprawkidotabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Zamowienia",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Ulga",
                table: "Zamowienia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrMiejsca",
                table: "Miejsca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                columns: new[] { "Guid", "Ulga" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                columns: new[] { "Guid", "Ulga" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                columns: new[] { "Guid", "Ulga" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                columns: new[] { "Guid", "Ulga" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "Ulga",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "NrMiejsca",
                table: "Miejsca");
        }
    }
}
