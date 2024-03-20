using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWithDatabase.Migrations
{
    /// <inheritdoc />
    public partial class MigrateToAdvWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "pet",
                newName: "pet",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "location",
                newName: "location",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "category",
                newSchema: "AdventureWorks");

            migrationBuilder.RenameTable(
                name: "breed",
                newName: "breed",
                newSchema: "AdventureWorks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "pet",
                schema: "AdventureWorks",
                newName: "pet");

            migrationBuilder.RenameTable(
                name: "location",
                schema: "AdventureWorks",
                newName: "location");

            migrationBuilder.RenameTable(
                name: "category",
                schema: "AdventureWorks",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "breed",
                schema: "AdventureWorks",
                newName: "breed");
        }
    }
}
