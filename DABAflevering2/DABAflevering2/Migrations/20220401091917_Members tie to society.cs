using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class Memberstietosociety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Societies_SocietyCvr",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_SocietyCvr",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "SocietyCvr",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "Cvr",
                table: "Member",
                newName: "CvrNavigationCvr");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Societies_CvrNavigationCvr",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_CvrNavigationCvr",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "CvrNavigationCvr",
                table: "Member",
                newName: "Cvr");

            migrationBuilder.AddColumn<int>(
                name: "SocietyCvr",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_SocietyCvr",
                table: "Member",
                column: "SocietyCvr");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Societies_SocietyCvr",
                table: "Member",
                column: "SocietyCvr",
                principalTable: "Societies",
                principalColumn: "CVR");
        }
    }
}
