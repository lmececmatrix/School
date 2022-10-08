using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KinderGarten.Data
{
    public class KinderGartenContext
        : IdentityDbContext
    {

        public KinderGartenContext(DbContextOptions<KinderGartenContext> options)
            : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; } 
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
