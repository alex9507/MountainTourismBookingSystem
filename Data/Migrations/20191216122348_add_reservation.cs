using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class add_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    reservation_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dt = table.Column<DateTime>(nullable: false),
                    chalet_id = table.Column<long>(nullable: false),
                    dt_from = table.Column<DateTime>(nullable: false),
                    dt_to = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(maxLength: 50, nullable: true),
                    amount = table.Column<double>(nullable: false),
                    currency = table.Column<string>(maxLength: 3, nullable: true),
                    balance_transaction_id = table.Column<string>(maxLength: 100, nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservation_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
