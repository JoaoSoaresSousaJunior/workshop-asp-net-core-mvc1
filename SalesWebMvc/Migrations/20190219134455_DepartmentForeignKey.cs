using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sellers",
                newName: "DataNascimento");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Sellers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Sellers",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Sellers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
