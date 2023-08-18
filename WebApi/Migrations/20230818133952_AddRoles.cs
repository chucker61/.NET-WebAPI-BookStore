using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2829afc6-5c23-4372-89e1-bbfb3f8a97e1", "bf8acb67-b4bf-41fd-9e7b-4796357dd5f9", "Editor", "EDITOR" },
                    { "54ece0bc-bdb3-4184-bf17-b189a5e2ebca", "af10f1fb-ccb5-4770-9ee4-8783b2eb8b5f", "Administrator", "ADMINISTRATOR" },
                    { "e703ad4e-3580-4e24-9ef3-56b07539f703", "7b0c13d7-4638-457b-90a9-251672f11c7c", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2829afc6-5c23-4372-89e1-bbfb3f8a97e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54ece0bc-bdb3-4184-bf17-b189a5e2ebca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e703ad4e-3580-4e24-9ef3-56b07539f703");
        }
    }
}
