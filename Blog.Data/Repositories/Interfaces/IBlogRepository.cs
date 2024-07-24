using Blog.Core.DTOS.Blog;
using Blog.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Interfaces
{
    public interface IBlogRepository:IRepository<Blog.Core.Entities.Models.Blog>
    {
        Task<IEnumerable<BlogReadDto>> GetRecentBlogsAsync(int count);

    }
}
