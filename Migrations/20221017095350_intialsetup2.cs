using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APPR_TASK1.Migrations
{
    public partial class intialsetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goods_Disaster_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Disaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TypeID = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Money_Disaster_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Disaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_TypeID",
                table: "Goods",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Money_TypeID",
                table: "Money",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Money");
        }
    }
}
