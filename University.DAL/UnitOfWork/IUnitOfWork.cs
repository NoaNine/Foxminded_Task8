using University.DAL.Repositories;

namespace University.Dal.UnitOfWork;

public interface IUnitOfWork
{
    void Dispose();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    void Save();
}