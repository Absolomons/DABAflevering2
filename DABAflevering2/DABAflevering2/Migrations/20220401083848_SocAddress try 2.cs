using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class SocAddresstry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Societies",
                keyColumn: "CVR",
                keyValue: 1234,
                column: "SocAddress",
                value: "Beach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Societies",
                keyColumn: "CVR",
                keyValue: 1234,
                column: "SocAddress",
                value: null);
        }
    }
}
