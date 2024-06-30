namespace SingleScope.Plugin.Enums
{
    public enum PopupReportMode : uint
    {
        Disabled = 1 << 0,

        /// <summary>
        /// Show the exception as a popup dialog.
        /// </summary>
        ReportDialog = 1 << 1,

        /// <summary>
        /// Write the exception with specified logger.
        /// </summary>
        ReportLogging = 1 << 2,

        /// <summary>
        /// Write the exception with specified logger and show as a popup dialog.
        /// </summary>
        LogAndDialog = ReportDialog | ReportLogging,
    }
}
