using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                           
           optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneType>(x => x.ToTable("PhoneTypes"));
            modelBuilder.Entity<Phone>(x => x.ToTable("Phones"));
            modelBuilder.Entity<Contact>(x => x.ToTable("Contacts"));
        }

    }
}
