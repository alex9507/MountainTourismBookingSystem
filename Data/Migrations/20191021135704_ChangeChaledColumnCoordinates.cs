using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class ChangeChaledColumnCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location_coordinated",
                table: "Chalet",
                newName: "location_coordinates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location_coordinates",
                table: "Chalet",
                newName: "location_coordinated");
        }
    }
}
