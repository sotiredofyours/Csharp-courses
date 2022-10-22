using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookCRUD.Migrations
{
    public partial class Addid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Contacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contacts");
        }
    }
}
