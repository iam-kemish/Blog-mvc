using DatasInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace DatasInformation.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        
        }
       public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Technology", Description = "All about tech and gadgets" },
        new Category { Id = 2, Name = "Health", Description = "Health tips and news" },
        new Category { Id = 3, Name = "Travel", Description = "Travel guides and experiences" },
        new Category { Id = 4, Name = "Food", Description = "Recipes and food reviews" },
        new Category { Id = 5, Name = "Sports", Description = "Sports news and events" }

                );
            modelBuilder.Entity<Post>().HasData(
                  new Post
                  {
                      Id = 1,
                      Title = "Latest Tech Trends 2025",
                      Content = "Stay updated with the latest technology trends for 2025.",
                      Author = "Theon",
                      PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0),
                      CategoryId = 1
                  },
                   new Post
                   {
                       Id = 2,
                       Title = "Healthy Eating Tips",
                       Content = "Learn how to eat healthy and maintain your lifestyle.",
                       Author = "Ramsay",
                       PublishedDate =  new DateTime(2025, 12, 17, 10, 0, 0),
                       CategoryId = 2
                   },
           new Post
        {
            Id = 3,
            Title = "Top Travel Destinations",
            Content = "Check out the most amazing travel destinations this year.",
            Author = "lockhead",
            PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0),
            CategoryId = 3
        }
                );
            modelBuilder.Entity<Comment>().HasData(
                 new Comment
                 {
                     Id = 1,
                     UserName = "Alice",
                     Content = "Great article! Learned a lot about tech.",
                     CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
                     PostId = 1
                 },
        new Comment
        {
            Id = 2,
            UserName = "Bob",
            Content = "Very helpful health tips, thanks!",
            CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
            PostId = 2
        },
        new Comment
        {
            Id = 3,
            UserName = "Charlie",
            Content = "I want to visit these places ASAP!",
            CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
            PostId = 3
        }
                );
        }
    }
}
