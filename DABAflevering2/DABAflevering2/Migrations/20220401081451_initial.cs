using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityID);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    roomlimit = table.Column<int>(type: "int", nullable: true),
                    TimespanStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimespanEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    MunicipalityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK__rooms__Municipal__5728DECD",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    CVR = table.Column<int>(type: "int", nullable: false),
                    NumberOfMembers = table.Column<int>(type: "int", nullable: true),
                    Activity = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    MunicipalityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Societie__C1FE224CA7F4BA4B", x => x.CVR);
                    table.ForeignKey(
                        name: "FK__Societies__Munic__4F87BD05",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    WiFi = table.Column<bool>(type: "bit", nullable: true),
                    whiteboard = table.Column<bool>(type: "bit", nullable: true),
                    soccerGoals = table.Column<bool>(type: "bit", nullable: true),
                    coffee = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.propertyID);
                    table.ForeignKey(
                        name: "FK__propertie__RoomI__5BED93EA",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookingoverview",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    BookingStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    BookingEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    CVR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookingo__93FCB6C609F9E8D2", x => new { x.RoomID, x.BookingStart, x.BookingEnd });
                    table.ForeignKey(
                        name: "FK__Bookingov__RoomI__5FBE24CE",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomID");
                    table.ForeignKey(
                        name: "FK__Bookingover__CVR__5ECA0095",
                        column: x => x.CVR,
                        principalTable: "Societies",
                        principalColumn: "CVR");
                });

            migrationBuilder.CreateTable(
                name: "Chairman",
                columns: table => new
                {
                    CPR = table.Column<int>(type: "int", nullable: false),
                    HomeAddress = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    ChairmanName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    CVR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chairman__C1F8973CD4538063", x => x.CPR);
                    table.ForeignKey(
                        name: "FK__Chairman__CVR__53584DE9",
                        column: x => x.CVR,
                        principalTable: "Societies",
                        principalColumn: "CVR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookingoverview_CVR",
                table: "Bookingoverview",
                column: "CVR");

            migrationBuilder.CreateIndex(
                name: "IX_Chairman_CVR",
                table: "Chairman",
                column: "CVR");

            migrationBuilder.CreateIndex(
                name: "UQ__Chairman__C1F8973DC623382E",
                table: "Chairman",
                column: "CPR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Municipa__009B60F4FC02DE25",
                table: "Municipality",
                column: "MunicipalityID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__properti__328639182028850B",
                table: "properties",
                column: "RoomID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__properti__9C0B8C5CE91EE6F5",
                table: "properties",
                column: "propertyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rooms_MunicipalityID",
                table: "rooms",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "UQ__rooms__32863918C12586CE",
                table: "rooms",
                column: "RoomID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Societies_MunicipalityID",
                table: "Societies",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "UQ__Societie__C1FE224D644D06EE",
                table: "Societies",
                column: "CVR",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookingoverview");

            migrationBuilder.DropTable(
                name: "Chairman");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "Societies");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "Municipality");
        }
    }
}
