using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.Migrations
{
    /// <inheritdoc />
    public partial class addAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    HostelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelNameDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelNumberOfGuests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelNumberOfBedrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelNumberOfBathrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelLinkToBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelRoomPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.HostelID);
                });

            migrationBuilder.CreateTable(
                name: "LocationTravels",
                columns: table => new
                {
                    LocationTravelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationTravelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationTravelDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationTravelPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTravels", x => x.LocationTravelID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationTravelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_Activities_LocationTravels_LocationTravelID",
                        column: x => x.LocationTravelID,
                        principalTable: "LocationTravels",
                        principalColumn: "LocationTravelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LocationTravelID",
                table: "Activities",
                column: "LocationTravelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Hostels");

            migrationBuilder.DropTable(
                name: "LocationTravels");
        }
    }
}
