using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetWebProg.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c74dbe90-8db0-4be4-908a-29b5cb6e1f2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edf74b99-cab3-4a6a-aab0-b0623dfcbd2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26e2f0ea-3cc7-4529-bf36-b26568800c3f", null, "Utilisateur", "UTILISATEUR" },
                    { "70c0a638-4e32-4c5a-bf69-fdb7d41661ea", null, "admin", "ADMINISTRATEUR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e2f0ea-3cc7-4529-bf36-b26568800c3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c0a638-4e32-4c5a-bf69-fdb7d41661ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c74dbe90-8db0-4be4-908a-29b5cb6e1f2b", null, "admin", "ADMINISTRATEUR" },
                    { "edf74b99-cab3-4a6a-aab0-b0623dfcbd2e", null, "Utilisateur", "UTILISATEUR" }
                });
        }
    }
}
