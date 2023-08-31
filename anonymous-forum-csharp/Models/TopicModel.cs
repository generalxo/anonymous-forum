using System.ComponentModel.DataAnnotations;

namespace anonymous_forum_csharp.Models
{
	public class TopicModel
	{
		// Primary Key
		[Key]
		public int Id { get; set; }

		// Entity Properties
		[Required]
		[StringLength(100)]
		public string? Name { get; set; }

		[Required]
		[StringLength(250)]
		public string? Description { get; set; }

		// Navigation Properties
		public virtual IEnumerable<PostModel> Posts { get; set; }
	}
}
