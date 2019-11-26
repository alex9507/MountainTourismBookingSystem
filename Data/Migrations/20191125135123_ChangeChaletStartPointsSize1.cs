using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class ChangeChaletStartPointsSize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "starting_point",
                table: "Chalet",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "starting_point",
                table: "Chalet",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
