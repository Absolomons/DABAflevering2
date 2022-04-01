using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class SocAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocAddress",
                table: "Societies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Municipality",
                column: "MunicipalityID",
                value: 1);

            migrationBuilder.InsertData(
                table: "Societies",
                columns: new[] { "CVR", "Activity", "MunicipalityID", "NumberOfMembers", "SocAddress" },
                values: new object[] { 1234, "Volleyball", 1, 20, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Societies",
                keyColumn: "CVR",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Municipality",
                keyColumn: "MunicipalityID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SocAddress",
                table: "Societies");
        }
    }
}
