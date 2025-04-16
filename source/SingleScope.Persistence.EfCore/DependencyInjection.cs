using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.EFCore.UnitOfWork;
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
            services.TryAddScoped(typeof(IRepository<,,>), typeof(ReadWriteRepository<,,>));
            services.TryAddScoped(typeof(IReadRepository<,,>), typeof(ReadOnlyRepository<,,>));
            services.TryAddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }

        public static IServiceCollection AddEfCorePersistence<TContext>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextOptionsAction
            )
            where TContext : DbContext
        {
            services.TryAddScoped(typeof(IRepository<,,>), typeof(ReadWriteRepository<,,>));
            services.TryAddScoped(typeof(IReadRepository<,,>), typeof(ReadOnlyRepository<,,>));
            services.TryAddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddDbContext<TContext>(dbContextOptionsAction);

            return services;
        }
    }
}
