using anonymous_forum.Data.Repository.IRepository;
using anonymous_forum.Models;

namespace anonymous_forum.Data.Repository
{
	public class GenrePostRepository : RepositoryBase<GenrePostModel>, IGenrePostRepository
	{
		public GenrePostRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
