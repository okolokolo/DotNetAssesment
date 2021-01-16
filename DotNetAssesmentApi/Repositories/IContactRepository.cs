using DotNetAssesmentDataContext.Models;
using System.Collections.Generic;

namespace DotNetAssesmentApi.Repositories
{
    //Normally I would inherit this from a base abstract repository interface
    public interface IContactRepository
    {
        void Create(Contact contact);
        void Delete(int id);
        IEnumerable<Contact> Get();
        Contact Get(int id);
        void Update(Contact contact);
    }
}