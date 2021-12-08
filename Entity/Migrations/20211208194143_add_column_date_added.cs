using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_column_date_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateAdded",
                table: "Cryptocurrencies",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "efcbca60-fdb9-4210-8cb0-c4b04c9f6ec1", "6a4ae3c6-a7f4-43f2-8e81-053d0de44faf", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "1a2adfc7-dad2-4e52-ad9e-9773374c8240", "5604ea0e-5d34-4468-b1c9-6bf5f6737076", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "bfff1aeb-19c9-4185-956d-e8ba0378769d", "27eb1c45-1888-464b-9662-726ee1110946", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2adfc7-dad2-4e52-ad9e-9773374c8240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfff1aeb-19c9-4185-956d-e8ba0378769d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efcbca60-fdb9-4210-8cb0-c4b04c9f6ec1");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cryptocurrencies");

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
    }
}
