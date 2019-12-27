using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class reservation_user_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "ReservationDataHelper",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "ReservationDataHelper");
        }
    }
}
