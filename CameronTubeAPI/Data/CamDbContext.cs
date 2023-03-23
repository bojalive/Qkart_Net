using CameronTubeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CameronTubeAPI.Data
{
    public class CamDbContext : DbContext
    {

        public CamDbContext(DbContextOptions<CamDbContext> options)
        : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<LinkTable> LinkTableVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Video>().HasData(
                new Video
                {
                    Id = Guid.NewGuid(),
                    Kind = "youtube#video",
                    Etag = "Etag",
                    ChannelTitle = "Valves",
                    CategoryId = 1,
                    Tags = new List<string> { "d1", "d2" },
                    Url = "www.slb.com"
                },

                new Video
                {
                    Id = Guid.NewGuid(),
                    Kind = "sd#video",
                    Etag = "Etag",
                    ChannelTitle = "SubSea",
                    CategoryId = 1,
                    Tags = new List<string> { "d3", "d4" },
                    Url = "www.slb.com"
                }

                );

            modelBuilder.Entity<Snippet>().HasData(

                new Snippet
                {
                    Id = 1,
                    Description = "Sample 1",
                    PublishedAt = DateTime.Now.ToUniversalTime(),
                    ThumbnailUrl = "www.slb.com",
                    Title = "Title",
                },
                 new Snippet
                 {
                     Id = 2,
                     Description = "Sample 2",
                     PublishedAt = DateTime.Now.ToUniversalTime(),
                     ThumbnailUrl = "www.cameron.slb.com",
                     Title = "@@",
                 }

                );

            modelBuilder.Entity<Statistics>().HasData(

                new Statistics
                {
                    Id = 1,
                    ViewCount = 50,
                    LikeCount = 5,
                    DislikeCount = 1,
                    FavoriteCount = 5,
                    CommentCount = 2
                },
                  new Statistics
                  {
                      Id = 2,
                      ViewCount = 50,
                      LikeCount = 5,
                      DislikeCount = 1,
                      FavoriteCount = 5,
                      CommentCount = 2
                  }
                );
        }
    }
}
