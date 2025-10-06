using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DCPC.Challenge.Escola.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e7d2a8d-6b49-4d1b-8b9d-2a62a8f7f001", "8e7d2a8d-6b49-4d1b-8b9d-2a62a8f7f001", "User", "USER" },
                    { "a4c3f2b1-9d88-4c7e-9f4a-3b2c1d0e0f02", "a4c3f2b1-9d88-4c7e-9f4a-3b2c1d0e0f02", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7d2a8d-6b49-4d1b-8b9d-2a62a8f7f001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4c3f2b1-9d88-4c7e-9f4a-3b2c1d0e0f02");
        }
    }
}
