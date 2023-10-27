using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nsted.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKundeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Navn",
                table: "Kunder",
                newName: "Telefon");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Kunder",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Epost",
                table: "Kunder",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Etternavn",
                table: "Kunder",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Fornavn",
                table: "Kunder",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Kunder");

            migrationBuilder.DropColumn(
                name: "Epost",
                table: "Kunder");

            migrationBuilder.DropColumn(
                name: "Etternavn",
                table: "Kunder");

            migrationBuilder.DropColumn(
                name: "Fornavn",
                table: "Kunder");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Kunder",
                newName: "Navn");
        }
    }
}
