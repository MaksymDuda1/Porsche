using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrueValueOnInitInCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a04131f-7e73-4318-8a54-b8c087f3e973"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c0fb75b-119c-409d-9e00-5b23bcef8010"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("aa440865-c9af-43c3-9025-65438360acb3"), null, "Admin", "ADMIN" },
                    { new Guid("e42a8a6f-2cb1-4716-a319-e53eeddb07bf"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa440865-c9af-43c3-9025-65438360acb3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e42a8a6f-2cb1-4716-a319-e53eeddb07bf"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3a04131f-7e73-4318-8a54-b8c087f3e973"), null, "Admin", "ADMIN" },
                    { new Guid("6c0fb75b-119c-409d-9e00-5b23bcef8010"), null, "User", "USER" }
                });
        }
    }
}
