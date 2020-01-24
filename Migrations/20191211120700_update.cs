using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem1.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_AssignedToId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AssignedToId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentCourseModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourseModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseModel_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseModel_CourseId",
                table: "StudentCourseModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseModel_StudentId",
                table: "StudentCourseModel",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "StudentCourseModel");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AssignedToId",
                table: "Courses",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_AssignedToId",
                table: "Courses",
                column: "AssignedToId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
