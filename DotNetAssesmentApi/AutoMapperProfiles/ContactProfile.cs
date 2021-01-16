using AutoMapper;
using DotNetAssesmentApi.ViewModels;
using DotNetAssesmentDataContext.Models;

namespace DotNetAssesmentApi.AutoMapperProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>()
               .ForMember(viewModel => viewModel.Email,
                    opt => opt.MapFrom(entity => entity.Email))
               .ForMember(viewModel => viewModel.Name.First,
                    opt => opt.MapFrom(entity => entity.FirstName))
               .ForMember(viewModel => viewModel.Name.Middle,
                    opt => opt.MapFrom(entity => entity.MiddleName))
               .ForMember(viewModel => viewModel.Name.Last,
                    opt => opt.MapFrom(entity => entity.LastName))
               .ForMember(viewModel => viewModel.Address.Street,
                    opt => opt.MapFrom(entity => entity.Street))
               .ForMember(viewModel => viewModel.Address.City,
                    opt => opt.MapFrom(entity => entity.City))
               .ForMember(viewModel => viewModel.Address.State,
                    opt => opt.MapFrom(entity => entity.State))
               .ForMember(viewModel => viewModel.Address.Zip,
                    opt => opt.MapFrom(entity => entity.Zip.ToString()));

            CreateMap<ContactViewModel, Contact>()
               .ForMember(entity => entity.Email,
                    opt => opt.MapFrom(viewModel => viewModel.Email))
               .ForMember(entity => entity.FirstName,
                    opt => opt.MapFrom(viewModel => viewModel.Name.First))
               .ForMember(entity => entity.MiddleName,
                    opt => opt.MapFrom(viewModel => viewModel.Name.Middle))
               .ForMember(entity => entity.LastName,
                    opt => opt.MapFrom(viewModel => viewModel.Name.Last))
               .ForMember(entity => entity.Street,
                    opt => opt.MapFrom(viewModel => viewModel.Address.Street))
               .ForMember(entity => entity.City,
                    opt => opt.MapFrom(viewModel => viewModel.Address.City))
               .ForMember(entity => entity.State,
                    opt => opt.MapFrom(viewModel => viewModel.Address.State))
               .ForMember(entity => entity.Zip,
                    opt => opt.MapFrom(viewModel => int.Parse(viewModel.Address.Zip)))
               .ForMember(entity => entity.Phones, opt => opt.Ignore());
        }
    }
}
