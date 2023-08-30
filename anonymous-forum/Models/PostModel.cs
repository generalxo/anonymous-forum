using System.ComponentModel.DataAnnotations;

namespace anonymous_forum.Models
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
		public IEnumerable<GenrePostModel> GenrePosts { get; set; }

	}
}
