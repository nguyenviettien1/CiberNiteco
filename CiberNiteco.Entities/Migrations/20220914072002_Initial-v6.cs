using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiberNiteco.Entities.Migrations
{
    public partial class Initialv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"),
                column: "ConcurrencyStamp",
                value: "64b0c37d-5bfb-49d0-b229-343e6e6f6b27");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b99ec62e-1a92-4cf9-804a-2dff3a699ddc", "AQAAAAEAACcQAAAAELnDy7gNhtlZeus605VlTSjqJ0d2ZLum501ra69K/5Nwzu4Qs/P3RayoatUxta41dg==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "OrderName" },
                values: new object[] { new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "Đơn hàng đầu tiên test" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderDate", "OrderName" },
                values: new object[] { new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "Đơn hàng thứ hai test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"),
                column: "ConcurrencyStamp",
                value: "e04cf57e-14d3-4273-88f9-3f41c7d752a8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "525a6404-8c12-41f6-b920-559f3b5b7da3", "AQAAAAEAACcQAAAAEP7MRiCGUTkNjXaOs02z1BIjMRLHdus8970ujUhWfaOzNC1/K7CtgUs9PK7rLMDcnA==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
