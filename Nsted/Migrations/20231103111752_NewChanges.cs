using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nsted.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceNotat",
                table: "Servicer");

            migrationBuilder.AddColumn<string>(
                name: "Notat",
                table: "Servicer",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Produkttype",
                table: "Servicer",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Serienummer",
                table: "Servicer",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ServiceRep",
                table: "Servicer",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Årsmodell",
                table: "Servicer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notat",
                table: "Servicer");

            migrationBuilder.DropColumn(
                name: "Produkttype",
                table: "Servicer");

            migrationBuilder.DropColumn(
                name: "Serienummer",
                table: "Servicer");

            migrationBuilder.DropColumn(
                name: "ServiceRep",
                table: "Servicer");

            migrationBuilder.DropColumn(
                name: "Årsmodell",
                table: "Servicer");

            migrationBuilder.AddColumn<string>(
                name: "ServiceNotat",
                table: "Servicer",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
