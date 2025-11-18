using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirPort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 45, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Code = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CountryId = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCityId = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    IsRefundable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChildPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Guests = table.Column<int>(type: "int", nullable: false),
                    RemainingGuests = table.Column<int>(type: "int", nullable: false),
                    AboutExploreTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCityId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_City_FromCityId",
                        column: x => x.FromCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_City_ToCityId",
                        column: x => x.ToCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 45, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    IsRefundable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Guests = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    TripHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ChildPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RemainingGuests = table.Column<int>(type: "int", nullable: false),
                    FromCityId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_City_FromCityId",
                        column: x => x.FromCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityPackage_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityPackage_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTrip_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTrip_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPackage_CityId",
                table: "CityPackage",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPackage_PackageId",
                table: "CityPackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTrip_CityId",
                table: "CityTrip",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTrip_TripId",
                table: "CityTrip",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_FromCityId",
                table: "Package",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ToCityId",
                table: "Package",
                column: "ToCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_FromCityId",
                table: "Trip",
                column: "FromCityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirPort");

            migrationBuilder.DropTable(
                name: "CityPackage");

            migrationBuilder.DropTable(
                name: "CityTrip");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
