using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCarDescPropertyInCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("06eb21e7-57d1-4c30-b69d-bff102b473f8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf7b8588-72ca-4cd9-b825-3cb29b7ea6d4"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3a04131f-7e73-4318-8a54-b8c087f3e973"), null, "Admin", "ADMIN" },
                    { new Guid("6c0fb75b-119c-409d-9e00-5b23bcef8010"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a04131f-7e73-4318-8a54-b8c087f3e973"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c0fb75b-119c-409d-9e00-5b23bcef8010"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("06eb21e7-57d1-4c30-b69d-bff102b473f8"), null, "Admin", "ADMIN" },
                    { new Guid("cf7b8588-72ca-4cd9-b825-3cb29b7ea6d4"), null, "User", "USER" }
                });
        }
    }
}
