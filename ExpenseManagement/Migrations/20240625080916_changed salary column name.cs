using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagement.Migrations
{
    /// <inheritdoc />
    public partial class changedsalarycolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LastChangedDate",
                table: "SalaryRecords",
                newName: "ForTheMonth");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471d44e7-e8f4-4c11-8216-9f9a43bdea3e", null, "Admin", "ADMIN" },
                    { "cc3140d9-ea2d-4f10-b7c5-12d30372ca10", null, "Manager", "MANAGER" },
                    { "e4ee6cd8-ab12-4aed-9d14-285174891e6f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471d44e7-e8f4-4c11-8216-9f9a43bdea3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc3140d9-ea2d-4f10-b7c5-12d30372ca10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4ee6cd8-ab12-4aed-9d14-285174891e6f");

            migrationBuilder.RenameColumn(
                name: "ForTheMonth",
                table: "SalaryRecords",
                newName: "LastChangedDate");

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
    }
}
