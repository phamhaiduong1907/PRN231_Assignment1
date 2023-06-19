using Ass1Server.Models.Category;
using AutoMapper;
using BusinessObject.Models;

namespace Ass1Server.Configurations
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() 
        { 
            CreateMap<Category, CategoryInfoDTO>().ReverseMap();
        }
    }
}
