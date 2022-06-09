using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestExample2.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerOne = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrder",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrder", x => x.IdClientOrder);
                    table.ForeignKey(
                        name: "FK_ClientOrder_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientOrder_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_ClientOrder",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false),
                    IdConfectionary = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_ClientOrder", x => new { x.IdClientOrder, x.IdConfectionary });
                    table.ForeignKey(
                        name: "FK_Confectionery_ClientOrder_ClientOrder_IdClientOrder",
                        column: x => x.IdClientOrder,
                        principalTable: "ClientOrder",
                        principalColumn: "IdClientOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confectionery_ClientOrder_Confectionery_IdConfectionary",
                        column: x => x.IdConfectionary,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrder_IdClient",
                table: "ClientOrder",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrder_IdEmployee",
                table: "ClientOrder",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_ClientOrder_IdConfectionary",
                table: "Confectionery_ClientOrder",
                column: "IdConfectionary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_ClientOrder");

            migrationBuilder.DropTable(
                name: "ClientOrder");

            migrationBuilder.DropTable(
                name: "Confectionery");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
