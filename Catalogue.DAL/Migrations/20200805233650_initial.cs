using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalogue.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PreviousStatus = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    StatusChangedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UPC = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OrdersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CustomerId", "Login", "Password" },
                values: new object[] { 1, "customer1Mng", "Manager", "manager123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CustomerId", "Login", "Password" },
                values: new object[] { 2, "customer2usr", "User1", "usr1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CustomerId", "Login", "Password" },
                values: new object[] { 3, "customer3usr", "User2", "usr2" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "PreviousStatus", "Status", "StatusChangedAt", "UserId" },
                values: new object[] { 1, new DateTime(2020, 8, 5, 23, 36, 49, 401, DateTimeKind.Utc).AddTicks(4083), null, 0, null, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "PreviousStatus", "Status", "StatusChangedAt", "UserId" },
                values: new object[] { 2, new DateTime(2020, 8, 5, 23, 36, 49, 401, DateTimeKind.Utc).AddTicks(5517), null, 0, null, 3 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "OrdersId", "Price", "UPC" },
                values: new object[,]
                {
                    { 1, "iPhone 6s", 1, 121.25m, 1001m },
                    { 4, "iPhone X", 1, 950.50m, 100101m },
                    { 2, "Lenovo ThinkPad", 2, 215m, 10010m },
                    { 3, "some", 2, 50m, 851205m },
                    { 5, "MacBook Pro 13", 2, 1200.50m, 20213m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrdersId",
                table: "Items",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
