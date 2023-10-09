using System.Linq.Expressions;

namespace University.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity GetByID(object entity);
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}