using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_role_start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f96b59-df96-4f27-a232-c52af3f075d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660dd70f-a5fd-47bd-a9cc-cd0fd99c3791");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6288c46-de95-4e06-a8a1-aca0c390ab35");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "660dd70f-a5fd-47bd-a9cc-cd0fd99c3791", "10f4acdd-a75b-487d-8ff7-84468281cdc5", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39f96b59-df96-4f27-a232-c52af3f075d0", "f52cc214-48ee-4fb7-8734-c5f1d6f3aa81", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6288c46-de95-4e06-a8a1-aca0c390ab35", "99b28ac3-c0ec-467b-9c88-97e6f4f3cf66", "superAdmin", null });
        }
    }
}
