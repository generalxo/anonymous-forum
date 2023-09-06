namespace anonymous_forum_csharp.Models.ViewModels
{
    public class CommentViewModel
    {
        public List<CommentModel>? CommentList { get; set; }
        public PostModel? Post { get; set; }
        public AddCommentViewModel AddComment { get; set; }
    }
}
