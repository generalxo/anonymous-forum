using anonymous_forum_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace anonymous_forum_csharp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<TopicModel>? Topics { get; set; }
		public DbSet<PostModel>? Posts { get; set; }
		public DbSet<CommentModel>? Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Mapping Foreign Keys
			// Post Table
			modelBuilder.Entity<PostModel>()
				.HasOne(x => x.Topics)
				.WithMany(x => x.Posts)
				.HasForeignKey(x => x.TopicId);

			// Comment Table
			modelBuilder.Entity<CommentModel>()
				.HasOne(x => x.Posts)
				.WithMany(x => x.Comments)
				.HasForeignKey(x => x.PostId);

			// Database Seeding
			modelBuilder.Entity<TopicModel>().HasData(
					new TopicModel { Id = 1, Name = "General", Description = "General discussion" },
					new TopicModel { Id = 2, Name = "News", Description = "News and announcements" },
					new TopicModel { Id = 3, Name = "Help", Description = "Help and support" },
					new TopicModel { Id = 4, Name = "Suggestions", Description = "Suggestions and feedback" },
					new TopicModel { Id = 5, Name = "Off-Topic", Description = "Off-topic discussion" });

			modelBuilder.Entity<PostModel>().HasData(
					new PostModel { Id = 1, Title = "Forum rules", Text = "1. Be respectful to others. 2. No spamming. 3. No NSFW content. 4. No advertising. 5. No illegal content.", IpAdress = "::1", TopicId = 1 },
					new PostModel { Id = 2, Title = "Ukraine war", Text = "On 24 February 2022, Russia invaded Ukraine in an escalation of the Russo-Ukrainian War which began in 2014.", IpAdress = "::1", TopicId = 2 },
					new PostModel { Id = 3, Title = "How to change a tire", Text = "Before you start, make sure you find a safe place to park. It’s better to drive further and risk damaging the wheel rim than stop somewhere dangerous – such as on a narrow road.", IpAdress = "::1", TopicId = 3 },
					new PostModel { Id = 4, Title = "Add sports topic", Text = "I would like you to add sports topic so we can discuss F1!!", IpAdress = "::1", TopicId = 4 },
					new PostModel { Id = 5, Title = "Lucid dreams", Text = "A lucid dream is a type of dream in which the dreamer becomes aware that they are dreaming while dreaming.", IpAdress = "::1", TopicId = 5 });

			modelBuilder.Entity<CommentModel>().HasData(
					new CommentModel { Id = 1, Text = "First (comment)!", IpAdress = "::1", PostId = 1 },
					new CommentModel { Id = 2, Text = "Rickard was here", IpAdress = "::1", PostId = 2 });
		}

	}
}

