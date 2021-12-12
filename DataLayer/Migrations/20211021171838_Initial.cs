using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSignedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    CatagoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.CatagoryID);
                });

            migrationBuilder.CreateTable(
                name: "Infomation",
                columns: table => new
                {
                    InfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postal = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infomation", x => x.InfoID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumbér = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Infomation_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Infomation",
                        principalColumn: "InfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductsDetails",
                columns: table => new
                {
                    OrderProductsDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductsDetails", x => x.OrderProductsDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderProductsDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productCatagories",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CatagoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCatagories", x => new { x.ProductID, x.CatagoryID });
                    table.ForeignKey(
                        name: "FK_productCatagories_Catagories_CatagoryID",
                        column: x => x.CatagoryID,
                        principalTable: "Catagories",
                        principalColumn: "CatagoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productCatagories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumStars = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "IsSignedIn", "Password", "Username" },
                values: new object[] { 1, false, "123", "HR" });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "CatagoryID", "CatagoryName" },
                values: new object[,]
                {
                    { 14, "Bed" },
                    { 12, "LivingRoom" },
                    { 11, "Kitchen" },
                    { 10, "Shelf" },
                    { 9, "Breach" },
                    { 8, "Winter" },
                    { 13, "Bedroom" },
                    { 6, "Outdoor" },
                    { 5, "Light" },
                    { 4, "Sofa" },
                    { 3, "Combo" },
                    { 2, "Tabls" },
                    { 7, "Sommer" },
                    { 1, "Chair" }
                });

            migrationBuilder.InsertData(
                table: "Infomation",
                columns: new[] { "InfoID", "City", "Country", "Postal", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 2, "Bedroom.City", "Somewhere Bedroom", 9504, "Bedroom Street", 2 },
                    { 3, "Light.City", "Somewhere Light", 3032, "Light Street", 3 },
                    { 1, "Kitchen.City", "Somewhere Kitchen", 3439, "Kitchen Street", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "BuyDate", "Email" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7274), "ThisIsThe@Best.Email" },
                    { 1, new DateTime(2021, 10, 21, 19, 18, 37, 213, DateTimeKind.Local).AddTicks(6592), "ThisIsThe@Best.Email" },
                    { 2, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7071), "ThisIsThe@Best.Email" },
                    { 3, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7151), "ThisIsThe@Best.Email" },
                    { 4, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7179), "ThisIsThe@Best.Email" },
                    { 5, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7202), "ThisIsThe@Best.Email" },
                    { 6, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7229), "ThisIsThe@Best.Email" },
                    { 7, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7252), "ThisIsThe@Best.Email" },
                    { 9, new DateTime(2021, 10, 21, 19, 18, 37, 216, DateTimeKind.Local).AddTicks(7297), "ThisIsThe@Best.Email" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "Email", "InfoID", "ManufacturerName", "PhoneNumbér" },
                values: new object[,]
                {
                    { 1, "Manufacturer-1@Email.Kitchen", 1, "Manufacturer-1", 26822522 },
                    { 2, "Manufacturer-2@Email.Bedroom", 2, "Manufacturer-2", 44033026 },
                    { 3, "Manufacturer-3@Email.Light", 3, "Manufacturer-3", 40168794 }
                });

            migrationBuilder.InsertData(
                table: "OrderProductsDetails",
                columns: new[] { "OrderProductsDetailsId", "Navn", "OrderID", "Pris", "ProductID" },
                values: new object[,]
                {
                    { 44, "Bedroom", 5, 468.0, 27 },
                    { 47, "Tabls", 5, 194.0, 8 },
                    { 48, "Breach", 5, 253.0, 41 },
                    { 2, "Light", 6, 368.0, 38 },
                    { 4, "Bed", 6, 152.0, 2 },
                    { 10, "Breach", 6, 424.0, 3 },
                    { 17, "Breach", 6, 206.0, 38 },
                    { 20, "Bed", 6, 301.0, 31 },
                    { 23, "Outdoor", 6, 444.0, 44 },
                    { 11, "Winter", 7, 50.0, 27 },
                    { 18, "Bed", 7, 38.0, 38 },
                    { 27, "Sommer", 5, 113.0, 36 },
                    { 19, "Breach", 7, 389.0, 15 },
                    { 33, "Breach", 7, 67.0, 38 },
                    { 13, "Bed", 8, 252.0, 25 },
                    { 16, "Bedroom", 8, 456.0, 28 },
                    { 29, "Sommer", 8, 180.0, 14 },
                    { 41, "Tabls", 8, 442.0, 45 },
                    { 46, "Light", 8, 166.0, 34 },
                    { 3, "Outdoor", 9, 475.0, 43 },
                    { 37, "Breach", 9, 89.0, 43 },
                    { 12, "Bedroom", 7, 313.0, 43 },
                    { 15, "Breach", 5, 445.0, 1 },
                    { 6, "Light", 5, 191.0, 1 },
                    { 38, "Bed", 9, 321.0, 42 },
                    { 24, "Combo", 1, 336.0, 17 },
                    { 28, "Breach", 1, 149.0, 9 },
                    { 31, "Outdoor", 1, 135.0, 8 },
                    { 42, "Chair", 1, 279.0, 27 },
                    { 45, "Sommer", 1, 234.0, 1 },
                    { 7, "Sommer", 2, 430.0, 39 },
                    { 8, "Kitchen", 2, 141.0, 26 },
                    { 14, "LivingRoom", 2, 458.0, 17 },
                    { 25, "Breach", 2, 85.0, 11 },
                    { 26, "Sommer", 2, 418.0, 48 },
                    { 9, "Breach", 5, 61.0, 16 },
                    { 30, "Outdoor", 2, 421.0, 34 },
                    { 21, "Combo", 3, 105.0, 5 },
                    { 22, "Chair", 3, 206.0, 22 }
                });

            migrationBuilder.InsertData(
                table: "OrderProductsDetails",
                columns: new[] { "OrderProductsDetailsId", "Navn", "OrderID", "Pris", "ProductID" },
                values: new object[,]
                {
                    { 32, "Bedroom", 3, 300.0, 23 },
                    { 35, "Sofa", 3, 397.0, 48 },
                    { 36, "Sofa", 3, 336.0, 44 },
                    { 39, "Outdoor", 3, 404.0, 48 },
                    { 49, "Breach", 3, 92.0, 40 },
                    { 1, "Sofa", 4, 276.0, 49 },
                    { 5, "LivingRoom", 4, 436.0, 23 },
                    { 43, "Tabls", 4, 286.0, 7 },
                    { 34, "Sommer", 2, 82.0, 21 },
                    { 40, "Kitchen", 9, 180.0, 39 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ManufacturerID", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 2, 1, 398.49000000000001, "This is the Description for product-2", "Product-2" },
                    { 35, 2, 64.219999999999999, "This is the Description for product-35", "Product-35" },
                    { 36, 2, 146.87, "This is the Description for product-36", "Product-36" },
                    { 40, 2, 417.77999999999997, "This is the Description for product-40", "Product-40" },
                    { 42, 2, 33.939999999999998, "This is the Description for product-42", "Product-42" },
                    { 44, 2, 255.22, "This is the Description for product-44", "Product-44" },
                    { 45, 2, 310.23000000000002, "This is the Description for product-45", "Product-45" },
                    { 46, 2, 186.65000000000001, "This is the Description for product-46", "Product-46" },
                    { 47, 2, 264.32999999999998, "This is the Description for product-47", "Product-47" },
                    { 48, 2, 221.15000000000001, "This is the Description for product-48", "Product-48" },
                    { 1, 3, 349.05000000000001, "This is the Description for product-1", "Product-1" },
                    { 5, 3, 367.27999999999997, "This is the Description for product-5", "Product-5" },
                    { 9, 3, 206.50999999999999, "This is the Description for product-9", "Product-9" },
                    { 15, 3, 47.009999999999998, "This is the Description for product-15", "Product-15" },
                    { 16, 3, 188.63, "This is the Description for product-16", "Product-16" },
                    { 23, 3, 295.76999999999998, "This is the Description for product-23", "Product-23" },
                    { 27, 3, 49.359999999999999, "This is the Description for product-27", "Product-27" },
                    { 28, 3, 287.51999999999998, "This is the Description for product-28", "Product-28" },
                    { 29, 3, 369.19999999999999, "This is the Description for product-29", "Product-29" },
                    { 31, 3, 121.36, "This is the Description for product-31", "Product-31" },
                    { 32, 3, 166.96000000000001, "This is the Description for product-32", "Product-32" },
                    { 33, 3, 13.31, "This is the Description for product-33", "Product-33" },
                    { 34, 2, 407.00999999999999, "This is the Description for product-34", "Product-34" },
                    { 38, 3, 214.44999999999999, "This is the Description for product-38", "Product-38" },
                    { 30, 2, 95.209999999999994, "This is the Description for product-30", "Product-30" },
                    { 24, 2, 317.55000000000001, "This is the Description for product-24", "Product-24" },
                    { 4, 1, 27.82, "This is the Description for product-4", "Product-4" },
                    { 11, 1, 429.31999999999999, "This is the Description for product-11", "Product-11" },
                    { 12, 1, 117.63, "This is the Description for product-12", "Product-12" },
                    { 22, 1, 375.29000000000002, "This is the Description for product-22", "Product-22" },
                    { 26, 1, 315.89999999999998, "This is the Description for product-26", "Product-26" },
                    { 37, 1, 93.170000000000002, "This is the Description for product-37", "Product-37" },
                    { 39, 1, 24.489999999999998, "This is the Description for product-39", "Product-39" },
                    { 41, 1, 342.07999999999998, "This is the Description for product-41", "Product-41" },
                    { 49, 1, 394.25999999999999, "This is the Description for product-49", "Product-49" },
                    { 3, 2, 24.27, "This is the Description for product-3", "Product-3" },
                    { 6, 2, 6.3799999999999999, "This is the Description for product-6", "Product-6" },
                    { 7, 2, 125.73, "This is the Description for product-7", "Product-7" },
                    { 8, 2, 5.5800000000000001, "This is the Description for product-8", "Product-8" },
                    { 10, 2, 7.0, "This is the Description for product-10", "Product-10" },
                    { 13, 2, 87.879999999999995, "This is the Description for product-13", "Product-13" },
                    { 14, 2, 163.80000000000001, "This is the Description for product-14", "Product-14" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ManufacturerID", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 17, 2, 11.93, "This is the Description for product-17", "Product-17" },
                    { 18, 2, 201.12, "This is the Description for product-18", "Product-18" },
                    { 19, 2, 468.68000000000001, "This is the Description for product-19", "Product-19" },
                    { 20, 2, 271.48000000000002, "This is the Description for product-20", "Product-20" },
                    { 21, 2, 123.83, "This is the Description for product-21", "Product-21" },
                    { 25, 2, 219.81, "This is the Description for product-25", "Product-25" },
                    { 43, 3, 349.72000000000003, "This is the Description for product-43", "Product-43" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Path", "ProductId" },
                values: new object[,]
                {
                    { 4, "Image.png", 2 },
                    { 8, "Image.png", 5 },
                    { 9, "Image.png", 5 },
                    { 10, "Image.png", 5 },
                    { 36, "Image.png", 20 },
                    { 35, "Image.png", 20 },
                    { 34, "Image.png", 19 },
                    { 17, "Image.png", 9 },
                    { 33, "Image.png", 18 },
                    { 18, "Image.png", 9 },
                    { 32, "Image.png", 17 },
                    { 31, "Image.png", 17 },
                    { 26, "Image.png", 15 },
                    { 27, "Image.png", 15 },
                    { 25, "Image.png", 14 },
                    { 75, "Image.png", 44 },
                    { 23, "Image.png", 14 },
                    { 28, "Image.png", 16 },
                    { 29, "Image.png", 16 },
                    { 30, "Image.png", 16 },
                    { 22, "Image.png", 13 },
                    { 21, "Image.png", 13 },
                    { 37, "Image.png", 21 },
                    { 44, "Image.png", 24 },
                    { 3, "Image.png", 1 },
                    { 45, "Image.png", 25 },
                    { 77, "Image.png", 44 },
                    { 72, "Image.png", 42 },
                    { 71, "Image.png", 40 },
                    { 78, "Image.png", 45 },
                    { 79, "Image.png", 45 },
                    { 67, "Image.png", 36 },
                    { 80, "Image.png", 46 },
                    { 81, "Image.png", 46 },
                    { 66, "Image.png", 35 },
                    { 65, "Image.png", 35 },
                    { 19, "Image.png", 10 },
                    { 64, "Image.png", 35 },
                    { 83, "Image.png", 48 },
                    { 63, "Image.png", 34 },
                    { 62, "Image.png", 34 },
                    { 61, "Image.png", 34 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Path", "ProductId" },
                values: new object[,]
                {
                    { 84, "Image.png", 48 },
                    { 54, "Image.png", 30 },
                    { 1, "Image.png", 1 },
                    { 2, "Image.png", 1 },
                    { 47, "Image.png", 25 },
                    { 46, "Image.png", 25 },
                    { 82, "Image.png", 48 },
                    { 42, "Image.png", 23 },
                    { 24, "Image.png", 14 },
                    { 76, "Image.png", 44 },
                    { 5, "Image.png", 3 },
                    { 70, "Image.png", 38 },
                    { 69, "Image.png", 38 },
                    { 38, "Image.png", 22 },
                    { 55, "Image.png", 31 },
                    { 56, "Image.png", 31 },
                    { 86, "Image.png", 49 },
                    { 85, "Image.png", 49 },
                    { 57, "Image.png", 31 },
                    { 39, "Image.png", 22 },
                    { 58, "Image.png", 31 },
                    { 43, "Image.png", 23 },
                    { 40, "Image.png", 22 },
                    { 41, "Image.png", 22 },
                    { 68, "Image.png", 38 },
                    { 49, "Image.png", 26 },
                    { 48, "Image.png", 26 },
                    { 59, "Image.png", 33 },
                    { 6, "Image.png", 3 },
                    { 60, "Image.png", 33 },
                    { 13, "Image.png", 8 },
                    { 15, "Image.png", 8 },
                    { 14, "Image.png", 8 },
                    { 73, "Image.png", 43 },
                    { 50, "Image.png", 27 },
                    { 74, "Image.png", 43 },
                    { 51, "Image.png", 29 },
                    { 7, "Image.png", 4 },
                    { 12, "Image.png", 7 },
                    { 11, "Image.png", 7 },
                    { 52, "Image.png", 29 },
                    { 53, "Image.png", 29 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Path", "ProductId" },
                values: new object[,]
                {
                    { 20, "Image.png", 11 },
                    { 16, "Image.png", 8 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "NumStars", "ProductId", "ReviewComment" },
                values: new object[,]
                {
                    { 76, 1, 44, "Never Seed a better product" },
                    { 75, 1, 44, "Never Seed a better product" },
                    { 59, 4, 33, "Never Seed a better product" },
                    { 60, 2, 33, "Never Seed a better product" },
                    { 79, 1, 45, "Never Seed a better product" },
                    { 80, 4, 46, "Never Seed a better product" },
                    { 78, 2, 45, "Never Seed a better product" },
                    { 77, 3, 44, "Never Seed a better product" },
                    { 70, 2, 38, "Never Seed a better product" },
                    { 69, 2, 38, "Never Seed a better product" },
                    { 81, 4, 46, "Never Seed a better product" },
                    { 68, 4, 38, "Never Seed a better product" },
                    { 1, 2, 1, "Never Seed a better product" },
                    { 83, 3, 48, "Never Seed a better product" },
                    { 42, 1, 23, "Never Seed a better product" },
                    { 29, 1, 16, "Never Seed a better product" },
                    { 28, 2, 16, "Never Seed a better product" },
                    { 43, 2, 23, "Never Seed a better product" },
                    { 50, 2, 27, "Never Seed a better product" },
                    { 27, 4, 15, "Never Seed a better product" },
                    { 26, 1, 15, "Never Seed a better product" },
                    { 18, 1, 9, "Never Seed a better product" },
                    { 17, 0, 9, "Never Seed a better product" },
                    { 51, 1, 29, "Never Seed a better product" },
                    { 82, 0, 48, "Never Seed a better product" },
                    { 52, 4, 29, "Never Seed a better product" },
                    { 9, 0, 5, "Never Seed a better product" },
                    { 8, 3, 5, "Never Seed a better product" },
                    { 53, 2, 29, "Never Seed a better product" },
                    { 3, 4, 1, "Never Seed a better product" },
                    { 2, 0, 1, "Never Seed a better product" },
                    { 55, 2, 31, "Never Seed a better product" },
                    { 56, 3, 31, "Never Seed a better product" },
                    { 57, 0, 31, "Never Seed a better product" },
                    { 58, 2, 31, "Never Seed a better product" },
                    { 84, 4, 48, "Never Seed a better product" },
                    { 10, 1, 5, "Never Seed a better product" },
                    { 30, 2, 16, "Never Seed a better product" },
                    { 64, 3, 35, "Never Seed a better product" },
                    { 21, 4, 13, "Never Seed a better product" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "NumStars", "ProductId", "ReviewComment" },
                values: new object[,]
                {
                    { 32, 1, 17, "Never Seed a better product" },
                    { 31, 4, 17, "Never Seed a better product" },
                    { 25, 1, 14, "Never Seed a better product" },
                    { 24, 2, 14, "Never Seed a better product" },
                    { 23, 4, 14, "Never Seed a better product" },
                    { 22, 0, 13, "Never Seed a better product" },
                    { 72, 4, 42, "Never Seed a better product" },
                    { 19, 1, 10, "Never Seed a better product" },
                    { 16, 0, 8, "Never Seed a better product" },
                    { 15, 1, 8, "Never Seed a better product" },
                    { 14, 4, 8, "Never Seed a better product" },
                    { 13, 4, 8, "Never Seed a better product" },
                    { 12, 4, 7, "Never Seed a better product" },
                    { 11, 1, 7, "Never Seed a better product" },
                    { 6, 0, 3, "Never Seed a better product" },
                    { 5, 4, 3, "Never Seed a better product" },
                    { 86, 3, 49, "Never Seed a better product" },
                    { 85, 1, 49, "Never Seed a better product" },
                    { 49, 4, 26, "Never Seed a better product" },
                    { 48, 3, 26, "Never Seed a better product" },
                    { 41, 0, 22, "Never Seed a better product" },
                    { 40, 2, 22, "Never Seed a better product" },
                    { 39, 2, 22, "Never Seed a better product" },
                    { 38, 0, 22, "Never Seed a better product" },
                    { 20, 4, 11, "Never Seed a better product" },
                    { 7, 3, 4, "Never Seed a better product" },
                    { 4, 4, 2, "Never Seed a better product" },
                    { 33, 0, 18, "Never Seed a better product" },
                    { 34, 0, 19, "Never Seed a better product" },
                    { 74, 2, 43, "Never Seed a better product" },
                    { 44, 1, 24, "Never Seed a better product" },
                    { 47, 2, 25, "Never Seed a better product" },
                    { 63, 0, 34, "Never Seed a better product" },
                    { 65, 2, 35, "Never Seed a better product" },
                    { 46, 1, 25, "Never Seed a better product" },
                    { 45, 3, 25, "Never Seed a better product" },
                    { 67, 0, 36, "Never Seed a better product" },
                    { 73, 3, 43, "Never Seed a better product" },
                    { 61, 1, 34, "Never Seed a better product" },
                    { 66, 3, 35, "Never Seed a better product" },
                    { 54, 1, 30, "Never Seed a better product" },
                    { 71, 3, 40, "Never Seed a better product" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "NumStars", "ProductId", "ReviewComment" },
                values: new object[,]
                {
                    { 37, 1, 21, "Never Seed a better product" },
                    { 35, 0, 20, "Never Seed a better product" },
                    { 62, 4, 34, "Never Seed a better product" },
                    { 36, 0, 20, "Never Seed a better product" }
                });

            migrationBuilder.InsertData(
                table: "productCatagories",
                columns: new[] { "CatagoryID", "ProductID" },
                values: new object[,]
                {
                    { 6, 31 },
                    { 7, 39 },
                    { 9, 41 },
                    { 3, 49 },
                    { 3, 26 },
                    { 12, 37 },
                    { 9, 20 },
                    { 1, 33 },
                    { 2, 45 },
                    { 13, 36 },
                    { 2, 22 },
                    { 13, 12 },
                    { 1, 40 },
                    { 4, 38 },
                    { 4, 11 },
                    { 3, 4 },
                    { 11, 42 },
                    { 1, 2 },
                    { 10, 43 },
                    { 8, 32 },
                    { 9, 35 },
                    { 1, 6 },
                    { 5, 3 },
                    { 4, 5 },
                    { 6, 19 },
                    { 1, 21 },
                    { 6, 18 },
                    { 12, 9 },
                    { 1, 24 },
                    { 13, 17 },
                    { 6, 1 },
                    { 6, 15 },
                    { 7, 25 },
                    { 6, 14 },
                    { 7, 46 },
                    { 4, 13 },
                    { 8, 10 },
                    { 7, 30 }
                });

            migrationBuilder.InsertData(
                table: "productCatagories",
                columns: new[] { "CatagoryID", "ProductID" },
                values: new object[,]
                {
                    { 1, 48 },
                    { 11, 23 },
                    { 2, 34 },
                    { 2, 8 },
                    { 3, 27 },
                    { 3, 47 },
                    { 4, 28 },
                    { 3, 7 },
                    { 8, 29 },
                    { 3, 16 },
                    { 3, 44 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_InfoID",
                table: "Manufacturers",
                column: "InfoID",
                unique: true,
                filter: "[InfoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductsDetails_OrderID",
                table: "OrderProductsDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_productCatagories_CatagoryID",
                table: "productCatagories",
                column: "CatagoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerID",
                table: "Products",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderProductsDetails");

            migrationBuilder.DropTable(
                name: "productCatagories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Infomation");
        }
    }
}
