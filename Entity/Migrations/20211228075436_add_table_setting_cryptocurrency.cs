using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_table_setting_cryptocurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a8f804-ea7a-4581-a5c3-fc414ec283c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f2d4e7-400b-4ee3-90a8-41f7ed80bcad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4e1cc15-3d8a-4884-8b74-92cb46cfc350");

            migrationBuilder.CreateTable(
                name: "SettingCryptocurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCountMetadata = table.Column<int>(type: "int", nullable: false),
                    ExpiryDateExpired = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingCryptocurrency", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d80ce14-c40f-4ec0-b0e8-8215d9d1f5c5", "4b245f0a-fa0d-4cf3-95f1-3834882dfe68", "Role", true, "Admin", "ADMIN" },
                    { "2bad56c2-4886-4ec5-ad57-f54efb0d393d", "00e77d06-2572-49de-8dbc-cec6bffa115e", "Role", true, "User", "USER" },
                    { "5e7939a4-30c4-44ee-96c9-7b8be4075783", "9abc2e0d-def9-4753-9b39-2c1806364388", "Role", false, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "SettingCryptocurrency",
                columns: new[] { "Id", "ApiKey", "ExpiryDateExpired", "LastUpdateDate", "Limit", "MaxCountMetadata" },
                values: new object[] { 1, "10c2408c-f3fd-4c1e-801e-b97ba3bba899", 5, new DateTime(2021, 12, 28, 7, 54, 36, 102, DateTimeKind.Utc).AddTicks(1272), 5000, 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingCryptocurrency");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bad56c2-4886-4ec5-ad57-f54efb0d393d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d80ce14-c40f-4ec0-b0e8-8215d9d1f5c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e7939a4-30c4-44ee-96c9-7b8be4075783");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "b4e1cc15-3d8a-4884-8b74-92cb46cfc350", "94eee448-281c-4127-948b-4227784a099f", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "a2f2d4e7-400b-4ee3-90a8-41f7ed80bcad", "a1508329-8c6c-468d-9321-a98f0d24382c", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "04a8f804-ea7a-4581-a5c3-fc414ec283c0", "13c640a9-7418-435a-b7c5-b6ab7a77c55d", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }
    }
}
