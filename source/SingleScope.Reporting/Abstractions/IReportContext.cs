using System.Collections.Generic;

namespace SingleScope.Reporting.Abstractions
{
    public interface IReportContext
    {
        IReadOnlyDictionary<string, object?> Properties { get; }
    }
}
