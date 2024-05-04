using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusAgainstIsAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa440865-c9af-43c3-9025-65438360acb3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e42a8a6f-2cb1-4716-a319-e53eeddb07bf"));

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e4dca7a-9963-4da2-91ca-6aa946fb4fd0"), null, "Admin", "ADMIN" },
                    { new Guid("eae77cb5-15b5-4951-8beb-22b65acbbb94"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e4dca7a-9963-4da2-91ca-6aa946fb4fd0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eae77cb5-15b5-4951-8beb-22b65acbbb94"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("aa440865-c9af-43c3-9025-65438360acb3"), null, "Admin", "ADMIN" },
                    { new Guid("e42a8a6f-2cb1-4716-a319-e53eeddb07bf"), null, "User", "USER" }
                });
        }
    }
}
