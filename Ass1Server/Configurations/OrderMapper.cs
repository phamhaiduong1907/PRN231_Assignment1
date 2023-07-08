using Ass1Server.Models.Order;
using AutoMapper;
using BusinessObject.Models;

namespace Ass1Server.Configurations
{
    public class OrderMapper : Profile
    {
        public OrderMapper() 
        {
            CreateMap<Order, OrderInfoDTO>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Member.Email));
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();
        }
    }
}
