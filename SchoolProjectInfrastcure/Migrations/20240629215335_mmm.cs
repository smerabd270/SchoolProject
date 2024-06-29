using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProjectInfrastrcure.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "studentSubjects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "studentSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true);
        }
    }
}
