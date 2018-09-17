using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class DeleteDateFromOrderController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2015, 7, 25, 12, 30, 33, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2015, 8, 25, 12, 35, 33, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {        
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");
        }
    }
}
