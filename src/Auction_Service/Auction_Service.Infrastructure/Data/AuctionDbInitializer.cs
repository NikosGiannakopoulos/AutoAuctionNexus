using Microsoft.EntityFrameworkCore;
using Auction_Service.Domain.Entities;
using Auction_Service.Domain.Entities.Enums;

namespace Auction_Service.Infrastructure.Data
{
    public class AuctionDbInitializer
    {
        public static void InitDb(AuctionDbContext auctionDbContext)
        {
            try
            {
                auctionDbContext.Database.Migrate();

                if (!auctionDbContext.Auctions.Any())
                {
                    SeedData(auctionDbContext);
                }
                else
                {
                    Console.WriteLine("Data already exists - No need to seed.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while seeding the database: {ex.Message}");
            }
        }

        private static void SeedData(AuctionDbContext auctionDbContext)
        {
            var auctions = new List<Auction>()
            {
                new() {
                    Id = Guid.Parse("bf453e92-57c9-4feb-b19d-7e31e57208f0"),
                    ReservePrice = 20000,
                    StartingBidPrice = null,
                    BuyItNowPrice = 25000,
                    Seller = "Bob",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-8),
                    AuctionStart = DateTime.UtcNow.AddDays(-1),
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Ford",
                        Model = "GT",
                        Year = 2020,
                        HP = 700,
                        CC = 5000,
                        Color = "White",
                        Mileage = 50000,
                        VIN = "12345678901234567",
                        Description = "Powerful sports car",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("23bd2f2c-c236-47e2-a942-2ccaa3d2a70b"),
                    ReservePrice = 90000,
                    StartingBidPrice = 75000,
                    BuyItNowPrice = null,
                    Seller = "Alice",
                    Winner = "John",
                    SoldAmount = 95000,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-35),
                    AuctionStart = DateTime.UtcNow.AddDays(-15),
                    AuctionEnd = DateTime.UtcNow.AddDays(-5),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Bugatti",
                        Model = "Veyron",
                        Year = 2018,
                        HP = 1200,
                        CC = 8000,
                        Color = "Black",
                        Mileage = 15035,
                        VIN = "98765432109876543",
                        Description = "Iconic supercar",
                        Condition = Condition.Damaged,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("a6d264f3-7a11-4bfa-afb3-d9edca9b790d"),
                    ReservePrice = 90000,
                    StartingBidPrice = null,
                    BuyItNowPrice = 100000,
                    Seller = "Bob",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                    AuctionStart = DateTime.UtcNow.AddDays(5),
                    AuctionEnd = DateTime.UtcNow.AddDays(15),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Ford",
                        Model = "Mustang",
                        Year = 2023,
                        HP = 450,
                        CC = 5000,
                        Color = "Black",
                        Mileage = 65125,
                        VIN = "ABCD1234EFGH5678",
                        Description = "Classic American muscle car",
                        Condition = Condition.New,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("21c541e0-2cc6-44fe-96a9-4056fe882d4e"),
                    ReservePrice = 50000,
                    StartingBidPrice = 30000,
                    BuyItNowPrice = 65000,
                    Seller = "Tom",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-25),
                    UpdatedAt = DateTime.UtcNow.AddDays(-30),
                    AuctionStart = DateTime.UtcNow.AddDays(-10),
                    AuctionEnd = DateTime.UtcNow.AddDays(-5),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Mercedes",
                        Model = "SLK",
                        Year = 2020,
                        HP = 300,
                        CC = 2000,
                        Color = "Silver",
                        Mileage = 15001,
                        VIN = "MNOP1234IJKL5678",
                        Description = "Luxury convertible",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png"]
                    }
                },
                new() {
                    Id = Guid.Parse("2f6f738e-e281-4289-89c2-09d025b68898"),
                    ReservePrice = 20000,
                    StartingBidPrice = 11000,
                    BuyItNowPrice = 28000,
                    Seller = "Alice",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    UpdatedAt = DateTime.UtcNow.AddDays(-25),
                    AuctionStart = DateTime.UtcNow.AddDays(-5),
                    AuctionEnd = DateTime.UtcNow.AddDays(25),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "BMW",
                        Model = "X1",
                        Year = 2017,
                        HP = 200,
                        CC = 1500,
                        Color = "White",
                        Mileage = 90000,
                        VIN = "UVWX1234QRST5678",
                        Description = "Compact SUV",
                        Condition = Condition.Damaged,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("2033cecf-a747-4162-8cb7-6a5e2d20b636"),
                    ReservePrice = 200000,
                    StartingBidPrice = 120000,
                    BuyItNowPrice = 220000,
                    Seller = "Bob",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-20),
                    AuctionStart = DateTime.UtcNow.AddDays(2),
                    AuctionEnd = DateTime.UtcNow.AddDays(14),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Ferrari",
                        Model = "Spider",
                        Year = 2015,
                        HP = 600,
                        CC = 4000,
                        Color = "Red",
                        Mileage = 50000,
                        VIN = "IJKL5678EFGH1234",
                        Description = "Exotic convertible",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("2481475a-6431-4acd-8323-caa26be53d23"),
                    ReservePrice = 150000,
                    StartingBidPrice = null,
                    BuyItNowPrice = null,
                    Seller = "Alice",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-40),
                    UpdatedAt = DateTime.UtcNow.AddDays(-45),
                    AuctionStart = DateTime.UtcNow.AddDays(-1),
                    AuctionEnd = DateTime.UtcNow.AddDays(13),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Ferrari",
                        Model = "F-430",
                        Year = 2022,
                        HP = 800,
                        CC = 5000,
                        Color = "Red",
                        Mileage = 5000,
                        VIN = "MNOP1234IJKL5678",
                        Description = "High-performance sports car",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("79440561-2890-43e9-9150-f0377707b4c0"),
                    ReservePrice = 180000,
                    StartingBidPrice = 100000,
                    BuyItNowPrice = 200000,
                    Seller = "Bob",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-45),
                    UpdatedAt = DateTime.UtcNow.AddDays(-50),
                    AuctionStart = DateTime.UtcNow.AddDays(-1),
                    AuctionEnd = DateTime.UtcNow.AddDays(19),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Audi",
                        Model = "R8",
                        Year = 2021,
                        HP = 550,
                        CC = 4000,
                        Color = "White",
                        Mileage = 10050,
                        VIN = "QRST5678MNOP1234",
                        Description = "Luxury sports car",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("379d8706-1537-4498-b539-33f60256fe81"),
                    ReservePrice = 32000,
                    StartingBidPrice = null,
                    BuyItNowPrice = null,
                    Seller = "Tom",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-50),
                    UpdatedAt = DateTime.UtcNow.AddDays(-55),
                    AuctionStart = DateTime.UtcNow.AddDays(-10),
                    AuctionEnd = DateTime.UtcNow.AddDays(-1),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Audi",
                        Model = "TT",
                        Year = 2020,
                        HP = 300,
                        CC = 2000,
                        Color = "Black",
                        Mileage = 25400,
                        VIN = "UVWX1234QRST5678",
                        Description = "Compact sports car",
                        Condition = Condition.Used,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg"]
                    }
                },
                new() {
                    Id = Guid.Parse("30447612-3b2f-4da9-944c-3de2cefdcac6"),
                    ReservePrice = 20000,
                    StartingBidPrice = null,
                    BuyItNowPrice = 30000,
                    Seller = "Bob",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    UpdatedAt = DateTime.UtcNow.AddDays(-65),
                    AuctionStart = DateTime.UtcNow.AddDays(-5),
                    AuctionEnd = DateTime.UtcNow.AddDays(48),
                    Vehicle = new Vehicle()
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Ford",
                        Model = "Model T",
                        Year = 1938,
                        HP = 40,
                        CC = 2200,
                        Color = "Rust",
                        Mileage = 150150,
                        VIN = "EFGH1234IJKL5678",
                        Description = "Vintage automobile",
                        Condition = Condition.Damaged,
                        Category = Category.Car,
                        ImageUrls = ["https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg"]
                    }
                }
            };

            auctionDbContext.AddRange(auctions);
            auctionDbContext.SaveChanges();
        }
    }
}