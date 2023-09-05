using anonymous_forum_csharp.Data;
using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Models;

namespace anonymous_forum.Data.Repository
{
    public class PostRepository : RepositoryBase<PostModel>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
