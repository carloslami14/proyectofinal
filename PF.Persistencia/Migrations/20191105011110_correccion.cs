using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_Items_ChildItemId",
                table: "ItemDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_Items_FatherItemId",
                table: "ItemDetalle");

            migrationBuilder.DropIndex(
                name: "IX_ItemDetalle_ChildItemId",
                table: "ItemDetalle");

            migrationBuilder.DropColumn(
                name: "ChildItemId",
                table: "ItemDetalle");

            migrationBuilder.RenameColumn(
                name: "FatherItemId",
                table: "ItemDetalle",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "ChilItemId",
                table: "ItemDetalle",
                newName: "ContructionId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetalle_FatherItemId",
                table: "ItemDetalle",
                newName: "IX_ItemDetalle_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_Items_ItemId",
                table: "ItemDetalle",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_Items_ItemId",
                table: "ItemDetalle");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemDetalle",
                newName: "FatherItemId");

            migrationBuilder.RenameColumn(
                name: "ContructionId",
                table: "ItemDetalle",
                newName: "ChilItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetalle_ItemId",
                table: "ItemDetalle",
                newName: "IX_ItemDetalle_FatherItemId");

            migrationBuilder.AddColumn<int>(
                name: "ChildItemId",
                table: "ItemDetalle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ChildItemId",
                table: "ItemDetalle",
                column: "ChildItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_Items_ChildItemId",
                table: "ItemDetalle",
                column: "ChildItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_Items_FatherItemId",
                table: "ItemDetalle",
                column: "FatherItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
