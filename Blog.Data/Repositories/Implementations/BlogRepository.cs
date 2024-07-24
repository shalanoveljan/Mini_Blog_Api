using Blog.Core.DTOS.Blog;
using Blog.Data.DBContext;
using Blog.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Implementations
{
    public class BlogRepository:BaseRepository<Blog.Core.Entities.Models.Blog>,IBlogRepository
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogReadDto>> GetRecentBlogsAsync(int count)
        {
            return await _context.Blogs
                                 .OrderByDescending(b => b.CreatedAt) 
                                 .Take(count)
                                  .Select(b => new BlogReadDto
                                  {
                                      Id = b.Id,
                                      Title = b.Title,
                                      Content = b.Content,
                                      CreatedAt = b.CreatedAt,
                                  })
                                 .ToListAsync();
        }
    }
}
