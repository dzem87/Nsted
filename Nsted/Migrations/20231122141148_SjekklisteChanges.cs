using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nsted.Migrations
{
    /// <inheritdoc />
    public partial class SjekklisteChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TestHydraulikkblokk",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SkifteOljeTank",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SkifteOljeGirBoks",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkWire",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkSlanger",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkRyngsylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkRadio",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkPinonLager",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkLedningsnett",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkLagerForTrommel",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKnappekasse",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKjedestrammer",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKile",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkHydrauliskSylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkClutchLamellerForSlitasje",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkBremsesylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkBremser",
                table: "Sjekklister",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "TestHydraulikkblokk",
                keyValue: null,
                column: "TestHydraulikkblokk",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TestHydraulikkblokk",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SkifteOljeTank",
                keyValue: null,
                column: "SkifteOljeTank",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SkifteOljeTank",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SkifteOljeGirBoks",
                keyValue: null,
                column: "SkifteOljeGirBoks",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SkifteOljeGirBoks",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkWire",
                keyValue: null,
                column: "SjekkWire",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkWire",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkSlanger",
                keyValue: null,
                column: "SjekkSlanger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkSlanger",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkRyngsylinder",
                keyValue: null,
                column: "SjekkRyngsylinder",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkRyngsylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkRadio",
                keyValue: null,
                column: "SjekkRadio",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkRadio",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkPinonLager",
                keyValue: null,
                column: "SjekkPinonLager",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkPinonLager",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkLedningsnett",
                keyValue: null,
                column: "SjekkLedningsnett",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkLedningsnett",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkLagerForTrommel",
                keyValue: null,
                column: "SjekkLagerForTrommel",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkLagerForTrommel",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkKnappekasse",
                keyValue: null,
                column: "SjekkKnappekasse",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKnappekasse",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkKjedestrammer",
                keyValue: null,
                column: "SjekkKjedestrammer",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKjedestrammer",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkKile",
                keyValue: null,
                column: "SjekkKile",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkKile",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkHydrauliskSylinder",
                keyValue: null,
                column: "SjekkHydrauliskSylinder",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkHydrauliskSylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkClutchLamellerForSlitasje",
                keyValue: null,
                column: "SjekkClutchLamellerForSlitasje",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkClutchLamellerForSlitasje",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkBremsesylinder",
                keyValue: null,
                column: "SjekkBremsesylinder",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkBremsesylinder",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekklister",
                keyColumn: "SjekkBremser",
                keyValue: null,
                column: "SjekkBremser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkBremser",
                table: "Sjekklister",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
