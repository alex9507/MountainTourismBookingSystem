using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class chalet_price_and_guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Chalet",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "unique_id",
                table: "Chalet",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Chalet");

            migrationBuilder.DropColumn(
                name: "unique_id",
                table: "Chalet");
        }
    }
}
