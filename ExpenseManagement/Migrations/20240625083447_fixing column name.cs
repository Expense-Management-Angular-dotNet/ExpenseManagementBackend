using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagement.Migrations
{
    /// <inheritdoc />
    public partial class fixingcolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2624f47c-572b-4849-95c9-c6188ec6173e", null, "Admin", "ADMIN" },
                    { "8e46ec41-e9dd-40c4-93c8-e4fff903d0f2", null, "User", "USER" },
                    { "aeb4c1ec-12c1-47f8-b2f2-5156d2033dc9", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2624f47c-572b-4849-95c9-c6188ec6173e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e46ec41-e9dd-40c4-93c8-e4fff903d0f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeb4c1ec-12c1-47f8-b2f2-5156d2033dc9");

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
    }
}
