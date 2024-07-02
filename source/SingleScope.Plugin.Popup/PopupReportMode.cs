namespace SingleScope.Plugin.Popup
{
    public enum PopupReportMode : uint
    {
        Disabled = 1 << 0,

        /// <summary>
        /// Write the exception with a specific logger.
        /// </summary>
        ErrorLogging = 1 << 1,

        /// <summary>
        /// Show the exception message and it's stack trace as a dialog.
        /// </summary>
        ShowFullException = 1 << 2,

        /// <summary>
        /// Show the exception message as a dialog.
        /// </summary>
        ShowExceptionMessage = 1 << 3,

        /// <summary>
        /// Write the exception with a specific logger and show as a popup dialog.
        /// </summary>
        LogAndFullException = ErrorLogging | ShowFullException,

        /// <summary>
        /// Write the exception with a specific logger and show as a popup dialog.
        /// </summary>
        LogAndException = ErrorLogging | ShowExceptionMessage,
    }
}
