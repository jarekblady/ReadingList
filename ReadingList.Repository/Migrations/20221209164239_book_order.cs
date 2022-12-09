using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingList.Repository.Migrations
{
    public partial class book_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Books");
        }
    }
}
