﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SingleScope.Persistence.UnitOfWork;

namespace SingleScope.Persistence.EFCore.UnitOfWork
{
    /// <summary>
    /// EF Core implementation of the Unit of Work pattern.
    /// Wraps a _context instance to manage saving changes and optionally transactions.
    /// </summary>
    /// <typeparam name="TContext">The type of the _context being wrapped.</typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        protected readonly TContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        private IDbContextTransaction? _currentTransaction; // Tracks the explicit transaction, if any
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The _context instance, typically provided by Dependency Injection.</param>
        public UnitOfWork(TContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public TRepository GetRepository<TRepository>()
            where TRepository : notnull
        {
            return _repositories.TryGetValue(typeof(TRepository), out var repository) ? (TRepository)repository :
                throw new NullReferenceException($"No valid repository exist: {typeof(TRepository)}");
        }

        protected void AddRepository<TRepository>(TRepository repository)
            where TRepository : notnull
        {
            _repositories.Add(typeof(TRepository), repository);
        }

        /// <summary>
        /// Saves all changes made in the _context to the underlying database.
        /// EF Core automatically wraps this call in a transaction by default.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Begins a new database transaction explicitly.
        /// Use this only if you need to control the transaction boundary across multiple
        /// SaveChangesAsync calls or combine EF Core operations with other transactional work.
        /// Otherwise, rely on the transaction implicitly created by SaveChangesAsync.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <exception cref="InvalidOperationException">Thrown if a transaction is already in progress.</exception>
        public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            // Starts a new transaction using the _context's database facade.
            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        /// <summary>
        /// Commits the current explicit database transaction.
        /// Should only be called if BeginTransactionAsync was previously called.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <exception cref="InvalidOperationException">Thrown if no transaction is active.</exception>
        public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("Cannot commit transaction - no active transaction.");
            }

            try
            {
                // First, save any pending changes within the transaction scope.
                await SaveChangesAsync(cancellationToken);
                // Then, commit the transaction on the database.
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                // If commit fails, attempt to rollback.
                await RollbackTransactionInternalAsync(cancellationToken);
                throw;
            }
            finally
            {
                // Dispose the transaction object whether commit succeeded or failed.
                await DisposeTransactionInternalAsync();
            }
        }

        /// <summary>
        /// Rolls back the current explicit database transaction.
        /// Should only be called if BeginTransactionAsync was previously called.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        public virtual async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
            {
                // No explicit transaction active, nothing to roll back in this UoW scope.
                return;
            }

            try
            {
                await RollbackTransactionInternalAsync(cancellationToken);
            }
            finally
            {
                await DisposeTransactionInternalAsync();
            }
        }

        private async Task RollbackTransactionInternalAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
        }

        private async Task DisposeTransactionInternalAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        #region Dispose Pattern

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.
        /// Ensures any active explicit transaction is rolled back.
        /// </summary>
        public virtual async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            // Suppress finalization for this object
            Dispose(disposing: false);

            // Request CLR not to call the finalizer
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Core asynchronous disposal logic. Rolls back any pending explicit transaction.
        /// </summary>
        protected virtual async ValueTask DisposeAsyncCore()
        {
            // Rollback and dispose any lingering explicit transaction if it wasn't committed/rolled back properly.
            try
            {
                await RollbackTransactionInternalAsync();
            }
            finally
            {
                await DisposeTransactionInternalAsync();
            }

            // Note: We generally DO NOT dispose the _context here.
            // The _context lifetime is typically managed by the Dependency Injection container (e.g., Scoped).
            // Disposing it here could lead to issues if other services in the same scope still need it.
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            // Dispose managed resources
            Dispose(disposing: true);

            // Request CLR not to call the finalizer
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing">Indicates if the method call comes from a Dispose method (true) or from a finalizer (false).</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                try
                {
                    // Rollback and dispose any lingering explicit transaction synchronously if possible.
                    _currentTransaction?.Rollback();
                }
                finally
                {
                    _currentTransaction?.Dispose();
                    _currentTransaction = null;
                }

                // Again, typically DO NOT dispose _context here due to DI lifetime management.
            }

            _disposed = true;
        }

        #endregion
    }
}
