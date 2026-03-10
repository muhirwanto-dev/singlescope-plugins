using SingleScope.Maui.Loadings.Options;

namespace SingleScope.Maui.Loadings.Controls;

public partial class ProgressiveLoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    public ProgressiveLoadingOptions? Options { get; }

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

    /// <summary>
    /// A double value that represents the current progress as a value from 0 to 1.
    /// Progress values less than 0 will be clamped to 0, values greater than 1 will be clamped to 1. The default value of this property is 0.
    /// </summary>
    private double _progressValue = 0.0;
    public double ProgressValue
    {
        get => _progressValue;
        set
        {
            _progressValue = Math.Clamp(value, 0.0, 1.0);
            OnPropertyChanged();
            OnPropertyChanged(nameof(ProgressValuePercent));
        }
    }

    public double ProgressValuePercent => ProgressValue * 100;

    public ProgressiveLoadingPopup(ProgressiveLoadingOptions options, string? message)
    {
        BindingContext = this;
        Options = options;
        Message = message;

        InitializeComponent();
    }
}