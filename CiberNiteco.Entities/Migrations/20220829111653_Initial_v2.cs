using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiberNiteco.Entities.Migrations
{
    public partial class Initial_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Danh mục các đồ uống", "Đồ uống" },
                    { 2, "Danh mục các thực phẩm", "Đồ ăn" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "Tạp hóa Minh Anh" },
                    { 2, "Bắc Ninh", "Siêu thị Kim Ngân" },
                    { 3, "Bắc Giang", "Nhà hàng Hùng Cường" },
                    { 4, "Vĩnh Phúc", "Nhà hàng Thu Cúc" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Sản phẩm của Habeco", "Bia Trúc Bạch", 15000m, 1600m },
                    { 2, 1, "Sản phẩm của Habeco", "Bia BOLD", 12000m, 1800m },
                    { 5, 1, "Sản phẩm của TH True Milk", "Sữa TH", 8000m, 5700m },
                    { 3, 2, "Sản phẩm của MenVodka", "Chân gà vị cay - 30g", 9000m, 5000m },
                    { 4, 2, "Sản phẩm của MenVodka", "Chân gà vị mật ong - 30g", 10000m, 4000m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 2, 170m, 3, new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 1, 20m, 1, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });
        }
    }
}
