using AutoMapper;
using Blog.Business.Responses;
using Blog.Business.Services.Interfaces;
using Blog.Core.DTOS.Blog;
using Blog.Core.Entities.Models;
using Blog.Core.Utilities.Results.Abstract;
using Blog.Core.Utilities.Results.Concrete.ErrorResults;
using Blog.Core.Utilities.Results.Concrete.SuccessResults;
using Blog.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        readonly IBlogRepository _blogRepository;
        readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

      public async Task<IResult> CreateAsync(BlogCreateDto dto)
    {
        var blog = _mapper.Map<Blog.Core.Entities.Models.Blog>(dto);

        await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveChangesAsync();

            return new SuccessResult("Blog created successfully.");
    }

    public async Task<PagginatedResponse<BlogReadDto>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
    {
            PagginatedResponse<BlogReadDto> pagginatedResponse = new PagginatedResponse<BlogReadDto>();
            pagginatedResponse.CurrentPage = pageNumber;
            var query = _blogRepository.GetQuery(x => !x.IsDeleted)
               .AsNoTrackingWithIdentityResolution();
            pagginatedResponse.TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize);

            var blogs = await query.Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
            .ToListAsync();

            pagginatedResponse.Items = _mapper.Map<List<BlogReadDto>>(blogs);

            return pagginatedResponse;
        }

    public async Task<IDataResult<BlogReadDto>> GetAsync(int id)
    {
            var blog = await _blogRepository.GetAsync(x => !x.IsDeleted && x.Id == id);


            if (blog == null)
            {
                return new ErrorDataResult<BlogReadDto>("Get Blog");
            }
                var blogDto = _mapper.Map<BlogReadDto>(blog);
        return new SuccessDataResult<BlogReadDto>(blogDto,"Get Blog");
    }

    public async Task<IResult> RemoveAsync(int id)
    {
            var blog = await _blogRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (blog == null)
        {
            return new ErrorResult("Blog not found.");
        }

        blog.IsDeleted = true;
        await _blogRepository.UpdateAsync(blog);
        await _blogRepository.SaveChangesAsync();


            return new SuccessResult("Blog removed successfully.");
    }

    public async Task<IResult> UpdateAsync(int id, BlogUpdateDto dto)
    {
        var blog = await _blogRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
        if (blog == null)
        {
            return new ErrorResult("Blog not found.");
        }

        blog.Title = dto.Title;
        blog.Content = dto.Content;
        blog.UpdatedAt = DateTime.UtcNow;

        await _blogRepository.UpdateAsync(blog);
        await _blogRepository.SaveChangesAsync();


            return new SuccessResult("Blog updated successfully.");
    }


        public async Task<IDataResult<IEnumerable<BlogReadDto>>> GetRecentAsync(int count)
        {
            // En son eklenen veya güncellenen blogları döndürmek için gerekli iş mantığını burada uygulayın
            // Örneğin, veritabanından en son blogları getirin
            var recentBlogs = await _blogRepository.GetRecentBlogsAsync(count);
            if (recentBlogs == null)
            {
                return new ErrorDataResult<IEnumerable<BlogReadDto>>("recent Blogs not found");

              
            }

            return new SuccessDataResult<IEnumerable<BlogReadDto>>(recentBlogs, "Get Blog");
        }
    }
}
