using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MountainTourismBookingSystem.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chalet",
                columns: table => new
                {
                    challet_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dt = table.Column<DateTime>(nullable: false),
                    mountain_type = table.Column<string>(maxLength: 3, nullable: false),
                    region_type = table.Column<string>(maxLength: 3, nullable: false),
                    chalet_type = table.Column<string>(maxLength: 3, nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: true),
                    information = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true),
                    location_info = table.Column<string>(nullable: true),
                    location_coordinated = table.Column<string>(nullable: true),
                    location_map = table.Column<string>(nullable: true),
                    altitude = table.Column<string>(maxLength: 10, nullable: true),
                    starting_point = table.Column<string>(maxLength: 250, nullable: true),
                    owner = table.Column<string>(maxLength: 200, nullable: true),
                    gsm = table.Column<string>(maxLength: 50, nullable: true),
                    contacts = table.Column<string>(maxLength: 200, nullable: true),
                    routes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chalet", x => x.challet_id);
                });

            migrationBuilder.CreateTable(
                name: "ChaletType",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 3, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChaletType", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Mountain",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 3, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountain", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 3, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chalet");

            migrationBuilder.DropTable(
                name: "ChaletType");

            migrationBuilder.DropTable(
                name: "Mountain");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
