namespace SingleScope.Persistence.Benchmarks.DataSource
{
    internal class RwVirtualRepositoryImpl : RwVirtualRepository
    {
        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            return base.Add(entity);
        }

        public override Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default)
        {
            return base.AddAsync(entity, cancellation);
        }

        public override void AddRange<TEntity>(IEnumerable<TEntity> entities)
        {
            base.AddRange(entities);
        }

        public override void AddRange<TEntity>(params TEntity[] entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return base.AddRangeAsync(entities, cancellation);
        }

        public override Task AddRangeAsync<TEntity>(params TEntity[] entities)
        {
            return base.AddRangeAsync(entities);
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            return base.Attach(entity);
        }

        public override void AttachRange<TEntity>(IEnumerable<TEntity> entities)
        {
            base.AttachRange(entities);
        }

        public override void AttachRange<TEntity>(params TEntity[] entities)
        {
            base.AttachRange(entities);
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
        {
            base.RemoveRange(entities);
        }

        public override void RemoveRange<TEntity>(params TEntity[] entities)
        {
            base.RemoveRange(entities);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }

        public override Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return base.SaveChangesAsync(cancellation);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            return base.Update(entity);
        }

        public override void UpdateRange<TEntity>(IEnumerable<TEntity> entities)
        {
            base.UpdateRange(entities);
        }

        public override void UpdateRange<TEntity>(params TEntity[] entities)
        {
            base.UpdateRange(entities);
        }
    }
}
