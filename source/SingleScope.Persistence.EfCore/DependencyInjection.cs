using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SingleScope.Persistence.EfCore.Repository;
using SingleScope.Persistence.EfCore.UnitOfWork;
using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.Repository;
using SingleScope.Persistence.UnitOfWork;

namespace SingleScope.Persistence.EfCore
{
    public static class DependencyInjection
    {
        // Option 1: Generic DbContext
        public static IServiceCollection AddEfCorePersistence<TContext>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextOptionsAction)
            where TContext : DbContext // Could also add IUnitOfWork constraint if DbContext implements it
        {
            // Register the DbContext itself
            services.AddDbContext<TContext>(dbContextOptionsAction);

            // Register the generic repository implementation
            // Scoped lifetime is typical for repositories tied to a DbContext scope
            services.AddScoped(typeof(IRepository<,>), typeof(EfCoreReadWriteRepository<,,>));
            services.AddScoped(typeof(IReadRepository<,>), typeof(EfCoreReadOnlyRepository<,,>));

            // Register the Unit of Work implementation
            // Option A: If DbContext directly implements IUnitOfWork
            // services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TContext>());

            // Option B: If you have a separate EfCoreUnitOfWork class wrapping TContext
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork<TContext>>(); // Assuming EfCoreUnitOfWork<TContext> exists

            // Register any other specific repositories or services for EF Core
            // services.AddScoped<IProductRepository, EfProductRepository>();

            return services;
        }
    }
}
