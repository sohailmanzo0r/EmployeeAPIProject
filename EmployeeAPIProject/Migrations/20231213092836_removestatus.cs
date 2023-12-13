using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class removestatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "laterstatus",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "status",
                table: "employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "laterstatus",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
