using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWithDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ToDatabasesAdventureWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Databases.AdventureWorks");

            migrationBuilder.RenameTable(
                name: "pet",
                schema: "AdventureWorks",
                newName: "pet",
                newSchema: "Databases.AdventureWorks");

            migrationBuilder.RenameTable(
                name: "location",
                schema: "AdventureWorks",
                newName: "location",
                newSchema: "Databases.AdventureWorks");

            migrationBuilder.RenameTable(
                name: "category",
                schema: "AdventureWorks",
                newName: "category",
                newSchema: "Databases.AdventureWorks");

            migrationBuilder.RenameTable(
                name: "breed",
                schema: "AdventureWorks",
                newName: "breed",
                newSchema: "Databases.AdventureWorks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "pet",
                schema: "Databases.AdventureWorks",
                newName: "pet",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "location",
                schema: "Databases.AdventureWorks",
                newName: "location",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "category",
                schema: "Databases.AdventureWorks",
                newName: "category",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "breed",
                schema: "Databases.AdventureWorks",
                newName: "breed",
                newSchema: "AdventureWorks");
        }
    }
}
