using DAL.Repositories;

namespace DAL.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : class;
        
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        
    Task CommitAsync(CancellationToken cancellationToken = default);
        
    Task RollbackAsync(CancellationToken cancellationToken = default);
        
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}