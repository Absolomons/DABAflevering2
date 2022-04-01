using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class DummyDataBookingoverview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookingoverview",
                columns: new[] { "BookingEnd", "BookingStart", "RoomID", "CVR" },
                values: new object[] { new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1234 });

            migrationBuilder.InsertData(
                table: "Bookingoverview",
                columns: new[] { "BookingEnd", "BookingStart", "RoomID", "CVR" },
                values: new object[] { new DateTime(2042, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 4321 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookingoverview",
                keyColumns: new[] { "BookingEnd", "BookingStart", "RoomID" },
                keyValues: new object[] { new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 });

            migrationBuilder.DeleteData(
                table: "Bookingoverview",
                keyColumns: new[] { "BookingEnd", "BookingStart", "RoomID" },
                keyValues: new object[] { new DateTime(2042, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21 });
        }
    }
}
