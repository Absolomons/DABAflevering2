using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class Bookingprimkeyrea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookingoverview",
                table: "Bookingoverview");

            migrationBuilder.DropIndex(
                name: "IX_Bookingoverview_RoomID",
                table: "Bookingoverview");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Bookingoverview");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Bookingo__93FCB6C609F9E8D2",
                table: "Bookingoverview",
                columns: new[] { "RoomID", "BookingStart", "BookingEnd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Bookingo__93FCB6C609F9E8D2",
                table: "Bookingoverview");

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookingoverview_RoomID",
                table: "Bookingoverview",
                column: "RoomID");
        }
    }
}
