using AutoMapper;
using Web_API.Models.DTOS;
using Web_API.Models;

namespace Web_API.Profiles
{
    public class OrderProfiles:Profile 
    {
        public OrderProfiles()
        {
            CreateMap<AddProductDTO, Product>().ReverseMap();
            CreateMap<AddOrdersDTO, Order>().ReverseMap();
        }
    }
}
