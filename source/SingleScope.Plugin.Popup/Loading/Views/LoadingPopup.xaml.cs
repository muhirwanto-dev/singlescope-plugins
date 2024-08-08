namespace SingleScope.Plugin.Popup.Loading;

public partial class LoadingPopup : CommunityToolkit.Maui.Views.Popup
{
    private Color? _backgroundColor;
    public Color? BackgroundColor
    {
        get => _backgroundColor;
        set
        {
            _backgroundColor = value;
            OnPropertyChanged();
        }
    }

    private float? _cornerRadius;
    public float? CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = value;
            OnPropertyChanged();
        }
    }

    private byte[]? _gifImageBuffer;
    public byte[]? GifImageBuffer
    {
        get => _gifImageBuffer;
        set
        {
            _gifImageBuffer = value;
            OnPropertyChanged();
        }
    }

    private double? _gifImageHeight;
    public double? GifImageHeight
    {
        get => _gifImageHeight;
        set
        {
            _gifImageHeight = value;
            OnPropertyChanged();
        }
    }

    private double? _gifImageWidth;
    public double? GifImageWidth
    {
        get => _gifImageWidth;
        set
        {
            _gifImageWidth = value;
            OnPropertyChanged();
        }
    }

    private string? _message;
    public string? Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public LoadingPopup()
    {
        InitializeComponent();

        BindingContext = this;
    }
}