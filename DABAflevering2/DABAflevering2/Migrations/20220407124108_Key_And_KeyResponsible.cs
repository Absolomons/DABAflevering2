using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAflevering2.Migrations
{
    public partial class Key_And_KeyResponsible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Societies_CvrNavigationCvr",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Member_CvrNavigationCvr",
                table: "Members",
                newName: "IX_Members_CvrNavigationCvr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Cpr");

            migrationBuilder.CreateTable(
                name: "KeyResponsibles",
                columns: table => new
                {
                    CPR = table.Column<int>(type: "int", nullable: false),
                    MunicipalityID = table.Column<int>(type: "int", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Passport = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyResponsible", x => new { x.CPR, x.MunicipalityID });
                    table.ForeignKey(
                        name: "FK_KeyResponsibles_Chairman_CPR",
                        column: x => x.CPR,
                        principalTable: "Chairman",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyResponsibles_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    keyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    keyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.keyID);
                    table.ForeignKey(
                        name: "FK_Keys_rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyResponsibles_MunicipalityID",
                table: "KeyResponsibles",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_RoomID",
                table: "Keys",
                column: "RoomID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Societies_CvrNavigationCvr",
                table: "Members",
                column: "CvrNavigationCvr",
                principalTable: "Societies",
                principalColumn: "CVR",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Societies_CvrNavigationCvr",
                table: "Members");

            migrationBuilder.DropTable(
                name: "KeyResponsibles");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CvrNavigationCvr",
                table: "Member",
                newName: "IX_Member_CvrNavigationCvr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Cpr");

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
