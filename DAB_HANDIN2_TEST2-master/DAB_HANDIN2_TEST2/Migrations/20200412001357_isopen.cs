using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_HANDIN2_TEST2.Migrations
{
    public partial class isopen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Helprequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Helprequests");
        }
    }
}
