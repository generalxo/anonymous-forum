using System.ComponentModel.DataAnnotations;

namespace anonymous_forum_csharp.Models
{
	public class TopicPostModel
	{
		// Primary Key
		[Key]
		public int Id { get; set; }

		// Entity Properties
		[Required]
		public int PostId { get; set; }

		[Required]
		public int TopicId { get; set; }

		// Navigation Properties
		public virtual TopicModel Topics { get; set; }
		public virtual PostModel Posts { get; set; }
	}
}
