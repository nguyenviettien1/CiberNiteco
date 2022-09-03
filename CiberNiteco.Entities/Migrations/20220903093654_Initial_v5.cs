using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiberNiteco.Entities.Migrations
{
    public partial class Initial_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"), "e04cf57e-14d3-4273-88f9-3f41c7d752a8", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"), new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d"), 0, "525a6404-8c12-41f6-b920-559f3b5b7da3", new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "viettien98htttbn@gmail.com", true, "Tien", "Nguyen", false, null, "viettien98htttbn@gmail.com", "admin", "AQAAAAEAACcQAAAAEP7MRiCGUTkNjXaOs02z1BIjMRLHdus8970ujUhWfaOzNC1/K7CtgUs9PK7rLMDcnA==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("175ee44a-cc60-45d4-8ebb-8f3b072d38f8"), new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3728fd0a-eda0-4bf8-9048-0b7839f0404d"));
        }
    }
}
