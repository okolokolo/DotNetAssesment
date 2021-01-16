using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DotNetAssesmentDataContext
{
    public class ContactDbContext : DbContext
    {
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ContactDbContext() : base()
        {

        }

        private string _connectionString { get; set; } = @"Data Source=ContactDB.db;";
        public ContactDbContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public void SeedData()
        {
            if (this.Phones.Count() > 0)
                this.Phones.RemoveRange(this.Phones);

            if (this.PhoneTypes.Count() > 0)
                this.PhoneTypes.RemoveRange(this.PhoneTypes);

            if (this.Contacts.Count() > 0)
                this.Contacts.RemoveRange(this.Contacts);

            Console.WriteLine("Inserting PhoneTypes...");
            this.PhoneTypes.AddRange(new List<PhoneType>() {
                    new PhoneType {
                        Id = (int)PhoneTypeEnum.home,
                        Name = "home"
                    },
                    new PhoneType
                    {
                        Id = (int)PhoneTypeEnum.work,
                        Name = "work"
                    },
                    new PhoneType
                    {
                        Id = (int)PhoneTypeEnum.mobile,
                        Name = "mobile"
                    }
                });
            this.SaveChanges();

            Console.WriteLine("Inserting initial contact...");
            this.Contacts.Add(new Contact()
            {
                Id = 1,
                Email = "harold.gilkey@yahoo.com",
                FirstName = "Harold",
                MiddleName = "Francis",
                LastName = "Gilkey",
                Street = "8360 High Autumn Row",
                City = "Cannon",
                State = "Delaware",
                Zip = 19797,
                Phones = new List<Phone>()
                    {
                        new Phone() {
                            Number = 3026119148,
                            PhoneTypeId = (int)PhoneTypeEnum.home
                        },
                        new Phone()
                        {
                            Number = 3025329427,
                            PhoneTypeId = (int)PhoneTypeEnum.mobile
                        }
                    }
            });
            this.SaveChanges();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                           
           optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneType>(x => x.ToTable("PhoneTypes"));
            modelBuilder.Entity<Phone>(x => x.ToTable("Phones"));
            modelBuilder.Entity<Contact>(x => {
                x.ToTable("Contacts");
                x.HasIndex(u => u.Email)
                 .IsUnique();
            });
        }

    }
}
