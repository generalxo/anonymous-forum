using System.ComponentModel.DataAnnotations;

namespace anonymous_forum.Models
{
	public class GenreModel
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
		public IEnumerable<GenrePostModel> GenrePosts { get; set; }
	}
}
