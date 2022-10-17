using Microsoft.EntityFrameworkCore.Migrations;

namespace APPR_TASK1.Migrations
{
    public partial class intialsetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Money_Disaster_TypeID",
                table: "Money");

            migrationBuilder.DropIndex(
                name: "IX_Money_TypeID",
                table: "Money");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Money");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Money");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Money",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Money");

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Money",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Money",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Money_TypeID",
                table: "Money",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Money_Disaster_TypeID",
                table: "Money",
                column: "TypeID",
                principalTable: "Disaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
