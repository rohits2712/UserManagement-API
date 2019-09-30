using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementAPI.Migrations
{
    public partial class Validations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GivenName",
                table: "Users",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "GivenName", "ManagerId", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("b0449cc2-eb6b-48aa-8333-3cab43166b8e"), "a@x.com", "Rohit", new Guid("00000000-0000-0000-0000-000000000000"), "4242", "Sharma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0449cc2-eb6b-48aa-8333-3cab43166b8e"));

            migrationBuilder.AlterColumn<string>(
                name: "GivenName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
