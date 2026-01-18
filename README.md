# 💡 SingleScope Plugins
SingleScope is **not a framework**. It is a set of opinionated adapters and composition helpers that integrate
best-in-class .NET libraries into consistent, production-ready application
architectures.

## 🤔 What is included in this repository?
This repository contains several .NET libraries which can be used in .NET 8, but can be expanded to support more framework and platforms. These libraries are also being used personally to build any applications I developed and keep improved with new ideas which always coming during the development.

| Package | Description | Latest Version | Download|
|---------|-------------|----------------|---------|
|[`SingleScope.Common`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Common.md)|Shared core utilities, constants, and basic helpers used across the `SingleScope` ecosystem.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Common)](https://www.nuget.org/packages/SingleScope.Common/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Common)|
|[`SingleScope.Extensions.Json`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Extensions.Json.md)|Advanced JSON serialization and deserialization extensions for streamlined data handling.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Extensions.Json)](https://www.nuget.org/packages/SingleScope.Extensions.Json/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Extensions.Json)|
|[`SingleScope.Maui`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Maui.md)|UI components for .NET MAUI, including `IDialogService` and animated loading popups for process waiting.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Maui)](https://www.nuget.org/packages/SingleScope.Maui/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Maui)|
|[`SingleScope.Mvvm.Maui`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Mvvm.Maui.md)|MVVM extensions for .NET MAUI, featuring `ViewModelOwnerAttribute` to automate View-ViewModel binding.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Mvvm.Maui)](https://www.nuget.org/packages/SingleScope.Mvvm.Maui/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Mvvm.Maui)|
|[`SingleScope.Navigations.Maui`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Navigations.Maui.md)|A lightweight navigation service designed specifically for .NET MAUI MVVM applications.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Navigations.Maui)](https://www.nuget.org/packages/SingleScope.Navigations.Maui/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Navigations.Maui)|
|[`SingleScope.Persistence`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Persistence.md)|Core abstractions for data persistence, including `Repository` and `UnitOfWork` patterns.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Persistence)](https://www.nuget.org/packages/SingleScope.Persistence/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence)|
|[`SingleScope.Persistence.EFCore`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Persistence.EFCore.md)|Concrete implementation of persistence abstractions using `Entity Framework Core`.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Persistence.EFCore)](https://www.nuget.org/packages/SingleScope.Persistence.EFCore/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Persistence.EFCore)|
|[`SingleScope.Querying`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Querying.md)|Utility for building dynamic queries, filtering, and sorting logic within the persistence layer.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Querying)](https://www.nuget.org/packages/SingleScope.Querying/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Querying)|
|[`SingleScope.Reporting`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Reporting.md)|Helpers and services for generating data reports and exporting information from the application.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Reporting)](https://www.nuget.org/packages/SingleScope.Reporting/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Reporting)|
|[`SingleScope.Reporting.Logging`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Reporting.Logging.md)|Extension services for tracking, capturing, and logging application behavior and report generation events into logging infrastructure.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Reporting.Logging)](https://www.nuget.org/packages/SingleScope.Reporting.Logging/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Reporting.Logging)|
|[`SingleScope.Reporting.Maui`](https://github.com/muhirwanto-dev/singlescope-plugins/blob/main/docs/SingleScope.Reporting.Maui.md)|.NET MAUI specific helpers for exporting reports, handling and displaying data summaries on mobile/desktop devices.|[![NuGet](https://img.shields.io/nuget/v/SingleScope.Reporting.Maui)](https://www.nuget.org/packages/SingleScope.Reporting.Maui/)|![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Reporting.Maui)|

## Naming Convention

```
SingleScope.<Capability>.<Technology>
```

## 🚀 Getting Started
Please read the documentation for each respective library in the [/docs](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/docs) folder.

## 💪 Support
If you like this project and want to support it, you can [buy me a coffee︎](https://buymeacoffee.com/muhirwanto.dev). Your coffee will keep me awake while developing this project ☕.

<br />

<div align="center">
<a href="https://buymeacoffee.com/muhirwanto.dev"><img src="https://img.buymeacoffee.com/button-api/?text=Buy me a coffee&emoji=&slug=muhirwanto.dev&button_colour=FFDD00&font_colour=000000&font_family=Comic&outline_colour=000000&coffee_colour=ffffff" /></a>
</div>

***
