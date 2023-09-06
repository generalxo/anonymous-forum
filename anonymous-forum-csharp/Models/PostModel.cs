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

        [Required]
		public int TopicId { get; set; }
        
		// Navigation Properties
        public virtual TopicModel Topics { get; set; }

		public virtual IEnumerable<CommentModel> Comments { get; set; }
	}
}
