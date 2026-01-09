using Microsoft.Extensions.DependencyInjection;
using SingleScope.Persistence.Abstraction;

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
            Type rw = typeof(IReadWriteRepository<TEntity>);
            Type ro = typeof(IRepository<TEntity>);

            services.AddScoped<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (ro.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddScoped(sp => (IRepository<TEntity>)sp.GetRequiredService<TImpl>());
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
            Type rw = typeof(IReadWriteRepository<TEntity>);
            Type ro = typeof(IRepository<TEntity>);

            services.AddTransient<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (ro.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddTransient(sp => (IRepository<TEntity>)sp.GetRequiredService<TImpl>());
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
            Type rw = typeof(IReadWriteRepository<TEntity>);
            Type ro = typeof(IRepository<TEntity>);

            services.AddSingleton<TImpl>();

            if (rr.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IReadRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (rw.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IReadWriteRepository<TEntity>)sp.GetRequiredService<TImpl>());
            }

            if (ro.IsAssignableFrom(typeof(TImpl)))
            {
                services.AddSingleton(sp => (IRepository<TEntity>)sp.GetRequiredService<TImpl>());
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
