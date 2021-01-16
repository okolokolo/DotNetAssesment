using DotNetAssesmentApi.ViewModels;
using System.Collections.Generic;

namespace DotNetAssesmentApi.Services
{
    public interface IContactService
    {
        ContactViewModel Create(ContactViewModel viewModel);
        void Delete(int id);
        IEnumerable<ContactViewModel> Get();
        ContactViewModel Get(int id);
        IEnumerable<CallListViewModel> GetCallList();
        ContactViewModel Update(ContactViewModel viewModel);
    }
}