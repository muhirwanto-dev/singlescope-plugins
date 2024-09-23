namespace SingleScope.Plugin.Popup.Loading;

public partial class LoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    private LoadingParam? _param;
    public LoadingParam? Param
    {
        get => _param;
        set
        {
            _param = value;
            OnPropertyChanged();
        }
    }

    public LoadingPopup()
    {
        InitializeComponent();

        BindingContext = this;
    }
}