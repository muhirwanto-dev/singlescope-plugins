# SingleScope.Persistence

[![NuGet Version](https://img.shields.io/nuget/v/SingleScope.Persistence.EFCore.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Persistence.EFCore/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence.EFCore.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Persistence.EFCore/)
[![License](https://img.shields.io/github/license/muhirwanto-dev/singlescope-plugins?style=flat-square)](LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/issues)
[![GitHub Stars](https://img.shields.io/github/stars/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/network/members)
[![Contributions Welcome](https://img.shields.io/badge/Contributions-Welcome-brightgreen.svg?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/pulls)

## Overview

This library provides concrete implementations of the generic `IRepository<TEntity>` and `IUnitOfWork` interfaces from the [SingleScope.Persistence](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence) package, leveraging Entity Framework Core for data persistence.

## Features

* Generic Repository implementation (`Repository<TEntity>`) for `EntityFrameworkCore`.
* Unit of Work implementation (`UnitOfWork`) to manage transactions across multiple repositories.
* Easy integration with .NET Dependency Injection.

## Installation

You can install the package via NuGet Package Manager or the .NET CLI:

**Package Manager Console:**

```powershell
Install-Package SingleScope.Persistence.EFCore
```

**.NET CLI**
```bash
dotnet add package SingleScope.Persistence.EFCore
```

## Usage

**Configure Your `DbContext`**

Ensure you have an `DbContext` set up for your application.

```csharp
public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }
}
```

**Implement `IRepository<TEntity>` and `IUnitOfWork`**

```csharp
using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.EFCore.UnitOfWork;

// Read-Write repository
public class YourRwRepository<TEntity, TKey> : ReadWriteRepository<TEntity, TKey>
    where TEntity : class
{   
}

// Read-Only repository
public class YourRoRepository<TEntity, TKey> : ReadOnlyRepository<TEntity, TKey>
    where TEntity : class
{
}

// Unit of work
public class YourUnitOfWork<TContext> : UnitOfWork<TContext>
    where TContext : DbContext
{
    public YourUnitOfWork(TContext dbContext,
        YourRoRepository roRepository,
        YourRwRepository rwRepository)
        : base(dbContext)
    {
        AddRepository<YourRoRepository>(roRepository);
        AddRepository<YourRwRepository>(rwRepository);
    }
}
```

**Configure Dependency Injection**

```csharp
// Inject the services in Program.cs

// Option 1: inject generic Repository & UnitOfWork with db context at once
services.AddEfCorePersistence<YourDbContext>(builder => builder.UseSqlServer("your connection string"));

// Option 2: inject generic Repository & UnitOfWork and db context separately
services.AddEfCorePersistence();
services.AddDbContext<YourDbContext>(builder => builder.UseSqlServer("your connection string"));

// Inject specific Repository & UnitOfWork
services.AddScoped<IRepository<YourEntity, int>, YourRwRepository<YourEntity, int>>();
services.AddScoped<IReadRepository<YourEntity, int>, YourRoRepository<YourEntity, int>>();
services.AddScoped<IUnitOfWork<YourDbContext>, YourUnitOfWork<YourDbContext>>();
```

## Contributions

Contributions are welcome! If you encounter a bug, have a suggestion, or want to contribute code, please follow these steps:

1.  Check the [GitHub Issues](https://github.com/muhirwanto-dev/singlescope-plugins/issues) to see if your issue or idea has already been reported.
2.  If not, open a new issue to describe the bug or feature request.
3.  **For code contributions:**
    * Fork the Project repository.
    * Create your Feature Branch (`git checkout -b feature/YourAmazingFeature`).
    * Commit your Changes (`git commit -m 'Add YourAmazingFeature'`). Adhere to conventional commit messages if possible.
    * Push to the Branch (`git push origin feature/YourAmazingFeature`).
    * Open a Pull Request against the `main` branch of the original repository.
4.  Please try to follow the existing coding style and include unit tests for new or modified functionality.

## License

Distributed under the [MIT License](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main?tab=MIT-1-ov-file#readme). See the `LICENSE` file in the repository for more information.

## Contact

[@muhirwanto-dev](https://github.com/muhirwanto-dev)

Project link: [https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence.EFCore](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence.EFCore)
