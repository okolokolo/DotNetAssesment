using DotNetAssesmentDataContext.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DotNetAssesmentDataContext
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Getting connection string...");

            IConfiguration configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true)
                            .AddCommandLine(args)
                            .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine("Seeding ContactDB.db...");

            using (var db = new ContactDbContext(connectionString))
            {
                Console.WriteLine("Inserting PhoneTypes...");
                db.PhoneTypes.AddRange(new List<PhoneType>() {
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
                db.SaveChanges();

                Console.WriteLine("Inserting initial contact...");
                db.Contacts.Add(new Contact()
                {
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
                db.SaveChanges();
            }
        }
    }
}
