using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_boilerplate.Migrations
{
    public partial class RemoveTimestampFromDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Device");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Device",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Device",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Device",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
