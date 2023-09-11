using System.ComponentModel.DataAnnotations;

namespace anonymous_forum_csharp.Models
{
    public class CommentModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Entity Properties
        [Required]
        [StringLength(250)]
        public string? Text { get; set; }

        [Required]
        public string? IpAdress { get; set; }

        // Foreign Key
        [Required]
        public int PostId { get; set; }


        // Navigation Properties
        public virtual PostModel Posts { get; set; }
    }
}
