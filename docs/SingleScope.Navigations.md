# SingleScope.Navigations

[![NuGet Version](https://img.shields.io/nuget/v/SingleScope.Navigations.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Navigations/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Navigations.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Navigations/)
[![License](https://img.shields.io/github/license/muhirwanto-dev/singlescope-plugins?style=flat-square)](LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/issues)
[![GitHub Stars](https://img.shields.io/github/stars/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/network/members)
[![Contributions Welcome](https://img.shields.io/badge/Contributions-Welcome-brightgreen.svg?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/pulls)

## Overview

`SingleScope.Navigation` provides a **platform-agnostic navigation abstraction** designed to model the full navigation feature set of .NET MAUI (Page Navigation and Shell Navigation).

This package contains **no UI dependencies** and is safe to use in ViewModels.

## 🎯 Design Goals

- Feature-complete abstraction (Shell + Page)
- Honest capability reporting
- ViewModel-friendly API
- Adapter-based platform integration
- No ServiceLocator
- Testable and extensible

## 🧱 Core Concepts

### INavigationService
The single entry point used by ViewModels.

### INavigationCapabilities
Describes which navigation features are supported
by the active implementation.

### NavigationRequest
A superset request model that supports:
- routing
- parameters
- modal navigation
- stack reset

### NavigationResult
Explicit success/failure result without throwing exceptions.

## 📦 Platform Implementations

This package is intended to be implemented by:
- `SingleScope.Navigations.Maui`
- future platforms (WPF, Avalonia, etc.)

## Installation

This library primarily provides **abstractions**. You will typically need to implement the provided interfaces based on your chosen data access technology (e.g., Entity Framework Core, Dapper, NHibernate, etc.), or potentially use a separate companion implementation package if available.

Install the abstractions package via NuGet:

**Package Manager Console:**

```powershell
Install-Package SingleScope.Navigations
```

**.NET CLI**
```bash
dotnet add package SingleScope.Navigations
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

Project link: [https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Navigations](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Navigations)
