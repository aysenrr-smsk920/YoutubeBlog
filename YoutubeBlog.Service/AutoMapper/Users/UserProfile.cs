using AutoMapper;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, UserAddDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, UserProfileDTO>().ReverseMap();
        }
        
    }
}
