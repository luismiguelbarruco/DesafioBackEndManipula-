using DesafioManipulaeHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioManipulaeHealth.Domain.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
//#if DEBUG
//            if (System.Diagnostics.Debugger.IsAttached)
//                this.Database.EnsureCreated();
//#endif
        }

        public DbSet<VideoYoutube> VideosYoutube { get; set; }
        public DbSet<ResourceVideoYoutube> ResourcesVideoYoutube { get; set; }
        public DbSet<YoutubeSearchResultSnippet> YoutubeSearchsResultSnippet { get; set; }
        public DbSet<YoutubeThumbnailDetails> YoutubeThumbnailDetails { get; set; }
        public DbSet<YoutubeThumbnail> YoutubeThumbnails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($@"Data Source=youtube.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoYoutube>().ToTable("VideosYoutube");
            modelBuilder.Entity<ResourceVideoYoutube>().ToTable("ResourcesVideoYoutube");
            modelBuilder.Entity<YoutubeSearchResultSnippet>().ToTable("YoutubeSearchsResultSnippet");
            modelBuilder.Entity<YoutubeThumbnailDetails>().ToTable("YoutubeThumbnailDetails");
            modelBuilder.Entity<YoutubeThumbnail>().ToTable("YoutubeThumbnails");

            base.OnModelCreating(modelBuilder);
        }
    }
}
