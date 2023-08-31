using anonymous_forum.Data.Repository;
using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Models;

namespace anonymous_forum_csharp.Data.Repository
{
	public class TopicPostRepository : RepositoryBase<TopicPostModel>, ITopicPostRepository
	{
		public TopicPostRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
