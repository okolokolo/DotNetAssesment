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
                    entity => entity.PhoneType.Name))
                .ForMember(viewModel => viewModel.Number, opt => opt.MapFrom(
                    entity => String.Format("{0:###-###-####}", entity.Number)));

            CreateMap<PhoneViewModel, Phone>()
                .ForMember(entity => entity.PhoneTypeId, opt => opt.MapFrom(
                    viewModel => (int)Enum.Parse(typeof(PhoneTypeEnum), viewModel.Type)))
                .ForMember(entity => entity.Number, opt => opt.MapFrom(
                    viewModel => uint.Parse(viewModel.Number.Replace("-",""))));
        }
    }
}
