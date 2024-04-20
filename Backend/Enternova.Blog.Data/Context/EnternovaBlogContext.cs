using Enternova.Blog.Data.Context.Extension;
using Enternova.Blog.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Enternova.Blog.Data.Context
{
    public class EnternovaBlogContext : DbContext
    {

        public EnternovaBlogContext()
        {
                
        }

        public EnternovaBlogContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBlogEntities();
            base.OnModelCreating(modelBuilder);
        }

    }
}
