using Microsoft.Extensions.DependencyInjection;
using SingleScope.Persistence.Entities;
using SingleScope.Persistence.Repository;

namespace SingleScope.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedRepository<TImpl, TEntity>(
            this IServiceCollection services)
            where TImpl : class
            where TEntity : class, IEntity
        {
            Type rr = typeof(IReadRepository<TEntity>);
            Type wr = typeof(IWriteRepository<TEntity>);
            Type rw = typeof(IReadWriteRepository<TEntity>);

            services.AddScoped<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (wr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            return services;
        }

        public static IServiceCollection AddScopedRepository<TService, TImpl, TEntity>(
            this IServiceCollection services)
            where TService : class
            where TImpl : class, TService
            where TEntity : class, IEntity
        {
            return services
                .AddScopedRepository<TImpl, TEntity>()
                .AddScoped<TService>(sp => sp.GetRequiredService<TImpl>());
        }

        public static IServiceCollection AddTransientRepository<TImpl, TEntity>(
            this IServiceCollection services)
            where TImpl : class
            where TEntity : class, IEntity
        {
            Type rr = typeof(IReadRepository<TEntity>);
            Type wr = typeof(IWriteRepository<TEntity>);
            Type rw = typeof(IReadWriteRepository<TEntity>);

            services.AddTransient<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (wr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            return services;
        }

        public static IServiceCollection AddTransientRepository<TService, TImpl, TEntity>(
            this IServiceCollection services)
            where TService : class
            where TImpl : class, TService
            where TEntity : class, IEntity
        {
            return services
                .AddTransientRepository<TImpl, TEntity>()
                .AddTransient<TService>(sp => sp.GetRequiredService<TImpl>());
        }

        public static IServiceCollection AddSingletonRepository<TImpl, TEntity>(
            this IServiceCollection services)
            where TImpl : class
            where TEntity : class, IEntity
        {
            Type rr = typeof(IReadRepository<TEntity>);
            Type wr = typeof(IWriteRepository<TEntity>);
            Type rw = typeof(IReadWriteRepository<TEntity>);

            services.AddSingleton<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (wr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            return services;
        }

        public static IServiceCollection AddSingletonRepository<TService, TImpl, TEntity>(
            this IServiceCollection services)
            where TService : class
            where TImpl : class, TService
            where TEntity : class, IEntity
        {
            return services
                .AddSingletonRepository<TImpl, TEntity>()
                .AddSingleton<TService>(sp => sp.GetRequiredService<TImpl>());
        }
    }
}
