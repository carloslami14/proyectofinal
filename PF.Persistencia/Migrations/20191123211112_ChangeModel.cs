using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PF.Persistencia.Migrations
{
    public partial class ChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetalle");

            migrationBuilder.CreateTable(
                name: "ItemsConstructions",
                columns: table => new
                {
                    ConstructionId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsConstructions", x => new { x.ConstructionId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemsConstructions_Constructions_ConstructionId",
                        column: x => x.ConstructionId,
                        principalTable: "Constructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsConstructions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsConstructions_ItemId",
                table: "ItemsConstructions",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsConstructions");

            migrationBuilder.CreateTable(
                name: "ItemDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConstructionId = table.Column<int>(nullable: true),
                    ContructionId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Constructions_ConstructionId",
                        column: x => x.ConstructionId,
                        principalTable: "Constructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ConstructionId",
                table: "ItemDetalle",
                column: "ConstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ItemId",
                table: "ItemDetalle",
                column: "ItemId");
        }
    }
}
