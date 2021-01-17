using AutoMapper;
using DotNetAssesmentApi.ViewModels;
using DotNetAssesmentDataContext;
using DotNetAssesmentDataContext.Models;
using System;

namespace DotNetAssesmentApi.AutoMapperProfiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<Phone, PhoneViewModel>()
                .ForMember(viewModel => viewModel.Type, opt => opt.MapFrom(
                    entity => (PhoneTypeEnum)entity.PhoneTypeId))
                .ForMember(viewModel => viewModel.Number, opt => opt.MapFrom(
                    entity => string.Format("{0:###-###-####}", entity.Number)));

            CreateMap<PhoneViewModel, Phone>()
                .ForMember(entity => entity.PhoneTypeId, opt => opt.MapFrom(
                    viewModel => (int)viewModel.Type))
                .ForMember(entity => entity.Number, opt => opt.MapFrom(
                    viewModel => uint.Parse(viewModel.Number.Replace("-",""))));
        }
    }
}
