﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class seeddatav5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2023, 4, 4, 10, 20, 0, 0, DateTimeKind.Unspecified));

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
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 4,
                column: "Data",
                value: new DateTime(2023, 4, 5, 22, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 4,
                column: "Data",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
