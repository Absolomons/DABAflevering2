using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class DummyDataIDprimkeybooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Societies_CvrNavigationCvr",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_CvrNavigationCvr",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Bookingo__93FCB6C609F9E8D2",
                table: "Bookingoverview");

            migrationBuilder.RenameColumn(
                name: "CvrNavigationCvr",
                table: "Member",
                newName: "Cvr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimespanStart",
                table: "rooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimespanEnd",
                table: "rooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocietyCvr",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingEnd",
                table: "Bookingoverview",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingStart",
                table: "Bookingoverview",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Bookingoverview",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookingoverview",
                table: "Bookingoverview",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Chairman",
                columns: new[] { "CPR", "ChairmanName", "CVR", "HomeAddress" },
                values: new object[] { 2312, "bossman", 1234, "Bygning" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Cpr", "Cvr", "Name", "SocietyCvr" },
                values: new object[,]
                {
                    { 123451, 1234, "Sorry John", null },
                    { 542124, 4321, "Sorry Jens", null }
                });

            migrationBuilder.InsertData(
                table: "Societies",
                columns: new[] { "CVR", "Activity", "MunicipalityID", "NumberOfMembers", "SocAddress" },
                values: new object[] { 4321, "Yoga", 1, 25, "Damp Cellar" });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "RoomID", "AccessCode", "MunicipalityID", "RoomAddress", "roomlimit", "TimespanEnd", "TimespanStart" },
                values: new object[,]
                {
                    { 12, 5454, 1, "Skanderborg", 50, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1111, 1, "Silkeborg", 51, new DateTime(2065, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Chairman",
                columns: new[] { "CPR", "ChairmanName", "CVR", "HomeAddress" },
                values: new object[] { 6421, "Stol", 4321, "Bygning2" });

            migrationBuilder.InsertData(
                table: "properties",
                columns: new[] { "propertyID", "coffee", "RoomID", "soccerGoals", "whiteboard", "WiFi" },
                values: new object[] { 1, false, 12, true, true, false });

            migrationBuilder.InsertData(
                table: "properties",
                columns: new[] { "propertyID", "coffee", "RoomID", "soccerGoals", "whiteboard", "WiFi" },
                values: new object[] { 2, true, 21, true, false, true });

            migrationBuilder.CreateIndex(
                name: "IX_Member_SocietyCvr",
                table: "Member",
                column: "SocietyCvr");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingoverview_RoomID",
                table: "Bookingoverview",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Societies_SocietyCvr",
                table: "Member",
                column: "SocietyCvr",
                principalTable: "Societies",
                principalColumn: "CVR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Societies_SocietyCvr",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_SocietyCvr",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookingoverview",
                table: "Bookingoverview");

            migrationBuilder.DropIndex(
                name: "IX_Bookingoverview_RoomID",
                table: "Bookingoverview");

            migrationBuilder.DeleteData(
                table: "Chairman",
                keyColumn: "CPR",
                keyValue: 2312);

            migrationBuilder.DeleteData(
                table: "Chairman",
                keyColumn: "CPR",
                keyValue: 6421);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Cpr",
                keyValue: 123451);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Cpr",
                keyValue: 542124);

            migrationBuilder.DeleteData(
                table: "properties",
                keyColumn: "propertyID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "properties",
                keyColumn: "propertyID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Societies",
                keyColumn: "CVR",
                keyValue: 4321);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomID",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "SocietyCvr",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Bookingoverview");

            migrationBuilder.RenameColumn(
                name: "Cvr",
                table: "Member",
                newName: "CvrNavigationCvr");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimespanStart",
                table: "rooms",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimespanEnd",
                table: "rooms",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "BookingStart",
                table: "Bookingoverview",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "BookingEnd",
                table: "Bookingoverview",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Bookingo__93FCB6C609F9E8D2",
                table: "Bookingoverview",
                columns: new[] { "RoomID", "BookingStart", "BookingEnd" });

            migrationBuilder.CreateIndex(
                name: "IX_Member_CvrNavigationCvr",
                table: "Member",
                column: "CvrNavigationCvr");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Societies_CvrNavigationCvr",
                table: "Member",
                column: "CvrNavigationCvr",
                principalTable: "Societies",
                principalColumn: "CVR",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
