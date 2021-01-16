using AutoMapper;
using DotNetAssesmentApi.AutoMapperProfiles;
using DotNetAssesmentApi.Repositories;
using DotNetAssesmentApi.Services;
using DotNetAssesmentDataContext;
using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Xunit.Sdk;

namespace DotNetAssesmentTest
{
    [TestClass]
    public class ContactTests
    {
        private IContactRepository _repository;
        private ContactDbContext _context;

        [TestInitialize]
        public void SetUp()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true)
                           .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = new ContactDbContext(connectionString);
            _repository = new ContactRepository(_context);
        }

        //This is just an example of a test that I would write for this
        [TestMethod("Should ensure email addresses of contacts are unique")]
        [ExpectedException(typeof(DbUpdateException))]
        public void TestContactsWithDuplicateEmail()
        {
            _repository.Create(new Contact()
            {
                FirstName = "Harold",
                LastName = "Duplicate",
                Email = "harold.gilkey@yahoo.com"
            });
        }


    }
}
