using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class dob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "employees");
        }
    }
}
