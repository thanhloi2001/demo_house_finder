using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Mock_House_Finder.Migrations
{
    /// <inheritdoc />
    public partial class editRateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Rate",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rate",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 1, 24, 17, 990, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 1, 24, 17, 990, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 1, 24, 17, 990, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 1, 24, 17, 990, DateTimeKind.Local).AddTicks(6405));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Rate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 17, 29, 47, 300, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 17, 29, 47, 300, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 17, 29, 47, 300, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "RoleID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 17, 29, 47, 300, DateTimeKind.Local).AddTicks(5937));
        }
    }
}
