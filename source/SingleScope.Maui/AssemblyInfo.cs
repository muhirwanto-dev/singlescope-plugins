//[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.SingleScopeNamespacePrefix + nameof(SingleScope.Maui.Controls))]
//[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.SingleScopeNamespacePrefix + nameof(SingleScope.Maui.Converters))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "singlescope")]

static class Constants
{
    public const string XamlNamespace = "http://schemas.nuget.org/dotnet/2024/maui/singlescope";
    public const string SingleScopeNamespace = $"{nameof(SingleScope)}.{nameof(SingleScope.Maui)}";
    public const string SingleScopeNamespacePrefix = $"{SingleScopeNamespace}.";
}