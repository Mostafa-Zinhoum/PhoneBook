using PhB.Data;

namespace PhB.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IRepository<T> Repository<T>() where T : BaseEntity;
    }
}
