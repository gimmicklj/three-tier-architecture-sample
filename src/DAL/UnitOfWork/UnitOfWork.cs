using DAL.Repositories;
using DAL.DataBase;

namespace DAL.UnitOfWork
{
    public class UnitOfWork (ApplicationDbContext dbContext) : IUnitOfWork, IDisposable
    {
        private bool _completed;
        private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly Dictionary<Type, object> _repositories = new();

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                _repositories.Add(typeof(TEntity), new Repository<TEntity, TKey>(_dbContext));
            }
            return (IRepository<TEntity, TKey>)_repositories[typeof(TEntity)];
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                await _dbContext.Database.BeginTransactionAsync(cancellationToken);
                _completed = true;
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                if (_completed)
                {
                    await _dbContext.Database.CommitTransactionAsync(cancellationToken);
                    _completed = false;
                }
            }
            catch (Exception)
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
        }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
                _completed = false;
            }
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        
        public void Dispose()
        {
            if (_completed)
            {
                try {
                    _dbContext.Database.RollbackTransaction();
                }
                catch (Exception ex) {
                    throw new InvalidOperationException("An error occurred while rolling back the transaction.", ex);
                }
                finally {
                    _completed = false;
                }
            }
            _dbContext.Dispose();
        }
    }
}
