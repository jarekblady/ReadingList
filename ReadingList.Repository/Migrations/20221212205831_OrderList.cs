using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingList.Repository.Migrations
{
    public partial class OrderList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Books",
                newName: "OrderList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderList",
                table: "Books",
                newName: "Order");
        }
    }
}
