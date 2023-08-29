using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingRefreshTokenv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e5d707c-d803-4c3e-b1f3-26c22bb0de1d", "c69b2c4d-0457-483b-bb88-c1112f1a8ceb", "Editor", "EDITOR" },
                    { "78c48b06-5eb9-4e53-b9dc-d02b6597d244", "6a3ed7a3-308d-4bbc-93bc-ee9a57b3313f", "Administrator", "ADMINISTRATOR" },
                    { "eead54cb-1ec7-4f4e-b4e8-5d492e07eb99", "77d9bb67-8acb-4e25-9dca-69cce05290a5", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e5d707c-d803-4c3e-b1f3-26c22bb0de1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78c48b06-5eb9-4e53-b9dc-d02b6597d244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eead54cb-1ec7-4f4e-b4e8-5d492e07eb99");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
