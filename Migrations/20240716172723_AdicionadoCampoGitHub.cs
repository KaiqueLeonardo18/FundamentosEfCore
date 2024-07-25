using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEf.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoGitHub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2024, 7, 16, 17, 27, 22, 876, DateTimeKind.Utc).AddTicks(9692),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2024, 7, 16, 17, 10, 35, 794, DateTimeKind.Utc).AddTicks(6034));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2024, 7, 16, 17, 10, 35, 794, DateTimeKind.Utc).AddTicks(6034),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2024, 7, 16, 17, 27, 22, 876, DateTimeKind.Utc).AddTicks(9692));
        }
    }
}
