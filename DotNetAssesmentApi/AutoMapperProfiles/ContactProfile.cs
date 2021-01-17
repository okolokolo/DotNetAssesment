using AutoMapper;
using DotNetAssesmentApi.ViewModels;
using DotNetAssesmentDataContext;
using DotNetAssesmentDataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAssesmentApi.AutoMapperProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {

            #region Contact to CallListViewModel
            CreateMap<Contact, CallListViewModel>()
              .ForMember(viewModel => viewModel.Phone,
                   opt => opt.MapFrom(entity => GetHomePhoneNumber(entity.Phones)))
              .ForPath(viewModel => viewModel.Name.First,
                   opt => opt.MapFrom(entity => entity.FirstName))
              .ForPath(viewModel => viewModel.Name.Middle,
                   opt => opt.MapFrom(entity => entity.MiddleName))
              .ForPath(viewModel => viewModel.Name.Last,
                   opt => opt.MapFrom(entity => entity.LastName));
            #endregion

            #region Contact to ContactViewModel
            CreateMap<Contact, ContactViewModel>()
               .ForMember(viewModel => viewModel.Email,
                    opt => opt.MapFrom(entity => entity.Email))
               .ForPath(viewModel => viewModel.Name.First,
                    opt => opt.MapFrom(entity => entity.FirstName))
               .ForPath(viewModel => viewModel.Name.Middle,
                    opt => opt.MapFrom(entity => entity.MiddleName))
               .ForPath(viewModel => viewModel.Name.Last,
                    opt => opt.MapFrom(entity => entity.LastName))
               .ForPath(viewModel => viewModel.Address.Street,
                    opt => opt.MapFrom(entity => entity.Street))
               .ForPath(viewModel => viewModel.Address.City,
                    opt => opt.MapFrom(entity => entity.City))
               .ForPath(viewModel => viewModel.Address.State,
                    opt => opt.MapFrom(entity => entity.State))
               .ForPath(viewModel => viewModel.Address.Zip,
                    opt => opt.MapFrom(entity => string.Format("{0:#####-####}", entity.Zip.ToString())));
            #endregion

            #region ContactViewModel to Contact
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
                    opt => opt.MapFrom(viewModel => int.Parse(viewModel.Address.Zip.Replace("-",""))))
               .ForMember(entity => entity.Phones, opt => opt.Ignore());

            #endregion

        }

        private string GetHomePhoneNumber(IList<Phone> phones)
        {
            Phone phone = phones.Single(p => p.PhoneTypeId == (int)PhoneTypeEnum.home);
            return string.Format("{0:###-###-####}", phone.Number);
        }
    }
}
