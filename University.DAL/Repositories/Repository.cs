using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using University.DAL.Models.Base;

namespace University.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
{
    private readonly UniversityContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(UniversityContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<TEntity>() ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public TEntity GetByID(object entity)
    {
        return _dbSet.Find(entity);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter == null)
        {
            return _dbSet.ToList();
        }
        return _dbSet.Where(filter).ToList();
    }

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}