using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagement.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4936d661-3d7c-4bf8-8647-a6cfa6349854");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7abeccbc-b0b0-479f-a7c3-760393981117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada941dd-9508-4017-b362-b5ae363fec8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86cf5901-c61c-4787-93f7-6e5b6c2de2de", null, "Admin", "ADMIN" },
                    { "adb94674-3133-41c9-adb0-bdfe59ed8f09", null, "User", "USER" },
                    { "b2d192f7-c0fa-4455-935e-66ac842206ad", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86cf5901-c61c-4787-93f7-6e5b6c2de2de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb94674-3133-41c9-adb0-bdfe59ed8f09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2d192f7-c0fa-4455-935e-66ac842206ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4936d661-3d7c-4bf8-8647-a6cfa6349854", null, "User", "USER" },
                    { "7abeccbc-b0b0-479f-a7c3-760393981117", null, "Manager", "MANAGER" },
                    { "ada941dd-9508-4017-b362-b5ae363fec8a", null, "Admin", "ADMIN" }
                });
        }
    }
}
