using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_table_cryptocurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "700e284d-c51b-4a0f-975e-c400eff2d6e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6c2b64-3011-4ea1-8c53-8328db0c24df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db0f821c-097c-417b-884c-828362e90532");

            migrationBuilder.CreateTable(
                name: "Cryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentChange1H = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentChange24H = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarketCap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptocurrencies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "2ca6ba69-8178-4c6a-8f2f-ae130c559782", "6ad99e7b-32f1-4dec-a215-c5bde1fa13ae", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "dd7237e5-b320-4e12-9961-ce7e9f7bbf7c", "54742393-e0db-44d9-b31b-542a457d8e2b", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "d0bbb684-371a-48e9-a40b-a0db419aa4b1", "c20630e4-1a0b-4fe4-8860-f9693bc85df1", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptocurrencies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca6ba69-8178-4c6a-8f2f-ae130c559782");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0bbb684-371a-48e9-a40b-a0db419aa4b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd7237e5-b320-4e12-9961-ce7e9f7bbf7c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "700e284d-c51b-4a0f-975e-c400eff2d6e2", "17d69fb4-b0e2-4d2f-9526-b3c1247b2aac", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "ac6c2b64-3011-4ea1-8c53-8328db0c24df", "7926d01a-268f-48c6-866b-e4bed78a608b", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "db0f821c-097c-417b-884c-828362e90532", "c8e3940c-5907-448d-a43a-bf36eca8e1fc", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }
    }
}
