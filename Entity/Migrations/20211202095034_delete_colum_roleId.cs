using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class delete_colum_roleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
