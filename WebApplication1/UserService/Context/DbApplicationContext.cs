﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Models;

namespace UserService.Context
{
    public class DbApplicationContext : DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);
            base.OnModelCreating(builder);
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            // Required properties
            modelBuilder.Entity<Address>()
                .Property(b => b.StreetName)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(b => b.HouseNumber)
                .IsRequired();

            modelBuilder.Entity<CityInfo>()
                .Property(b => b.ZipCode)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(_ => _.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(_ => _.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(_ => _.Password)
                .IsRequired();

            // Enum configuration for roles
            modelBuilder.Entity<Role>()
                .Property(_ => _.RoleType)
                .HasConversion(new EnumToStringConverter<Common.Enums.Enum.RoleTypes>());

            // Dummy data
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = 1, RoleType = Common.Enums.Enum.RoleTypes.Customer },
                    new Role { Id = 2, RoleType = Common.Enums.Enum.RoleTypes.DeliveryPerson },
                    new Role { Id = 3, RoleType = Common.Enums.Enum.RoleTypes.RestaurantOwner });

            modelBuilder.Entity<CityInfo>()
                .HasData(
                    new CityInfo { Id = 1, ZipCode = "3400", City = "Hillerød" },
                    new CityInfo { Id = 2, ZipCode = "3480", City = "Fredensborg" },
                    new CityInfo { Id = 3, ZipCode = "2630", City = "Taastrup" },
                    new CityInfo { Id = 4, ZipCode = "2640", City = "Hedehusene" },
                    new CityInfo { Id = 5, ZipCode = "2920", City = "Charlottenlund" },
                    new CityInfo { Id = 6, ZipCode = "3000", City = "" });

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address { Id = 1, StreetName = "Skovledet", HouseNumber = "94A", Floor = 3, DoorDesignation = "tv", CityInfoId = 1 },
                    new Address { Id = 2, StreetName = "Cphbusinessvej", HouseNumber = "23", Floor = 2, CityInfoId = 5 });

            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = 1, FirstName = "Phillip", Email = "phillip.andersen1999@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("P@ris2027!"), AddressId = 1, RoleId = 1 },
                    new User { Id = 2, FirstName = "Lukas", Email = "lukasbangstoltz@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("P@ris2027!"), AddressId = 2, RoleId = 3 },
                    new User { Id = 3, FirstName = "Christoffer", Email = "christofferiw@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("P@ris2027!"), AddressId = 2, RoleId = 2 });

        }
    }
}
