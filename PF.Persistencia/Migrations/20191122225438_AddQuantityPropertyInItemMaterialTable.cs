using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class AddQuantityPropertyInItemMaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ItemsMaterials",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemsMaterials");
        }
    }
}
