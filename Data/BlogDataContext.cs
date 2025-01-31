using BlogEf.Data.Mappings;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEf.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagsCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=QBk88ka(6>;TrustServerCertificate=True");
            //options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());


            modelBuilder.Entity<PostWithTagsCount>().HasNoKey();

            modelBuilder.Entity<PostWithTagsCount>(x =>
            {
                x.ToSqlQuery(@"SELECT [Title] as [NAME], COUNT(Id) AS [COUNT] FROM Post GROUP BY ID, [Title]");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}