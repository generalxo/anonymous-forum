namespace anonymous_forum_csharp.Models.ViewModels
{
    public class ThreadIndexViewModel
    {
        public List<PostModel>? PostList { get; set; }
        public ThreadCreateViewModel ThreadCreate { get; set; }
        public TopicModel? Topic { get; set; }
    }
}

