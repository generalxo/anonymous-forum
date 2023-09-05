using anonymous_forum_csharp.Data;
using anonymous_forum_csharp.Data.Repository.IRepository;
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
        public void Create(T entity)
        {
            ApplicationDbContext.Set<T>().Add(entity);
            ApplicationDbContext.SaveChanges(); // Save changes to the database
        }
        public void Update(T entity) => ApplicationDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => ApplicationDbContext.Set<T>().Remove(entity);
    }
}
