using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e4dca7a-9963-4da2-91ca-6aa946fb4fd0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eae77cb5-15b5-4951-8beb-22b65acbbb94"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("77dd6ee8-6d3b-4a13-a34f-570f254985c2"), null, "User", "USER" },
                    { new Guid("7b0aefbc-78dc-4bc0-91fe-c139168edae0"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77dd6ee8-6d3b-4a13-a34f-570f254985c2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b0aefbc-78dc-4bc0-91fe-c139168edae0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e4dca7a-9963-4da2-91ca-6aa946fb4fd0"), null, "Admin", "ADMIN" },
                    { new Guid("eae77cb5-15b5-4951-8beb-22b65acbbb94"), null, "User", "USER" }
                });
        }
    }
}
