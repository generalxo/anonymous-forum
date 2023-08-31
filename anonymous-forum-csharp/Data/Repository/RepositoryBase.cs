using anonymous_forum.Data.Repository.IRepository;
using anonymous_forum_csharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace anonymous_forum.Data.Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected ApplicationDbContext ApplicationDbContext { get; set; }
		public RepositoryBase(ApplicationDbContext applicationDbContext)
		{
			ApplicationDbContext = applicationDbContext;
		}
		public IQueryable<T> GetAll() => ApplicationDbContext.Set<T>().AsNoTracking();
		public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
			ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
		public void Create(T entity) => ApplicationDbContext.Set<T>().Add(entity);
		public void Update(T entity) => ApplicationDbContext.Set<T>().Update(entity);
		public void Delete(T entity) => ApplicationDbContext.Set<T>().Remove(entity);
	}
}
