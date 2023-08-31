using System.Linq.Expressions;

namespace anonymous_forum.Data.Repository.IRepository
{
	public interface IRepositoryBase<T>
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
