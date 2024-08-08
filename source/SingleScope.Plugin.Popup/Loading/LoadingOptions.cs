namespace SingleScope.Plugin.Popup.Loading
{
    public class LoadingOptions
    {
        public byte[]? GifImageBuffer { get; set; }

        public int? GifImageHeight { get; set; }

        public int? GifImageWidth { get; set; }

        public Color? BackgroundColor { get; set; }

        public float CornerRadius { get; set; } = 0;
    }
}
