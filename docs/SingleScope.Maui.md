# SingleScope.Maui

[![NuGet Version](https://img.shields.io/nuget/v/SingleScope.Maui.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Maui/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SingleScope.Maui.svg?style=flat-square)](https://www.nuget.org/packages/SingleScope.Maui/)
[![License](https://img.shields.io/github/license/muhirwanto-dev/singlescope-plugins?style=flat-square)](LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/issues)
[![GitHub Stars](https://img.shields.io/github/stars/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/muhirwanto-dev/singlescope-plugins?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/network/members)
[![Contributions Welcome](https://img.shields.io/badge/Contributions-Welcome-brightgreen.svg?style=flat-square)](https://github.com/muhirwanto-dev/singlescope-plugins/pulls)

## Overview

`SingleScope.Maui` is a C# .NET library contains some features and utilities to build a `.NET MAUI` app faster. `ViewModelOwnerAttribute` used to minimize binding between `APageView` and `APageViewModel`, also `IAnimatedLoadingDialogService` can be used to show loading popup with custom animation.

## Key Features

* **Animated Loading:** Provide loading popup with custom animation.
* **Navigation Service:** Extended abstraction to handle page & shell navigation.
* **Reporting:** Write exception into logging and popup dialog with single line of code.
* **MVVM:** Write less code to bind between `Page` and `ViewModel`.

## Installation

Install the abstractions package via NuGet:

**Package Manager Console:**

```powershell
Install-Package SingleScope.Maui
```

**.NET CLI**
```bash
dotnet add package SingleScope.Maui
```

## Usage

**Dialog Service**

```csharp
using (var popup = _dialogService.ShowProgressiveLoading("Example progressive activity"))
{
    while (popup.ReturnValue.ProgressValue < 1.0)
    {
        popup.ReturnValue.ProgressValue += 0.1;
    }
}

using (var popup = _dialogService.ShowProgressiveLoading("Example progressive progress bar", ProgressiveLoadingProgressType.ProgressBar))
{
    while (popup.ReturnValue.ProgressValue < 1.0)
    {
        popup.ReturnValue.ProgressValue += 0.1;
    }
}

using (var popup = _dialogService.ShowFullPageLoading())
{
}

using (var popup = _dialogService.ShowLoading("Example scoped loading"))
{
}

using (var popup = _dialogService.ShowLoading("Example cancellable loading", cancelAction: () => { }))
{
}

using (var popup = _animatedLoadingDialogService.ShowLoading("Example gif loading"))
{
}
```

**View Model Owner**

```csharp
[ViewModelOwner(typeof(ExampleViewModel), IsDefaultConstructor = true)]
public partial class TestPage : ContentPage
{
}

// or

[ViewModelOwner<ExampleViewModel>(IsDefaultConstructor = false)]
public partial class TestPage : ContentPage
{
    public TestPage()
    {
        InitializeComponent();
        PostInitializeComponent();
    }
}
```

**Reporting**
```csharp
try
{
    // do something
}
catch (Exception ex)
{
    await _reportService.ReportAsync(ex);
}
```

**Navigation Service**
```chasrp
_navigationService.NavigateTo<TestPage>();

// this navigation works both for Page & Shell Navigation
_navigationService.NavigateTo<TestPage>(new Dictionary<string, object>
{
    ["key0"] = "value0",
    ["key1"] = "value1"
});
```

**Configure Dependency Injection**

```csharp
// Inject the services in MauiProgram.cs
builder
    .UseMauiApp<App>()
    .UseSingleScopeMaui();
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

Project link: [https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Maui](https://github.com/muhirwanto-dev/singlescope-plugins/tree/main/source/SingleScope.Maui)
