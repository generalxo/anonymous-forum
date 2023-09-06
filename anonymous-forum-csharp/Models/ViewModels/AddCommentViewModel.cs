using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace anonymous_forum_csharp.Models.ViewModels
{
    public class AddCommentViewModel
    {
        [DisplayName("Comment text.")]
        [Required(ErrorMessage = "Comment requires text.")]
        public string Text { get; set; }
    }
}
