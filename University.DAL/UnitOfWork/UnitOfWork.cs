using Microsoft.EntityFrameworkCore;
using University.Dal.UnitOfWork;
using University.DAL.Repositories;

namespace University.DAL.UnitOfWork;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly UniversityContext _context;
    private bool _disposed = false;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(UniversityContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        _repositories = new Dictionary<Type, object>();
        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<TEntity>(_context);
        }
        return (IRepository<TEntity>)_repositories[type];
    }

    public void Save()
    {
        _context.SaveChanges();
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception(dbEx.Message, dbEx);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
}