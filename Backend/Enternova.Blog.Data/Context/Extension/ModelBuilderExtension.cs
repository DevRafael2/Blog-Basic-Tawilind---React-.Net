using Enternova.Blog.Models.Entities.Blog;
using Enternova.Blog.Models.Entities.Logs;
using Enternova.Blog.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Enternova.Blog.Data.Context.Extension
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddBlogEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLogs", "Logs");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnType("uniqueidentifier");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.ToTable("LoginLogs", "Logs");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnType("uniqueidentifier");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts", "Blog");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnType("uniqueidentifier");
                entity.Property(x => x.UserId).HasColumnType("BIGINT");

                entity.HasOne(x => x.User).WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Security");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnType("BIGINT");

                entity.HasMany(x => x.LoginLogs).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id);

                entity.HasMany(x => x.Posts).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id);
            });


            return modelBuilder;
        }
    }
}
