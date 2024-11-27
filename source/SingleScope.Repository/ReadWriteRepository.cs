using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SingleScope.Repository.Interface;

namespace SingleScope.Repository
{
    public abstract class ReadWriteRepository<TContext, TEntity> : ReadOnlyRepository<TContext, TEntity>, IReadWriteRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public ReadWriteRepository(TContext context) : base(context)
        {
        }

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Patch(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames)
        {
            var existing = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            ReadWriteRepository<TContext>.PatchInternal(_context, existing, entity, propertyNames, ignoreNull: false);

            _context.SaveChanges();
        }

        public virtual async Task PatchAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames)
        {
            var existing = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            ReadWriteRepository<TContext>.PatchInternal(_context, existing, entity, propertyNames, ignoreNull: false);

            await _context.SaveChangesAsync();
        }

        public virtual void PatchNotNull(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            var existing = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            ReadWriteRepository<TContext>.PatchInternal(_context, existing, entity, typeof(TEntity).GetProperties(), ignoreNull: true);

            _context.SaveChanges();
        }

        public virtual async Task PatchNotNullAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            var existing = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            ReadWriteRepository<TContext>.PatchInternal(_context, existing, entity, typeof(TEntity).GetProperties(), ignoreNull: true);

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }

    public abstract class ReadWriteRepository<TContext> : ReadOnlyRepository<TContext>, IReadWriteRepository
        where TContext : DbContext
    {
        public ReadWriteRepository(TContext context) : base(context)
        {
        }

        public virtual void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Patch<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames) where TEntity : class
        {
            var existing = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            PatchInternal(existing, entity, propertyNames, ignoreNull: false);

            _context.SaveChanges();
        }

        public virtual async Task PatchAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames) where TEntity : class
        {
            var existing = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            PatchInternal(existing, entity, propertyNames, ignoreNull: false);

            await _context.SaveChangesAsync();
        }

        public virtual void PatchNotNull<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var existing = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            PatchInternal(existing, entity, typeof(TEntity).GetProperties(), ignoreNull: true);

            _context.SaveChanges();
        }

        public virtual async Task PatchNotNullAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var existing = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (existing == null)
            {
                throw new NullReferenceException();
            }

            PatchInternal(existing, entity, typeof(TEntity).GetProperties(), ignoreNull: true);

            await _context.SaveChangesAsync();
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        private void PatchInternal<TEntity>(TEntity existing, TEntity entity, PropertyInfo[] properties, bool ignoreNull)
        {
            PatchInternal(_context, existing, entity, properties.Select(e => e.Name).ToArray(), ignoreNull);
        }

        private void PatchInternal<TEntity>(TEntity existing, TEntity entity, string[] propertyNames, bool ignoreNull)
        {
            PatchInternal(_context, existing, entity, propertyNames, ignoreNull);
        }

        internal static void PatchInternal<TEntity>(TContext context, TEntity existing, TEntity entity, PropertyInfo[] properties, bool ignoreNull)
        {
            PatchInternal(context, existing, entity, properties.Select(e => e.Name).ToArray(), ignoreNull);
        }

        internal static void PatchInternal<TEntity>(TContext context, TEntity existing, TEntity entity, string[] propertyNames, bool ignoreNull)
        {
            if (existing == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var entityType = typeof(TEntity);

            foreach (var name in propertyNames)
            {
                PropertyInfo? pInfo = entityType.GetProperty(name);

                if (pInfo == null)
                {
                    continue;
                }

                var entry = context.Entry(existing);
                var newValue = pInfo.GetValue(entity);

                if (newValue == null && ignoreNull)
                {
                    continue;
                }

                if (pInfo.CanWrite)
                {
                    pInfo.SetValue(existing, newValue);
                    entry.Property(name).IsModified = true;
                }
            }
        }
    }
}
