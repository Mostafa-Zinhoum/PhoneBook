using PhB.Data;
using System.Linq.Expressions;

namespace PhB.Repo
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        TEntity GetByID(long id);

        void Insert(TEntity entity);

        void Delete(long id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
        void SaveChanges();
    }
}
