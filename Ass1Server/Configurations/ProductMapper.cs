using Ass1Server.Models.Product;
using AutoMapper;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ass1Server.Configurations
{
    public class ProductMapper : Profile
    {
        public ProductMapper() 
        {
            CreateMap<Product, ProductInfoDTO>()
                .ForMember(des => des.CategoryName, act => act.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductModifyDTO, Product>();
        }
    }
}
