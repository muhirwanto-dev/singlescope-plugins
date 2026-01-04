using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SingleScope.Persistence.Abstraction;
using SingleScope.Persistence.EFCore.Repositories;
using SingleScope.Persistence.EFCore.UnitOfWork;

namespace SingleScope.Persistence.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCorePersistence(
            this IServiceCollection services
            ) => services
                .AddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>))
                .AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>))
                .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

        public static IServiceCollection AddEfCorePersistence<TContext>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextOptionsAction
            )
            where TContext : DbContext => services
                .AddEfCorePersistence()
                .AddDbContext<TContext>(dbContextOptionsAction);
    }
}
