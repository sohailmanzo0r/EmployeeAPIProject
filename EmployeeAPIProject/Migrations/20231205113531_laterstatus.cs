using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class laterstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "laterstatus",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "laterstatus",
                table: "employees");
        }
    }
}
