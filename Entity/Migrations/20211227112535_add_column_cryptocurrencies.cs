using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_column_cryptocurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d06e3e5-68e0-49cd-82a9-0d0030022967");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90c61d6-c4e4-4b46-9b10-e50b42093815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bccdce6d-9ad4-4f65-9166-7bdfbb2b6bfb");

            migrationBuilder.AddColumn<int>(
                name: "CoinMarketCupId",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies",
                column: "CoinMarketCupId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_CoinMarketCupId",
                table: "Cryptocurrencies");

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

            migrationBuilder.DropColumn(
                name: "CoinMarketCupId",
                table: "Cryptocurrencies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "bccdce6d-9ad4-4f65-9166-7bdfbb2b6bfb", "bb71b8dd-264e-4602-87fb-be136ada7d97", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "5d06e3e5-68e0-49cd-82a9-0d0030022967", "c5a40eaa-39bf-4bd0-bc79-bec444115d87", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "a90c61d6-c4e4-4b46-9b10-e50b42093815", "65a807da-15ec-49f4-a348-4a50e88c06be", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }
    }
}
