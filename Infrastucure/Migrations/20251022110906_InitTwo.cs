using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityTrip_Cities_CityId",
                table: "CityTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CityTrip_Trips_TripId",
                table: "CityTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityTrip",
                table: "CityTrip");

            migrationBuilder.RenameTable(
                name: "CityTrip",
                newName: "CityTrips");

            migrationBuilder.RenameIndex(
                name: "IX_CityTrip_TripId",
                table: "CityTrips",
                newName: "IX_CityTrips_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_CityTrip_CityId",
                table: "CityTrips",
                newName: "IX_CityTrips_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityTrips",
                table: "CityTrips",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRefundable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChildPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Guests = table.Column<int>(type: "int", nullable: false),
                    RemainingGuests = table.Column<int>(type: "int", nullable: false),
                    AboutExploreTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CityId",
                table: "Packages",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityTrips_Cities_CityId",
                table: "CityTrips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CityTrips_Trips_TripId",
                table: "CityTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityTrips_Cities_CityId",
                table: "CityTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_CityTrips_Trips_TripId",
                table: "CityTrips");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityTrips",
                table: "CityTrips");

            migrationBuilder.RenameTable(
                name: "CityTrips",
                newName: "CityTrip");

            migrationBuilder.RenameIndex(
                name: "IX_CityTrips_TripId",
                table: "CityTrip",
                newName: "IX_CityTrip_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_CityTrips_CityId",
                table: "CityTrip",
                newName: "IX_CityTrip_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityTrip",
                table: "CityTrip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityTrip_Cities_CityId",
                table: "CityTrip",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CityTrip_Trips_TripId",
                table: "CityTrip",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
