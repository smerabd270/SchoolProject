using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProjectInfrastrcure.Migrations
{
    public partial class mmkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectNameEn",
                table: "subjects",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "SubjectNameAr",
                table: "subjects",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "DNameEn",
                table: "departments",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "DNameAr",
                table: "departments",
                newName: "NameAr");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "subjects",
                newName: "SubjectNameEn");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "subjects",
                newName: "SubjectNameAr");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "departments",
                newName: "DNameEn");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "departments",
                newName: "DNameAr");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
