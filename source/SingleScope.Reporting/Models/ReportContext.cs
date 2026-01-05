using System.Collections.Generic;
using SingleScope.Reporting.Abstractions;

namespace SingleScope.Reporting.Models
{
    public sealed class ReportContext : IReportContext
    {
        private readonly Dictionary<string, object?> _properties = new Dictionary<string, object?>();

        public IReadOnlyDictionary<string, object?> Properties => _properties;

        public void Set(string key, object? value)
        {
            _properties[key] = value;
        }
    }

    /* The following core is the example implementation of IReportContext.
     * 
     * public IReportContext Create()
     * {
     *    var context = new ReportContext();
     * 
     *    context.Set("Page", Shell.Current?.CurrentItem?.Title);
     *    context.Set("Device", DeviceInfo.Model);
     *    context.Set("Platform", DeviceInfo.Platform.ToString());
     * 
     *    return context;
     * }
     */
}
