using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class reservation_data_helper_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationDataHelper",
                columns: table => new
                {
                    reservation_helper_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    chalet_id = table.Column<long>(nullable: false),
                    dt_from = table.Column<DateTime>(nullable: false),
                    dt_to = table.Column<DateTime>(nullable: false),
                    is_full_day = table.Column<bool>(nullable: false),
                    amount = table.Column<double>(nullable: false),
                    currency = table.Column<string>(maxLength: 3, nullable: true),
                    people_count = table.Column<int>(nullable: false),
                    color = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDataHelper", x => x.reservation_helper_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationDataHelper");
        }
    }
}
