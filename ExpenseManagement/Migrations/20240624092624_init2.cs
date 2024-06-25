using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagement.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab5d7478-e8df-4085-a4d2-b48c79c64c2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5cd195a-9ab7-44ed-aed5-0458944ae06f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77e9423-a21e-48a3-8122-1883c8e3b2b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f57af2c-0ff6-48d6-ada6-f34891315698", null, "Manager", "MANAGER" },
                    { "53a3e10a-a868-4285-8f5b-bd08db73ef5f", null, "User", "USER" },
                    { "dbe85e48-b11f-4489-b648-96655b6a52ca", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f57af2c-0ff6-48d6-ada6-f34891315698");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53a3e10a-a868-4285-8f5b-bd08db73ef5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe85e48-b11f-4489-b648-96655b6a52ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab5d7478-e8df-4085-a4d2-b48c79c64c2f", null, "User", "USER" },
                    { "e5cd195a-9ab7-44ed-aed5-0458944ae06f", null, "Manager", "MANAGER" },
                    { "e77e9423-a21e-48a3-8122-1883c8e3b2b4", null, "Admin", "ADMIN" }
                });
        }
    }
}
