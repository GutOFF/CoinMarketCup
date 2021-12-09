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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cryptocurrencies",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
