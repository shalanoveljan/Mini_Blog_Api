using Blog.Business.Responses;
using Blog.Core.DTOS.Blog;
using Blog.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface IBlogService
    {
        public Task<PagginatedResponse<BlogReadDto>> GetAllAsync(int pageNumber = 1, int pageSize = 6);

        public Task<IResult> CreateAsync(BlogCreateDto dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, BlogUpdateDto dto);
        public Task<IDataResult<BlogReadDto>> GetAsync(int id);

        Task<IDataResult<IEnumerable<BlogReadDto>>> GetRecentAsync(int count);
    }
}
