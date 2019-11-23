using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class ProviderInMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ProviderId",
                table: "Materials",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Providers_ProviderId",
                table: "Materials",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Providers_ProviderId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ProviderId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Materials");
        }
    }
}
