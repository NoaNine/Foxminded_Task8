using System.Linq.Expressions;
using University.DAL.Models.Base;

namespace University.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : BaseModel
{
    TEntity GetById(object entity);
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}