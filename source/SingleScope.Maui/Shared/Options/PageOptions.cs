namespace SingleScope.Maui.Shared.Options
{
    public class PageOptions
    {
        /// <summary>
        /// Gets or sets the source page associated with the current application window.
        /// Either: Application.Current?.Windows[0].Page or Shell.Current
        /// </summary>
        /// <remarks>If the application has no windows or the window does not contain a page, this
        /// property may be <see langword="null"/>. Changing this property updates the reference to the page used as the
        /// source for window content.</remarks>
        public Page? PageSource { get; set; } = Application.Current?.Windows[0].Page;
    }
}
