using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIP = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientsID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerService",
                columns: table => new
                {
                    CustomerServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerService", x => x.CustomerServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Dispatcher",
                columns: table => new
                {
                    DispatcherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatcher", x => x.DispatcherID);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceID);
                });

            migrationBuilder.CreateTable(
                name: "Wagons",
                columns: table => new
                {
                    WagonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LoadQty = table.Column<double>(type: "float", nullable: false),
                    LoadType = table.Column<int>(type: "int", nullable: false),
                    WagonType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagons", x => x.WagonID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouseman",
                columns: table => new
                {
                    WarehousemanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouseman", x => x.WarehousemanID);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentID = table.Column<int>(type: "int", nullable: true),
                    ClientsID = table.Column<int>(type: "int", nullable: true),
                    CustomerServiceID = table.Column<int>(type: "int", nullable: true),
                    DispatcherID = table.Column<int>(type: "int", nullable: true),
                    DepartureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    PayloadType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormID);
                    table.ForeignKey(
                        name: "FK_Forms_Clients_FormID",
                        column: x => x.FormID,
                        principalTable: "Clients",
                        principalColumn: "ClientsID");
                    table.ForeignKey(
                        name: "FK_Forms_CustomerService_CustomerServiceID",
                        column: x => x.CustomerServiceID,
                        principalTable: "CustomerService",
                        principalColumn: "CustomerServiceID");
                    table.ForeignKey(
                        name: "FK_Forms_Dispatcher_DispatcherID",
                        column: x => x.DispatcherID,
                        principalTable: "Dispatcher",
                        principalColumn: "DispatcherID");
                });

            migrationBuilder.CreateTable(
                name: "CargoManifests",
                columns: table => new
                {
                    CargoManifestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayloadType = table.Column<int>(type: "int", nullable: false),
                    PayloadQty = table.Column<double>(type: "float", nullable: false),
                    DeparturePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    DispatcherID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoManifests", x => x.CargoManifestID);
                    table.ForeignKey(
                        name: "FK_CargoManifests_Dispatcher_DispatcherID",
                        column: x => x.DispatcherID,
                        principalTable: "Dispatcher",
                        principalColumn: "DispatcherID");
                    table.ForeignKey(
                        name: "FK_CargoManifests_Warehouseman_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Warehouseman",
                        principalColumn: "WarehousemanID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Forms_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Forms",
                        principalColumn: "FormID");
                });

            migrationBuilder.CreateTable(
                name: "CargoManifestWagon",
                columns: table => new
                {
                    CargoManifestsCargoManifestID = table.Column<int>(type: "int", nullable: false),
                    WagonsWagonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoManifestWagon", x => new { x.CargoManifestsCargoManifestID, x.WagonsWagonID });
                    table.ForeignKey(
                        name: "FK_CargoManifestWagon_CargoManifests_CargoManifestsCargoManifestID",
                        column: x => x.CargoManifestsCargoManifestID,
                        principalTable: "CargoManifests",
                        principalColumn: "CargoManifestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoManifestWagon_Wagons_WagonsWagonID",
                        column: x => x.WagonsWagonID,
                        principalTable: "Wagons",
                        principalColumn: "WagonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientsID", "CompanyAddress", "CompanyName", "Email", "NIP", "PhoneNumber", "Type" },
                values: new object[] { 2, "ABC123", "ACME", "abc@gmail.com", 1231273738L, "122334566", "Company" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientsID", "Email", "Name", "PESEL", "PhoneNumber", "Surname", "Type" },
                values: new object[] { 1, "abc@gmail.com", "Jan", 85092234933.0, "122334566", "Kowalski", "Individual" });

            migrationBuilder.InsertData(
                table: "CustomerService",
                columns: new[] { "CustomerServiceID", "Address", "DOB", "Login", "Name", "PESEL", "Password", "Phone", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "Testowa 1/3, Wąchock 27-215,Polska", new DateTime(1992, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkowalski", "Jan", 92010636232.0, "abc123", "123456789", 6000.0, "Kowalski" },
                    { 2, "Testowa 10, Wąchock 27-215,Polska", new DateTime(1965, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "tzielinski", "Toamsz", 65032754459.0, "abc123", "777888999", 9000.0, "Zieliński" }
                });

            migrationBuilder.InsertData(
                table: "Dispatcher",
                columns: new[] { "DispatcherID", "Address", "DOB", "Login", "Name", "PESEL", "Password", "Phone", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "Testowa 1/3, Wąchock 27-215,Polska", new DateTime(1992, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkowalski", "Jan", 92010636232.0, "abc123", "123456789", 6000.0, "Kowalski" },
                    { 2, "Testowa 10, Wąchock 27-215,Polska", new DateTime(1965, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "tzielinski", "Toamsz", 65032754459.0, "abc123", "777888999", 9000.0, "Zieliński" }
                });

            migrationBuilder.InsertData(
                table: "Wagons",
                columns: new[] { "WagonID", "Code", "LoadQty", "LoadType", "Status", "WagonType" },
                values: new object[,]
                {
                    { 7, "YYY123", 123.0, 1, 0, "Gas" },
                    { 9, "XYX123", 123.0, 1, 0, "Gas" },
                    { 10, "ZZY123", 131.0, 1, 0, "Gas" },
                    { 13, "FAZ123", 123.0, 1, 3, "Gas" },
                    { 1, "XYZ123", 33000.0, 0, 0, "Liquid" },
                    { 2, "ZZZ310", 33000.0, 0, 0, "Liquid" },
                    { 3, "DSE223", 33000.0, 0, 0, "Liquid" },
                    { 11, "AAA123", 33000.0, 0, 1, "Liquid" },
                    { 12, "FFF123", 33000.0, 0, 2, "Liquid" },
                    { 4, "GFH030", 58.0, 2, 0, "Loose" },
                    { 5, "KJH330", 58.0, 2, 0, "Loose" },
                    { 6, "LLL330", 58.0, 2, 0, "Loose" },
                    { 14, "XYZ123", 53.0, 2, 3, "Loose" }
                });

            migrationBuilder.InsertData(
                table: "Warehouseman",
                columns: new[] { "WarehousemanID", "Address", "DOB", "Login", "Name", "PESEL", "Password", "Phone", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "Testowa 1/3, Wąchock 27-215,Polska", new DateTime(1992, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkowalski", "Jan", 92010636232.0, "abc123", "123456789", 6000.0, "Kowalski" },
                    { 2, "Testowa 10, Wąchock 27-215,Polska", new DateTime(1965, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "tzielinski", "Toamsz", 65032754459.0, "abc123", "777888999", 9000.0, "Zieliński" }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "FormID", "ClientsID", "CustomerServiceID", "DepartureName", "DestinationName", "DispatcherID", "Distance", "PayloadType", "PaymentID" },
                values: new object[] { 1, 1, 1, "Rzeszów", "Gdańsk", 2, 3600, 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_CargoManifests_DispatcherID",
                table: "CargoManifests",
                column: "DispatcherID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoManifests_EmployeeID",
                table: "CargoManifests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoManifestWagon_WagonsWagonID",
                table: "CargoManifestWagon",
                column: "WagonsWagonID");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_CustomerServiceID",
                table: "Forms",
                column: "CustomerServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_DispatcherID",
                table: "Forms",
                column: "DispatcherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoManifestWagon");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "CargoManifests");

            migrationBuilder.DropTable(
                name: "Wagons");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Warehouseman");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CustomerService");

            migrationBuilder.DropTable(
                name: "Dispatcher");
        }
    }
}
