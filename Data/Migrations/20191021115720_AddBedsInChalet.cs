using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class AddBedsInChalet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "beds",
                table: "Chalet",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beds",
                table: "Chalet");
        }
    }
}
