using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Controls;

public partial class AnimatedLoadingPopup : CommunityToolkit.Maui.Views.Popup
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

    public AnimatedLoadingPopup(LoadingOptions options, string? message)
    {
        ArgumentNullException.ThrowIfNull(options.Animation, nameof(options.Animation));

        BindingContext = this;
        Options = options;
        Message = message;

        InitializeComponent();
    }
}