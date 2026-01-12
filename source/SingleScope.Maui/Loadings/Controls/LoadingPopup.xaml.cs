using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Controls;

public partial class LoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    public LoadingOptions Options { get; }

    private string? _message = string.Empty;
    public string? Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public LoadingPopup(LoadingOptions options, string? message)
    {
        BindingContext = this;
        Options = options;
        Message = message;

        InitializeComponent();
    }
}