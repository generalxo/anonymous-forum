using anonymous_forum_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace anonymous_forum_csharp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<TopicModel>? Topics { get; set; }
		public DbSet<PostModel>? Posts { get; set; }
		public DbSet<TopicPostModel>? GenrePosts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Connection string
			//Edit the Data Source to your own SQL Server
			optionsBuilder.UseSqlServer(CString.connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Mapping Foreign Keys

			// GenrePostModel
			modelBuilder.Entity<TopicPostModel>()
				.HasOne(x => x.Topics)
				.WithMany(x => x.TopicPosts)
				.HasForeignKey(x => x.PostId);

			modelBuilder.Entity<TopicPostModel>()
				.HasOne(x => x.Posts)
				.WithMany(x => x.TopicPosts)
				.HasForeignKey(x => x.PostId);

			// Database Seeding
			modelBuilder.Entity<TopicModel>().HasData(
					new TopicModel { Id = 1, Name = "General", Description = "General discussion" },
					new TopicModel { Id = 2, Name = "News", Description = "News and announcements" },
					new TopicModel { Id = 3, Name = "Help", Description = "Help and support" },
					new TopicModel { Id = 4, Name = "Suggestions", Description = "Suggestions and feedback" },
					new TopicModel { Id = 5, Name = "Off-Topic", Description = "Off-topic discussion" });

			modelBuilder.Entity<PostModel>().HasData(
				new PostModel { Id = 1, Title = "Welcome to Anonymous Forum!", Text = "Welcome to Anonymous Forum! Feel free to post anything you want here. Just remember to follow the rules." },
					new PostModel { Id = 2, Title = "Rules", Text = "1. Be respectful to others. 2. No spamming. 3. No NSFW content. 4. No advertising. 5. No illegal content." },
					new PostModel { Id = 3, Title = "How to post", Text = "To post, simply click on the \"New Post\" button on the top right corner of the page. You can also reply to other posts by clicking on the \"Reply\" button." },
					new PostModel { Id = 4, Title = "How to format your post", Text = "You can format your post using Markdown." },
					new PostModel { Id = 5, Title = "How to format your post", Text = "You can format your post using Markdown." });

			modelBuilder.Entity<TopicPostModel>().HasData(
				new TopicPostModel { Id = 1, PostId = 1, GenreId = 1 },
					new TopicPostModel { Id = 2, PostId = 2, GenreId = 1 },
					new TopicPostModel { Id = 3, PostId = 3, GenreId = 1 },
					new TopicPostModel { Id = 4, PostId = 4, GenreId = 1 },
					new TopicPostModel { Id = 5, PostId = 5, GenreId = 1 }
				);
		}

	}
}
