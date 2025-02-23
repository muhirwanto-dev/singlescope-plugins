namespace SingleScope.Maui.Dialogs.Controls;

public partial class LoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    private AnimatedLoadingOptions? _options;
    public AnimatedLoadingOptions? Options
    {
        get => _options;
        set
        {
            _options = value;
            OnPropertyChanged();
        }
    }

    public LoadingPopup()
    {
        InitializeComponent();

        BindingContext = this;
    }
}