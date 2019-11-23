using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class ChangeTableConstrucction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Constructions",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Constructions",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Constructions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Constructions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Constructions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Constructions",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
