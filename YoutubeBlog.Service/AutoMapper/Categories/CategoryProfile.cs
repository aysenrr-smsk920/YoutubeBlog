using AutoMapper;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CategoryAddDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();

        }
    
    }
}
