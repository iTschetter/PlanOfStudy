using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanOfStudy.Migrations
{
    public partial class SavedPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedPlans",
                columns: table => new
                {
                    SavedPlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedPlans", x => x.SavedPlanID);
                });

            migrationBuilder.CreateTable(
                name: "PlanLine",
                columns: table => new
                {
                    PlanLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SavedPlanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanLine", x => x.PlanLineID);
                    table.ForeignKey(
                        name: "FK_PlanLine_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanLine_SavedPlans_SavedPlanID",
                        column: x => x.SavedPlanID,
                        principalTable: "SavedPlans",
                        principalColumn: "SavedPlanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_CourseID",
                table: "PlanLine",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_SavedPlanID",
                table: "PlanLine",
                column: "SavedPlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanLine");

            migrationBuilder.DropTable(
                name: "SavedPlans");
        }
    }
}
