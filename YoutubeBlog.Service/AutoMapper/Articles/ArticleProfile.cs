using AutoMapper;
using YoutubeBlog.Entity.DTO.Articles;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO, Article>().ReverseMap(); // ArticleDTO isterse Article ile mapleme işlemi yap , ya da bunun tam tersi
            CreateMap<ArticleUpdateDTO, Article>().ReverseMap();
            CreateMap<ArticleUpdateDTO, ArticleDTO>().ReverseMap();// article üzerinden değil ArticleDTO üzerinden veri alış verişi yapıyoruz
            CreateMap<ArticleAddDTO, Article>().ReverseMap();
            //çift taraflı mapleme 

        }
    }
}
