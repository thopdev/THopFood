using Microsoft.EntityFrameworkCore.Migrations;

namespace ThopFood.API.Migrations
{
    public partial class UtensilName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Utensils",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Utensils");
        }
    }
}
