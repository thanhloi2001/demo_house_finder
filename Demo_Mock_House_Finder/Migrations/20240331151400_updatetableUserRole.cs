using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_Mock_House_Finder.Migrations
{
    /// <inheritdoc />
    public partial class updatetableUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleID", "CreatedDate", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1163), "Admin" },
                    { 2, new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1179), "Staff" },
                    { 3, new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1181), "Landlord" },
                    { 4, new DateTime(2024, 3, 31, 22, 14, 0, 300, DateTimeKind.Local).AddTicks(1182), "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 4);
        }
    }
}
