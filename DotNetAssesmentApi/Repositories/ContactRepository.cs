using DotNetAssesmentDataContext;
using DotNetAssesmentDataContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAssesmentApi.Repositories
{
    //Normally I would inherit this from a base abstract repository class
    public class ContactRepository : IContactRepository
    {
        readonly ContactDbContext _contactDbContext;

        public ContactRepository(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactDbContext.Contacts
                .Include(nameof(Phone))
                .Include(nameof(PhoneType))
                .AsEnumerable();
        }

        public Contact Create(Contact contact)
        {
            _contactDbContext.Contacts.Add(contact);
            _contactDbContext.SaveChanges();
            return contact;
        }

        public Contact Update(Contact contact)
        {
            _contactDbContext.Contacts.Update(contact);
            _contactDbContext.SaveChanges();
            return contact;
        }

        public Contact Get(int id)
        {
            return Get().Single(c => c.Id == id);
        }

        public void Delete(int id)
        {
            Contact contact = _contactDbContext.Contacts.Single(x => x.Id == id);
            _contactDbContext.Contacts.Remove(contact);
        }
    }
}
