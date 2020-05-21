using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_LMS.Data.Migrations
{
    public partial class facultyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculty",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculty",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
