using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d047619-0db4-48c3-bcd7-6b2106c4d452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f33572-7303-42b5-a4fa-bf4ae61c1476");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efa6c420-489e-4c37-8d39-c698d9c34c83");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "370224a0-e365-46df-8e3f-b54117cb3bad", "0e599cd6-14ac-49cc-921a-b0d473d0f78b", "Administrator", "ADMINISTRATOR" },
                    { "94496cd5-c836-48f7-8b8d-647ff909e4ae", "a8ef78ea-9938-403c-95f3-1cbc1884f6c5", "User", "USER" },
                    { "b575b653-bc08-491e-b6d4-020c63f1d6f3", "a4a07a99-0f75-4b7c-bef3-993fe9244068", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "370224a0-e365-46df-8e3f-b54117cb3bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94496cd5-c836-48f7-8b8d-647ff909e4ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b575b653-bc08-491e-b6d4-020c63f1d6f3");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d047619-0db4-48c3-bcd7-6b2106c4d452", "be91a54c-5d30-47af-bbb0-0ef55673daa4", "User", "USER" },
                    { "e4f33572-7303-42b5-a4fa-bf4ae61c1476", "49a93622-7208-435e-b73b-b7936b54b809", "Administrator", "ADMINISTRATOR" },
                    { "efa6c420-489e-4c37-8d39-c698d9c34c83", "a9039c6e-1f14-4da8-80b1-c4d6e20e0a25", "Editor", "EDITOR" }
                });
        }
    }
}
