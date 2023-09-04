using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace anonymous_forum_csharp.Models.ViewModels
{
    public class ThreadCreateViewModel
    {
        [DisplayName("Post title.")]
        [Required(ErrorMessage = "Post requires valid title name.")]
        public string Title { get; set; }
        [DisplayName("Post text.")]
        [Required(ErrorMessage = "Post requires text.")]
        public string Text { get; set; }
    }
}
