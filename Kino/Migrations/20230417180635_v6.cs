using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2023, 4, 18, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2023, 4, 18, 20, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("002da022-8b66-44a0-afb9-86f0c1c75ebd"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("cb382ec8-ce12-4a2e-9ae9-cb20eeac1328"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("889d34b1-929a-4165-ba9e-d09f4d892432"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("3f4438e7-ae5f-4c37-ba76-d516687e0991"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2023, 4, 6, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2023, 4, 5, 20, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
