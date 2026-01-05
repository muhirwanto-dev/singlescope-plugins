# SingleScope.Mvvm

[![NuGet Version](https://img.shields.io/nuget/v/SingleScope.Mvvm.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Mvvm/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Mvvm.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Mvvm/)
[![License](https://img.shields.io/github/license/muhirwanto-dev/singlescope-plugins?style=flat-square)](LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/issues)
[![GitHub Stars](https://img.shields.io/github/stars/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/network/members)
[![Contributions Welcome](https://img.shields.io/badge/Contributions-Welcome-brightgreen.svg?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/pulls)

## Overview

A lightweight, modern MVVM foundation built on top of `CommunityToolkit.Mvvm`. It focuses on **architecture and structure**, not reimplementing MVVM mechanics.

## 🎯 Design Goals

- Extend CommunityToolkit.Mvvm (do not replace it)
- MVVM-pure (no UI references)
- XAML command-based lifecycle
- Explicit View ↔ ViewModel ownership
- Optional messaging participation

## 🧱 Core Concepts

### ViewModelBase
Base class for all ViewModels, inherits `ObservableObject`.

### InteractiveViewModelBase

Designed to be bound from XAML.

### RecipientViewModelBase
Opt-in base class for ViewModels that participate in messaging.

## 🧩 Ownership

Views may declare ownership via:

```csharp
IViewModelOwner<TViewModel>
```

And optionally decorate with:

```csharp
[ViewModelOwner(typeof(MyViewModel))]
```

## 🧠 Messaging

Messaging is not implemented here.
IMessageRecipient is a marker only and works alongside
`CommunityToolkit.Mvvm.Messaging`.

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

Project link: [https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Mvvm](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Mvvm)
