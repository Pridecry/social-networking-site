using Microsoft.EntityFrameworkCore.Migrations;

namespace DieteticSNS.Persistence.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicURL",
                table: "AspNetUsers",
                newName: "AvatarPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarPath",
                table: "AspNetUsers",
                newName: "ProfilePicURL");
        }
    }
}
