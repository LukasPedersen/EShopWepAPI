using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer
{
    public class EShopContext : DbContext
    {
        Random random = new Random();
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Info> Infomation { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<ProductCatagory> productCatagories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderProductsDetails> OrderProductsDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDB; Trusted_Connection = True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Joined Primary Key
            modelBuilder.Entity<ProductCatagory>().HasKey(PC => new { PC.ProductID, PC.CatagoryID });

            //Seeding Admin
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                AdminId = 1,
                Username = "HR",
                Password = "123"
            });

            //Seeding Catagory
            string[] cat = new string[]
            {
                "Chair",
                "Tabls",
                "Combo",
                "Sofa",
                "Light",
                "Outdoor",
                "Sommer",
                "Winter",
                "Breach",
                "Shelf",
                "Kitchen",
                "LivingRoom",
                "Bedroom",
                "Bed"
            };
            int num = 1;
            foreach (var item in cat)
            {
                modelBuilder.Entity<Catagory>().HasData(new Catagory
                {
                    CatagoryID = num,
                    CatagoryName = item
                });
                num++;
            }

            //Seeding ProductCatagory
            for (int PC = 1; PC < 50; PC++)
            {
                modelBuilder.Entity<ProductCatagory>().HasData(new ProductCatagory
                {
                    ProductID = PC,
                    CatagoryID = random.Next(1, 14)
                });
            }

            //Seeding Manufacturer
            for (int i = 1; i < 4; i++)
            {
                string City = cat[random.Next(0, cat.Length)];
                //Seeding Info
                modelBuilder.Entity<Info>().HasData(new Info
                {
                    InfoID = i,
                    City = $"{City}.City",
                    Postal = random.Next(1000, 9999),
                    Street = $"{City} Street",
                    StreetNumber = i,
                    Country = $"Somewhere {City}",
                });
                modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                {
                    ManufacturerID = i,
                    ManufacturerName = $"Manufacturer-{i}",
                    Email = $"Manufacturer-{i}@Email.{City}",
                    PhoneNumbér = random.Next(10000000, 99999999),
                    InfoID = i
                });
            }
            int ReviewID = 1;
            int ImageID = 1;
            //Seeding Product
            for (int p = 1; p < 50; p++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductID = p,
                    ProductName = $"Product-{p}",
                    ProductDescription = $"This is the Description for product-{p}",
                    Price = Math.Round(Math.Clamp(random.Next(0, 500) + random.NextDouble(), 0.00, 500.00), 2),
                    ManufacturerID = random.Next(1, 4)
                });
                for (int pr = 1; pr - 1 < random.Next(0, 5); pr++)
                {
                    modelBuilder.Entity<Review>().HasData(new Review
                    {
                        ReviewID = ReviewID,
                        NumStars = random.Next(0, 5),
                        ReviewComment = $"Never Seed a better product",
                        ProductId = p
                    });
                    modelBuilder.Entity<Image>().HasData(new Image
                    {
                        ImageID = ImageID,
                        ProductId = p,
                        Path = "Image.png"
                    });
                    ImageID++;
                    ReviewID++;
                }
            }

            //Seeding Order
            for (int o = 1; o < 10; o++)
            {
                modelBuilder.Entity<Order>().HasData(new Order
                {
                    OrderID = o,
                    Email = "ThisIsThe@Best.Email",
                    BuyDate = DateTime.Now
                });
            }
            //Seeding OrderPRoductsDetalis
            for (int OP = 1; OP < 50; OP++)
            {
                modelBuilder.Entity<OrderProductsDetails>().HasData(new OrderProductsDetails
                {
                    OrderProductsDetailsId = OP,
                    Navn = cat[random.Next(0, 14)],
                    ProductID = random.Next(1, 50),
                    Pris = random.Next(15, 500),
                    OrderID = random.Next(1, 10)
                });
            }
        }
    }
}