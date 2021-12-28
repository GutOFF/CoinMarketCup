using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_column_fiat_currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "FiatCurrency",
                table: "SettingCryptocurrency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b50865fd-fa79-4205-a633-c20b5b1d9eef", "8ae4d8ac-0d48-4b4b-9038-9f6ea578a7de", "Role", true, "Admin", "ADMIN" },
                    { "c4cfc0d5-1384-4289-a71b-1d886ffff5a8", "bf14fe24-0f1c-4919-a822-ff1c31103412", "Role", true, "User", "USER" },
                    { "b1190ae0-97ae-4c14-b0ec-d69141c28fdd", "597e62c4-0832-49d4-b293-abbb1e38f04c", "Role", false, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "SettingCryptocurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FiatCurrency", "LastUpdateDate" },
                values: new object[] { "USD", new DateTime(2021, 12, 28, 8, 24, 22, 622, DateTimeKind.Utc).AddTicks(4387) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1190ae0-97ae-4c14-b0ec-d69141c28fdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b50865fd-fa79-4205-a633-c20b5b1d9eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4cfc0d5-1384-4289-a71b-1d886ffff5a8");

            migrationBuilder.DropColumn(
                name: "FiatCurrency",
                table: "SettingCryptocurrency");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d80ce14-c40f-4ec0-b0e8-8215d9d1f5c5", "4b245f0a-fa0d-4cf3-95f1-3834882dfe68", "Role", true, "Admin", "ADMIN" },
                    { "2bad56c2-4886-4ec5-ad57-f54efb0d393d", "00e77d06-2572-49de-8dbc-cec6bffa115e", "Role", true, "User", "USER" },
                    { "5e7939a4-30c4-44ee-96c9-7b8be4075783", "9abc2e0d-def9-4753-9b39-2c1806364388", "Role", false, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "SettingCryptocurrency",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdateDate",
                value: new DateTime(2021, 12, 28, 7, 54, 36, 102, DateTimeKind.Utc).AddTicks(1272));
        }
    }
}
