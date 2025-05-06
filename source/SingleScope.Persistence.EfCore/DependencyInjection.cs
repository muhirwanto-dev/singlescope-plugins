using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SingleScope.Persistence.EFCore.Querying;
using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.EFCore.UnitOfWork;
using SingleScope.Persistence.Querying;
using SingleScope.Persistence.Repository;
using SingleScope.Persistence.UnitOfWork;

namespace SingleScope.Persistence.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCorePersistence(
            this IServiceCollection services
            )
        {
            services.AddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>));
            services.AddScoped(typeof(IReadRepository<,>), typeof(ReadOnlyRepository<,>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddSingleton<ISpecificationEvaluator, SpecificationEvaluator>();

            return services;
        }

        public static IServiceCollection AddEfCorePersistence<TContext>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextOptionsAction
            )
            where TContext : DbContext
        {
            services.TryAddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>));
            services.TryAddScoped(typeof(IReadRepository<,>), typeof(ReadOnlyRepository<,>));
            services.TryAddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.TryAddSingleton<ISpecificationEvaluator, SpecificationEvaluator>();

            services.AddDbContext<TContext>(dbContextOptionsAction);

            return services;
        }

        public static IServiceProvider UseSingleScopePersistence(this IServiceProvider serviceProvider)
        {
            ServiceLocator.Provider = serviceProvider;

            return serviceProvider;
        }
    }
}
