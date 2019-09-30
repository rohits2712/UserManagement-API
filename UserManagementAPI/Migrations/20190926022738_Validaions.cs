using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementAPI.Migrations
{
    public partial class Validaions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0449cc2-eb6b-48aa-8333-3cab43166b8e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "GivenName", "ManagerId", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("29c699fb-3141-4878-8b3d-520700065b00"), "a@x.com", "Rohit", new Guid("00000000-0000-0000-0000-000000000000"), "4242", "Sharma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("29c699fb-3141-4878-8b3d-520700065b00"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "GivenName", "ManagerId", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("b0449cc2-eb6b-48aa-8333-3cab43166b8e"), "a@x.com", "Rohit", new Guid("00000000-0000-0000-0000-000000000000"), "4242", "Sharma" });
        }
    }
}
