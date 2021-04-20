using Microsoft.EntityFrameworkCore.Migrations;

namespace WAD_CW.DAL.DBO.Migrations
{
    public partial class Order_Weight_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Orders");
        }
    }
}
