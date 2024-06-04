using Microsoft.EntityFrameworkCore;
using DAL.DataBase;
using DAL.Interface;

namespace DAL.Repositories
{
    public class Repository<TEntity, TKey>(ApplicationDbContext dbContext) : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();
        public TEntity GetById(TKey id) => _dbSet.Find(id)!;
        public void Add(TEntity entity) => _dbSet.Add(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);
        public void Delete(TEntity entity) => _dbSet.Remove(entity);
    }
}