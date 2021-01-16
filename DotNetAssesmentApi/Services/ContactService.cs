using AutoMapper;
using DotNetAssesmentApi.Repositories;
using DotNetAssesmentApi.ViewModels;
using DotNetAssesmentDataContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAssesmentApi.Services
{
    public class ContactService : IContactService
    {
        readonly IMapper _mapper;
        readonly IContactRepository _repository;

        public ContactService(
            IMapper mapper,
            IContactRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ContactViewModel> Get()
        {
            return _repository.Get()
                .Select(c => _mapper.Map<ContactViewModel>(c));
        }

        public ContactViewModel Create(ContactViewModel viewModel)
        {
            Contact entity = _mapper.Map<Contact>(viewModel);
            entity.Phones = viewModel.Phones
                .Select(pvm => _mapper.Map<Phone>(pvm)).ToList();
            _repository.Create(entity);
            viewModel.Id = entity.Id;
            return viewModel;
        }

        public ContactViewModel Update(ContactViewModel viewModel)
        {
            Contact entity = _repository.Get(viewModel.Id);
            _mapper.Map(viewModel, entity);
            entity.Phones = viewModel.Phones
                .Select(pvm => _mapper.Map<Phone>(pvm)).ToList();
            _repository.Update(entity);
            return viewModel;
        }

        public ContactViewModel Get(int id)
        {
            Contact entity = _repository.Get(id);
            return _mapper.Map<ContactViewModel>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<CallListViewModel> GetCallList()
        {
            return _repository.Get()
                .OrderBy(c => c.LastName)
                .OrderBy(c => c.FirstName)
                .Select(c => _mapper.Map<CallListViewModel>(c));
        }

    }
}
