using KinderGarten.Data;
using KinderGarten.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace KinderGarten.Repositories
{
    public class BlogRepository
    {
        private readonly KinderGartenContext _context;

        public async Task<List<BlogModel>> GetAllBlogs()
        {
            var blogs = new List<BlogModel>();
            var allBlogs = await _context.Blogs.ToListAsync();

            if (allBlogs?.Any() == true)
            {
                foreach (var blog in allBlogs)
                {
                    blogs.Add(new BlogModel()
                    {
                        Id = blog.Id,
                        Name = blog.Name,
                        Description = blog.Description,
                        Class = blog.Class,
                        Comments = blog.Comments,
                        User = blog.User
                    });
                }
            }

            return blogs;
        }

        public async Task<BlogModel> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog != null)
            {
                return new BlogModel()
                {
                    Id = blog.Id,
                    Name = blog.Name,
                    Description = blog.Description,
                    Class = blog.Class,
                    Comments = blog.Comments,
                    User = blog.User
                };
            }

            return null;
        }
        public async Task<int> Create(BlogModel model)
        {
            var blog = new Blog()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Class = model.Class,
                Comments = model.Comments,
                User = model.User
            };

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return blog.Id;
        }

    }
}
