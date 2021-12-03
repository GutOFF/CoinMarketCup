using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_role_db_set : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "023e1a70-7258-42b6-968b-3e0cf44b000c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cede13a-22db-4220-9ef7-f6021017d4e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354f98dd-4a81-4375-9f50-7b0e95f356cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "5d8a5b96-3fc4-41c6-9351-8b0bca649d9f", "5138d6ce-00e8-4190-86a6-e4b273b34fb6", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "c176884f-c885-4174-8873-811fb037e659", "f75401db-d13d-4d5a-b1b4-dfd1b6e6f4f4", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "c994b3af-fe56-4859-a61f-0a5f01c8087a", "d07c4445-e9c2-4704-8343-4132490d9a40", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d8a5b96-3fc4-41c6-9351-8b0bca649d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c176884f-c885-4174-8873-811fb037e659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c994b3af-fe56-4859-a61f-0a5f01c8087a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "1cede13a-22db-4220-9ef7-f6021017d4e1", "3ef2e13b-39f0-4bd4-a00e-1c585ca448c5", "Role", true, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "354f98dd-4a81-4375-9f50-7b0e95f356cf", "8a795d0a-2e7d-409d-bf4b-16dd8b4377b2", "Role", true, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsPublish", "Name", "NormalizedName" },
                values: new object[] { "023e1a70-7258-42b6-968b-3e0cf44b000c", "319102b9-68b9-43d0-9876-fa3eddcec12d", "Role", false, "SuperAdmin", "SUPERADMIN" });
        }
    }
}
