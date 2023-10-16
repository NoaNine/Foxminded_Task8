using University.DAL.Repositories;

namespace University.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    void Save();
    void Dispose();
}