# 💡 SingleScope Plugins
SingleScope is **not a framework**. It is a set of opinionated adapters and composition helpers that integrate
best-in-class .NET libraries into consistent, production-ready application
architectures.

## 🤔 What is included in this repository?
This repository contains several .NET libraries which can be used in .NET 8, but can be expanded to support more framework and platforms. These libraries are also being used personally to build any applications I developed and keep improved with new ideas which always coming during the development.

| Package | Description | Latest Version | Download|
|---------|-------------|----------------|---------|
|[`SingleScope.Common`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Common.md)|A set of helpers which commonly used in other [`SingleScope`](https://github.com/muhirwanto-dev/singlescope-plugins) libraries.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Common)](https://www.nuget.org/packages/SingleScope.Common/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Common)|
|[`SingleScope.Maui`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Maui.md)|A set of helpers which can be used in MAUI project included with MVVM structure extensions . [`AnimatedLoadingDialogService`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/source/SingleScope.Maui/Dialogs/AnimatedLoadingDialogService.cs) can be used to show page loading dialog with `gif` as the indicator.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Maui)](https://www.nuget.org/packages/SingleScope.Maui/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Maui)|
|[`SingleScope.Persistence`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Persistence.md)|`SingleScope.Persistence` is a C# .NET library providing core abstractions and building blocks for the data persistence layer. It facilitates the implementation of patterns like [`Repository`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/source/SingleScope.Persistence/Repository/IRepository.cs) and [`UnitOfWork`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/source/SingleScope.Persistence/UnitOfWork/IUnitOfWork.cs).|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Persistence)](https://www.nuget.org/packages/SingleScope.Persistence/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence)|
|[`SingleScope.Persistence.EFCore`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Persistence.EFCore.md)|Implementation of `SingleScope.Persistence` specified to `EntityFrameworkCore`.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Persistence.EFCore)](https://www.nuget.org/packages/SingleScope.Persistence.EFCore/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence.EFCore)|

## Naming Convention

```
SingleScope.<Capability>.<Technology>
```

## 🚀 Getting Started
Please read the documentation for each respective library in the [/doc](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/docs) folder.

## 💪 Support
If you like this project and want to support it, you can [buy me a coffee︎](https://buymeacoffee.com/muhirwanto.dev). Your coffee will keep me awake while developing this project ☕.

<br />

<div align="center">
<a href="https://buymeacoffee.com/muhirwanto.dev"><img src="https://img.buymeacoffee.com/button-api/?text=Buy me a coffee&emoji=&slug=muhirwanto.dev&button_colour=FFDD00&font_colour=000000&font_family=Comic&outline_colour=000000&coffee_colour=ffffff" /></a>
</div>

***
