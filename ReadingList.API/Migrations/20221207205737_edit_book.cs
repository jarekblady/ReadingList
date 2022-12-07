using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingList.API.Migrations
{
    public partial class edit_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPriority",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPriority",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
