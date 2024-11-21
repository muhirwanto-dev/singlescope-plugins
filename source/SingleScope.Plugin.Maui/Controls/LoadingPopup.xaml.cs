using SingleScope.Plugin.Maui.Dialogs;

namespace SingleScope.Plugin.Maui.Controls;

public partial class LoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    private AnimatedLoadingOptions? _param;
    public AnimatedLoadingOptions? Param
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