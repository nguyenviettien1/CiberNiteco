using System;
using CiberNiteco.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CiberNiteco.Entities.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Đồ uống",
                    Description = "Danh mục các đồ uống"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Đồ ăn",
                    Description = "Danh mục các thực phẩm"
                });
            
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Bia Trúc Bạch",
                    Description = "Sản phẩm của Habeco",
                    CategoryId = 1,
                    Price = 15000,
                    Quantity = 1600
                },
                new Product()
                {
                    Id = 2,
                    Name = "Bia BOLD",
                    Description = "Sản phẩm của Habeco",
                    CategoryId = 1,
                    Price = 12000,
                    Quantity = 1800
                },new Product()
                {
                    Id = 3,
                    Name = "Chân gà vị cay - 30g",
                    Description = "Sản phẩm của MenVodka",
                    CategoryId = 2,
                    Price = 9000,
                    Quantity = 5000
                },
                new Product()
                {
                    Id = 4,
                    Name = "Chân gà vị mật ong - 30g",
                    Description = "Sản phẩm của MenVodka",
                    CategoryId = 2,
                    Price = 10000,
                    Quantity = 4000
                },
                new Product()
                {
                    Id = 5,
                    Name = "Sữa TH",
                    Description = "Sản phẩm của TH True Milk",
                    CategoryId = 1,
                    Price = 8000,
                    Quantity = 5700
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    Name = "Tạp hóa Minh Anh",
                    Address = "Hà Nội"
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Siêu thị Kim Ngân",
                    Address = "Bắc Ninh"
                },
                new Customer()
                {
                    Id = 3,
                    Name = "Nhà hàng Hùng Cường",
                    Address = "Bắc Giang"
                },
                new Customer()
                {
                    Id = 4,
                    Name = "Nhà hàng Thu Cúc",
                    Address = "Vĩnh Phúc"
                });
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 2,
                    Amount = 20,
                    OrderDate = DateTime.Today.AddDays(-4)
                },
                new Order()
                {
                    Id = 2,
                    CustomerId = 3,
                    ProductId = 1,
                    Amount = 170,
                    OrderDate = DateTime.Today.AddDays(-3)
                });
            
            // any guid
            var roleId = new Guid("175EE44A-CC60-45D4-8EBB-8F3B072D38F8");
            var adminId = new Guid("3728FD0A-EDA0-4BF8-9048-0B7839F0404D");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "viettien98htttbn@gmail.com",
                NormalizedEmail = "viettien98htttbn@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "12345aA@"),
                SecurityStamp = string.Empty,
                FirstName = "Tien",
                LastName = "Nguyen",
                DateOfBirth = new DateTime(1998, 07, 02)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}