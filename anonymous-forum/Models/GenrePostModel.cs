using System.ComponentModel.DataAnnotations;

namespace anonymous_forum.Models
{
	public class GenrePostModel
	{
		// Primary Key
		[Key]
		public int Id { get; set; }

		// Entity Properties
		[Required]
		public int PostId { get; set; }

		[Required]
		public int GenreId { get; set; }

		// Navigation Properties
		public virtual GenreModel Genres { get; set; }
		public virtual PostModel Posts { get; set; }
	}
}
