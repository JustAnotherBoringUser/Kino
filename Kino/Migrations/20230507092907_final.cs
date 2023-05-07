using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("27813b66-d725-4235-a6e9-ac95973adb19"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("f5fd6f08-5300-4f3b-9759-94f6cdb085b5"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("5d5b7238-31cb-4973-8883-ba43f16e3128"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c5455aea-3a6c-4565-b942-43427c96c7ce"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("0c031186-0c27-4a92-bcc5-cb5c79e69640"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("1d8c2a77-3e1d-4564-a215-8bca08102a7e"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("86d9b828-bd2d-4ace-9925-7ae6a5a9652b"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("7cd44159-a7dd-4648-85e6-52b2665036be"));
        }
    }
}
