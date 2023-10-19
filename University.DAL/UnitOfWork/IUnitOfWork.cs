using University.DAL.Models.Base;
using University.DAL.Repositories;

namespace University.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseModel;
    void Save();
    void Dispose();
}