using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetWebProg.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e2f0ea-3cc7-4529-bf36-b26568800c3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c0a638-4e32-4c5a-bf69-fdb7d41661ea");

            migrationBuilder.CreateTable(
                name: "CommandeToutous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToutousId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeToutous", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47b42130-431c-4aa7-9ccf-d6b55c288828", null, "admin", "ADMINISTRATEUR" },
                    { "c3663c8e-45d2-4fda-a74c-18789add06a7", null, "Utilisateur", "UTILISATEUR" }
                });

            migrationBuilder.InsertData(
                table: "Commande",
                columns: new[] { "Id", "Payee", "UserId" },
                values: new object[] { 1, false, "a049c840-f589-46d3-9466-27237c9379ad" });

            migrationBuilder.InsertData(
                table: "CommandeToutous",
                columns: new[] { "Id", "Quantite", "ToutousId" },
                values: new object[] { 1, 10, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeToutous");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47b42130-431c-4aa7-9ccf-d6b55c288828");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3663c8e-45d2-4fda-a74c-18789add06a7");

            migrationBuilder.DeleteData(
                table: "Commande",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26e2f0ea-3cc7-4529-bf36-b26568800c3f", null, "Utilisateur", "UTILISATEUR" },
                    { "70c0a638-4e32-4c5a-bf69-fdb7d41661ea", null, "admin", "ADMINISTRATEUR" }
                });
        }
    }
}
