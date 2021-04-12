using Microsoft.EntityFrameworkCore.Migrations;

namespace ThopFood.API.Migrations
{
    public partial class RecipeStepText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "RecipeSteps",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "RecipeSteps");
        }
    }
}
