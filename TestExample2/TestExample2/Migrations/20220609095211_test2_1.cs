using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestExample2.Migrations
{
    public partial class test2_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "FirstName", "LastName" },
                values: new object[] { 1, "Mateusz", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "PricePerOne" },
                values: new object[] { 1, "Shoe", 2f });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmployee", "FirstName", "LastName" },
                values: new object[] { 1, "Przemek", "Kowal" });

            migrationBuilder.InsertData(
                table: "ClientOrder",
                columns: new[] { "IdClientOrder", "Comments", "CompletionDate", "IdClient", "IdEmployee", "OrderDate" },
                values: new object[] { 1, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Confectionery_ClientOrder",
                columns: new[] { "IdClientOrder", "IdConfectionary", "Amount", "Comments" },
                values: new object[] { 1, 1, 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Confectionery_ClientOrder",
                keyColumns: new[] { "IdClientOrder", "IdConfectionary" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClientOrder",
                keyColumn: "IdClientOrder",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 1);
        }
    }
}
