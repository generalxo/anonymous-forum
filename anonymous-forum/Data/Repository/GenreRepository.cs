using anonymous_forum.Data.Repository.IRepository;
using anonymous_forum.Models;

namespace anonymous_forum.Data.Repository
{
	public class GenreRepository : RepositoryBase<GenreModel>, IGenreRepository
	{
		public GenreRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
