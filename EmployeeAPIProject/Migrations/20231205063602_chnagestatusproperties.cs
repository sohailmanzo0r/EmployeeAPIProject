using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class chnagestatusproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusChangeChoice",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangeDate",
                table: "employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChangeReason",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusChangeChoice",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "StatusChangeDate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "StatusChangeReason",
                table: "employees");
        }
    }
}
