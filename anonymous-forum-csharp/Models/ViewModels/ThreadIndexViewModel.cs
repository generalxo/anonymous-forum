namespace anonymous_forum_csharp.Models.ViewModels
{
    public class ThreadIndexViewModel
    {
        public PostModel? Post { get; set; }
        public List<PostModel>? PostList { get; set; }
        public ThreadCreateViewModel ThreadCreate { get; set; }

    }

}
