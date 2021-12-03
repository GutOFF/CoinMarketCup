using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class add_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7704d2f0-b195-4392-b9dc-eb485a1c44c2", "55ff42e4-a956-427c-a74b-926de0bcb72c", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c935d42-265b-4149-af5f-0ca4095dc02d", "c8176b11-4928-4b58-8e64-dcbb1046f6a5", "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7704d2f0-b195-4392-b9dc-eb485a1c44c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c935d42-265b-4149-af5f-0ca4095dc02d");
        }
    }
}
