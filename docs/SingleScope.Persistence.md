# SingleScope.Persistence

[![NuGet Version](https://img.shields.io/nuget/v/SingleScope.Persistence.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Persistence/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Persistence/)
[![License](https://img.shields.io/github/license/muhirwanto-dev/singlescope-plugins?style=flat-square)](LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/issues)
[![GitHub Stars](https://img.shields.io/github/stars/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/network/members)
[![Contributions Welcome](https://img.shields.io/badge/Contributions-Welcome-brightgreen.svg?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/pulls)

## Overview

`SingleScope.Persistence` is a C# .NET library providing core abstractions and building blocks for the **data persistence layer** of your applications. It aims to promote cleaner architecture, testability, and flexibility by offering common interfaces and patterns for interacting with data sources. While it facilitates the implementation of patterns like **Repository** and **Unit of Work**, its scope extends to general persistence concerns, providing a solid base for your data access strategy.

## Key Features

* **Core Abstractions for Data Persistence:** Provides fundamental interfaces and potentially base classes relevant to various data persistence tasks.
* **Facilitates Data Access Patterns:** Simplifies the implementation of common patterns like Repository and Unit of Work.
* **Generic `IRepository<TEntity, TKey>`:** Defines standard data access operations (Add, Update, Delete, GetAll, Find, etc.) adaptable for any entity.
* **`IUnitOfWork` Interface:** Offers a mechanism for managing atomic operations and coordinating changes across multiple data operations within a single transaction.
* **Promotes Separation of Concerns:** Helps isolate data access logic from your domain and application layers.
* **Dependency Injection Friendly:** Designed for seamless integration with standard .NET dependency injection containers.

## Installation

This library primarily provides **abstractions**. You will typically need to implement the provided interfaces based on your chosen data access technology (e.g., Entity Framework Core, Dapper, NHibernate, etc.), or potentially use a separate companion implementation package if available.

Install the abstractions package via NuGet:

**Package Manager Console:**

```powershell
Install-Package SingleScope.Persistence
```

**.NET CLI**
```bash
dotnet add package SingleScope.Persistence
```

## Usage

This library provides several abstractions for persistence. Below is an example demonstrating how to use the `IRepository<TEntity, TKey>` and `IUnitOfWork` interfaces, which are common components facilitated by this library. You might find other useful interfaces or base classes within the library depending on your specific persistence needs.

**Define Your Entity**

Implement your entity with `IEntity<TKey>` interface.

```csharp
public class Product : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

**Implement `IRepository<TEntity>` and `IUnitOfWork`**

```csharp
// Read-Write repository
public class YourRwRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{   
}

// Read-Only repository
public class YourRoRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
    where TEntity : class
{
}

// Unit of work
public class YourUnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
{
}
```

[`SingleScope.Persistence.EFCore`](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence.EfCore)
already have the implementation of both `IRepository` and `IUnitOfWork` specific to `EntityFrameworkCore`.

**Configure Dependency Injection**

```csharp
// Inject the services in Program.cs

services.AddScoped<IRepository<Entity, int>, YourRwRepository<Entity, int>>();
services.AddScoped<IReadRepository<Entity, int>, YourRoRepository<Entity, int>>();
services.AddScoped<IUnitOfWork<DbContext>, YourUnitOfWork<DbContext>>();
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

Project link: [https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Persistence)
