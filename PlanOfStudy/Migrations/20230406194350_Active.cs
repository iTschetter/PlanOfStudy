using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanOfStudy.Migrations
{
    public partial class Active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SavedPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "SavedPlans");
        }
    }
}
