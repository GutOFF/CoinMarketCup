using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class edit_coin_market_cup_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "218f4a60-0292-4afa-9e38-015b8d9c03db", "678610bd-796b-4593-84bf-6193d1de3d3e", "Role", true, "Admin", "ADMIN" },
                    { "ce2ecdcf-daca-44f4-8305-67b5f838db30", "d3dfafa5-75bc-4dd9-8a82-032d5593e209", "Role", true, "User", "USER" },
                    { "2a2c64b2-90e3-4e03-a9e2-ec63a8e856ca", "fdd603e1-570a-4c1f-a8e4-40a5ff73a34e", "Role", false, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "SettingCryptocurrency",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdateDate",
                value: new DateTime(2021, 12, 29, 10, 11, 20, 101, DateTimeKind.Utc).AddTicks(3250));

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies",
                column: "CoinMarketCupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "218f4a60-0292-4afa-9e38-015b8d9c03db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a2c64b2-90e3-4e03-a9e2-ec63a8e856ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2ecdcf-daca-44f4-8305-67b5f838db30");

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
                column: "LastUpdateDate",
                value: new DateTime(2021, 12, 28, 8, 24, 22, 622, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies",
                column: "CoinMarketCupId",
                unique: true);
        }
    }
}
