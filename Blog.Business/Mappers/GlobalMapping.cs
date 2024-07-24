using AutoMapper;
using Blog.Core.DTOS.Blog;

namespace Blog.Business.Mappers
{
    public class GlobalMapping:Profile
    {
        public GlobalMapping() 
        {
           
            CreateMap<Blog.Core.Entities.Models.Blog, BlogReadDto>().ReverseMap();
            CreateMap<Blog.Core.Entities.Models.Blog, BlogCreateDto>().ReverseMap();
            CreateMap<Blog.Core.Entities.Models.Blog, BlogUpdateDto>().ReverseMap();



        }

    }
}
