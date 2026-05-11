using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetWebProg.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea006ee-9a3c-4c08-89d6-63d9cf58b738");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4f84ffe-4832-4ec5-bcdf-0eff21bea3ce");

            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                table: "Toutous",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43a98e93-0e74-425e-8aff-72ff8e8bc5af", null, "Utilisateur", "UTILISATEUR" },
                    { "ff085b9d-0d22-4b03-8a87-76a27d49a4e9", null, "Administrateur", "ADMINISTRATEUR" }
                });

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceId",
                value: "prod_UT7R60A6mzLKXK");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceId",
                value: "prod_UT7SL1YLkDlt1x");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriceId",
                value: "prod_UT7SqFtj4oL2wS");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceId",
                value: "prod_UT7SO49lGPaX9y");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriceId",
                value: "prod_UT7SWfTzDr6gYf");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 6,
                column: "PriceId",
                value: "prod_UT7Tx0rMRjG6z2");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 7,
                column: "PriceId",
                value: "prod_UT7Tpa6QQoZEq1");

            migrationBuilder.UpdateData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 8,
                column: "PriceId",
                value: "prod_UT7TdWiC56wWkQ");

            migrationBuilder.InsertData(
                table: "Toutous",
                columns: new[] { "Id", "CoupCoeur", "Description", "Image", "NbrInventaire", "Nom", "Nouveau", "PriceId", "Prix" },
                values: new object[] { 9, true, "Le toutou qui respire", "https://fixcdn.hyonsu.com/attachments/911076301337669664/1499122232079814706/IMG_5199.jpg?ex=69f3a5e0&is=69f25460&hm=182938c660a25e01c0862e883cb9da57a3e20ae292f601f860db29ab86c16bc5&", 0, "Pou", true, "prod_UT7UzSCzcrLiKG", 8 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a98e93-0e74-425e-8aff-72ff8e8bc5af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff085b9d-0d22-4b03-8a87-76a27d49a4e9");

            migrationBuilder.DeleteData(
                table: "Toutous",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Toutous");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ea006ee-9a3c-4c08-89d6-63d9cf58b738", null, "Utilisateur", "UTILISATEUR" },
                    { "f4f84ffe-4832-4ec5-bcdf-0eff21bea3ce", null, "Administrateur", "ADMINISTRATEUR" }
                });
        }
    }
}
