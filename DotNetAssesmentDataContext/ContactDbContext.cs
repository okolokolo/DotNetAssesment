using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAssesmentDataContext
{
    public class ContactDbContext : DbContext
    {
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ContactDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneType>().ToTable("PhoneTypes");
            modelBuilder.Entity<Phone>().ToTable("Phones");
            modelBuilder.Entity<Contact>().ToTable("Contacts");
        }

    }
}
