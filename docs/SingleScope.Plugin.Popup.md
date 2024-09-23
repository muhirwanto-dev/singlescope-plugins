# SingleScope.Plugin.Popup
This plugin ensure the alert dialogs showing in UI thread, also handle the loading indicator as a popup.

## Installation
### Nuget Package
[![NuGet](https://img.shields.io/nuget/v/SingleScope.Plugin.Popup)](https://www.nuget.org/packages/SingleScope.Plugin.Popup/)

## Setup
### Logger
Set the logger at the beginning of the program or at the ``App.Ctor`` to enable logging, also set report mode to ``LogEnable | LogAndFullException | LogAndException``.
````
public App(ILogger<App> logger)
{
    PopupHelper.Instance
        .SetLogger(logger)
        .SetReportMode(PopupReportMode.LogAndFullException);
}
````
| ReportMode | Usage |
|---------|----------|
|Disabled|Completely disable the popup and logging|
|LogEnable|Write the exception with a specific logger without displaying it as popup|
|ShowFullException|Show the exception message and it's stack trace as a dialog|
|ShowExceptionMessage|Show the exception message as a dialog|
|LogAndFullException|Write the exception message and it's stack trace with a specific logger and show as a popup dialog|
|LogAndException|Write the exception message with a specific logger and show as a popup dialog|

#### Usage Example

````
try
{
}
catch (Exception ex)
{
    PopupHelper.Instance.ReportException(ex);
}
````