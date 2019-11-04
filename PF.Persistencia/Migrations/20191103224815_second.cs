using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Constructions_ConstructionId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ConstructionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ConstructionId",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "ItemDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    FatherItemId = table.Column<int>(nullable: false),
                    ChilItemId = table.Column<int>(nullable: false),
                    ChildItemId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ConstructionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Items_ChildItemId",
                        column: x => x.ChildItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Constructions_ConstructionId",
                        column: x => x.ConstructionId,
                        principalTable: "Constructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Items_FatherItemId",
                        column: x => x.FatherItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ChildItemId",
                table: "ItemDetalle",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ConstructionId",
                table: "ItemDetalle",
                column: "ConstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_FatherItemId",
                table: "ItemDetalle",
                column: "FatherItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetalle");

            migrationBuilder.AddColumn<int>(
                name: "ConstructionId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ConstructionId",
                table: "Activities",
                column: "ConstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Constructions_ConstructionId",
                table: "Activities",
                column: "ConstructionId",
                principalTable: "Constructions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
