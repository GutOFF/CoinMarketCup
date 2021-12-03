using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_role_superAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7704d2f0-b195-4392-b9dc-eb485a1c44c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c935d42-265b-4149-af5f-0ca4095dc02d");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7704d2f0-b195-4392-b9dc-eb485a1c44c2", "55ff42e4-a956-427c-a74b-926de0bcb72c", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c935d42-265b-4149-af5f-0ca4095dc02d", "c8176b11-4928-4b58-8e64-dcbb1046f6a5", "user", null });
        }
    }
}
