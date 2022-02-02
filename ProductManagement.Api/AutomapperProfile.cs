using AutoMapper;
using ProductManagement.Api.Data.Models;
using ProductManagement.Api.Model;

namespace ProductManagement.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserDetails, User>()
                .ForMember(dest=> dest.Email, opt => opt.MapFrom(src=>src.EmailAddress))
                .ReverseMap();

            CreateMap<ProductDetails, Product>().ReverseMap();
        }
    }
}