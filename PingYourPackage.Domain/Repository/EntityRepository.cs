using PingYourPackage.Domain.IRepositories;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace PingYourPackage.Domain.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        readonly DbContext _entitiesDbContext;

        public EntityRepository(DbContext dbContext)
        {
            if (null == dbContext)
            {
                throw new ArgumentNullException("dbContext");
            }
            _entitiesDbContext = dbContext;
        }

        public IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entityEntry = _entitiesDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Added;
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entitiesDbContext.Set<T>();

            foreach (var item in includeProperties)
            {
                query.Include(item);
            }
            return query;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entityEntry = _entitiesDbContext.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entitiesDbContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entitiesDbContext.Set<T>();
        }

        public T GetSingle(Guid Key)
        {
            return GetAll().FirstOrDefault<T>(item => item.Key == Key);
        }

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector)
        {
            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AllIncluding(includeProperties).OrderBy(keySelector);

            query = predicate == null ? query : query.Where(predicate);

            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual void Save()
        {
            _entitiesDbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry<T> entityEntry = _entitiesDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
