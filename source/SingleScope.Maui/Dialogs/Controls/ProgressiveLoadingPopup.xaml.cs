namespace SingleScope.Maui.Dialogs.Controls;

public partial class ProgressiveLoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    private ProgressiveLoadingOptions? _options;

    public ProgressiveLoadingOptions? Options
    {
        get => _options;
        set
        {
            _options = value;
            OnPropertyChanged();
        }
    }

    private double _progressValue = 0.0;

    /// <summary>
    /// A double value that represents the current progress as a value from 0 to 1.
    /// Progress values less than 0 will be clamped to 0, values greater than 1 will be clamped to 1. The default value of this property is 0.
    /// </summary>
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

    public ProgressiveLoadingPopup()
    {
        InitializeComponent();

        BindingContext = this;
    }
}