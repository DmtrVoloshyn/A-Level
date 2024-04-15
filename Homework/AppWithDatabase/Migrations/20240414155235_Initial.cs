using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWithDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pet_db");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "pet_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                schema: "pet_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breed",
                schema: "pet_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    breed_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breed", x => x.id);
                    table.ForeignKey(
                        name: "FK_breed_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "pet_db",
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pet",
                schema: "pet_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    breed_id = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet", x => x.id);
                    table.ForeignKey(
                        name: "FK_pet_breed_breed_id",
                        column: x => x.breed_id,
                        principalSchema: "pet_db",
                        principalTable: "breed",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pet_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "pet_db",
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pet_location_location_id",
                        column: x => x.location_id,
                        principalSchema: "pet_db",
                        principalTable: "location",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_breed_category_id",
                schema: "pet_db",
                table: "breed",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_breed_id",
                schema: "pet_db",
                table: "pet",
                column: "breed_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_category_id",
                schema: "pet_db",
                table: "pet",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_location_id",
                schema: "pet_db",
                table: "pet",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pet",
                schema: "pet_db");

            migrationBuilder.DropTable(
                name: "breed",
                schema: "pet_db");

            migrationBuilder.DropTable(
                name: "location",
                schema: "pet_db");

            migrationBuilder.DropTable(
                name: "category",
                schema: "pet_db");
        }
    }
}
