using Ass1Server.Models.OrderDetail;
using AutoMapper;
using BusinessObject.Models;

namespace Ass1Server.Configurations
{
    public class OrderDetailMapper : Profile
    {
        public OrderDetailMapper() 
        {
            CreateMap<OrderDetailCreateDTO, OrderDetail>();
        }
    }
}
