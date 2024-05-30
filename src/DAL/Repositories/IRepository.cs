namespace DAL.Repositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}