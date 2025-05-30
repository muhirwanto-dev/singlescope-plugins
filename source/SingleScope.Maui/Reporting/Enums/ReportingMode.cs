﻿namespace SingleScope.Maui.Reporting.Enums
{
    public enum ReportingMode : uint
    {
        /// <summary>
        /// Write report to the given logger.
        /// </summary>
        EnableLogging = 1 << 0,

        /// <summary>
        /// Show report as error dialog.
        /// </summary>
        EnableErrorDialog = 1 << 1,

        /// <summary>
        /// Write exception as with it's stack tree. Otherwise, only write the exception message.
        /// </summary>
        EnableExceptionStackTrace = 1 << 2,

        Default = EnableLogging | EnableErrorDialog | EnableExceptionStackTrace,
    }
}
