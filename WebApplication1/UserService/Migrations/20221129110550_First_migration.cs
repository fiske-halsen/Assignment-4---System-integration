using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    DoorDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CityInfo_CityInfoId",
                        column: x => x.CityInfoId,
                        principalTable: "CityInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityInfo",
                columns: new[] { "Id", "City", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Hillerød", "3400" },
                    { 2, "Fredensborg", "3480" },
                    { 3, "Taastrup", "2630" },
                    { 4, "Hedehusene", "2640" },
                    { 5, "Charlottenlund", "2920" },
                    { 6, "", "3000" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleType" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "DeliveryPerson" },
                    { 3, "RestaurantOwner" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "CityInfoId", "DoorDesignation", "Floor", "HouseNumber", "StreetName" },
                values: new object[,]
                {
                    { 1, 1, "tv", 3, "94A", "Skovledet" },
                    { 2, 5, null, 2, "23", "Cphbusinessvej" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAt", "Email", "FirstName", "ModifiedAt", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 29, 11, 5, 50, 435, DateTimeKind.Utc).AddTicks(8521), "phillip.andersen1999@gmail.com", "Phillip", new DateTime(2022, 11, 29, 11, 5, 50, 435, DateTimeKind.Utc).AddTicks(8522), "$2a$11$Yk2U4SyytJBzKG8aMyf27.fvvc9Qw9qFpxuPoPX/xU0V8cyNvwB.G", 1 },
                    { 2, 2, new DateTime(2022, 11, 29, 11, 5, 50, 548, DateTimeKind.Utc).AddTicks(2305), "lukasbangstoltz@gmail.com", "Lukas", new DateTime(2022, 11, 29, 11, 5, 50, 548, DateTimeKind.Utc).AddTicks(2316), "$2a$11$Qjq63Y9T/g1Ye5YlUmmPVOfBh/SVoSlJP/qZKrPznX7XuL4gmPU/i", 3 },
                    { 3, 2, new DateTime(2022, 11, 29, 11, 5, 50, 661, DateTimeKind.Utc).AddTicks(2520), "christofferiw@gmail.com", "Christoffer", new DateTime(2022, 11, 29, 11, 5, 50, 661, DateTimeKind.Utc).AddTicks(2524), "$2a$11$.OUQUdFRTi.oRYa6eWq9nOQsV1I8yyDEalJVPnOKslLjlg13Qx8ba", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityInfoId",
                table: "Address",
                column: "CityInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CityInfo");
        }
    }
}
