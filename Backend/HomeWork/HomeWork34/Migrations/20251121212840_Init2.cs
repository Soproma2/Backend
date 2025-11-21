using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork34.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_StudentId",
                table: "studentDetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_students_StudentId",
                table: "studentDetails",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_students_StudentId",
                table: "studentDetails");

            migrationBuilder.DropIndex(
                name: "IX_studentDetails_StudentId",
                table: "studentDetails");
        }
    }
}
