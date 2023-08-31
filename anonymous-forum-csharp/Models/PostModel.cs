using System.ComponentModel.DataAnnotations;

namespace anonymous_forum_csharp.Models
{
	public class PostModel
	{
		// Primary Key
		[Key]
		public int Id { get; set; }

		// Entity Properties
		[Required]
		[StringLength(100)]
		public string? Title { get; set; }

		[Required]
		public string? Text { get; set; }

		// Navigation Properties
		public virtual IEnumerable<TopicPostModel> TopicPosts { get; set; }
	}
}
