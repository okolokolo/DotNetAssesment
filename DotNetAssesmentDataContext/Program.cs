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
                db.SeedData();
            }
        }
    }
}
