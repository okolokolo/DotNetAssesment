using AutoMapper;
using DotNetAssesmentApi.AutoMapperProfiles;
using DotNetAssesmentApi.Repositories;
using DotNetAssesmentApi.Services;
using DotNetAssesmentApi.ViewModels;
using DotNetAssesmentDataContext;
using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit.Sdk;

namespace DotNetAssesmentTest
{
    [TestClass]
    public class ContactTests
    {
        private IContactRepository _repository;
        private IMapper _mapper;
        private IContactService _service;
        private ContactDbContext _context;
        private List<PhoneViewModel> _phones;

        [TestInitialize]
        public void SetUp()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true)
                           .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = new ContactDbContext(connectionString);
            _context.SeedData();

            _phones = new List<PhoneViewModel>() {
                new PhoneViewModel()
                {
                    Number = "123-789-1244",
                    Type = PhoneTypeEnum.work
                }
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContactProfile());
                cfg.AddProfile(new PhoneProfile());
            });
            _mapper = config.CreateMapper();
            
            _repository = new ContactRepository(_context);
            _service = new ContactService(_mapper, _repository);
        }

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

        [TestMethod("Should ensure the phone numbers of a contact are updated")]
        public void TestContactsPhoneNumbersAreSaved()
        {
            ContactViewModel contactViewModel = _service.Get(1);
            PhoneViewModel phone = _phones.Single();
            Assert.AreEqual(2, contactViewModel.Phones.Count(), "There are currently 2 total phone numbers");

            int numberOfWorkNumbers = contactViewModel.Phones.Where(p => p.Type == PhoneTypeEnum.work).Count();
            Assert.AreEqual(0, numberOfWorkNumbers, "There are currently 0 work phone numbers");

            contactViewModel.Phones = _phones;
            _service.Update(contactViewModel);

            ContactViewModel updatedContactViewModel = _service.Get(1);
            PhoneViewModel updatedPhone = updatedContactViewModel.Phones.Single();
            Assert.AreEqual(phone.Number, updatedPhone.Number, "The contact's phone numbers should have updated");

            Assert.AreEqual(1, updatedContactViewModel.Phones.Count(), "Now there is only 1 phone number");

            numberOfWorkNumbers = updatedContactViewModel.Phones.Where(p => p.Type == PhoneTypeEnum.work).Count();
            Assert.AreEqual(1, numberOfWorkNumbers, "That phone number is a work number");

        }
    }
}
