using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetWebProg.Migrations
{
    /// <inheritdoc />
    public partial class CreationModeleToutous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toutous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrInventaire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toutous", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Toutous",
                columns: new[] { "Id", "Description", "Image", "NbrInventaire", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1, "Ours en peluche brun classique", "bernard.jpg", 10, "Bernard", 25 },
                    { 2, "Lapin blanc aux longues oreilles", "lulu.jpg", 15, "Lulu", 30 },
                    { 3, "Chat gris rayé tout doux", "felix.jpg", 8, "Félix", 20 },
                    { 4, "Licorne rose avec crinière arc-en-ciel", "rosie.jpg", 12, "Rosie", 35 },
                    { 5, "Chien beige avec grandes pattes", "maxou.jpg", 6, "Maxou", 28 },
                    { 6, "Poisson clown orange et blanc", "nemo.jpg", 20, "Nemo", 22 },
                    { 7, "Éléphant gris avec nœud rose", "bella.jpg", 5, "Bella", 40 },
                    { 8, "Petit pingouin noir et blanc rigolo", "coco.jpg", 14, "Coco", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toutous");
        }
    }
}
