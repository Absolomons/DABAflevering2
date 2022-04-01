using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class UpdatedChangestoModel20finished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessCode",
                table: "rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomAddress",
                table: "rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "RoomAddress",
                table: "rooms");
        }
    }
}
