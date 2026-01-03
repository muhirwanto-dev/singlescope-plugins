using System;
using System.Collections.Generic;

namespace SingleScope.Querying.Filtering
{
    public sealed class FilterOptions
    {
        public IReadOnlyList<FilterDescriptor> Filters { get; }
            = Array.Empty<FilterDescriptor>();

        public static FilterOptions Empty => new FilterOptions();

        public FilterOptions()
        {
        }

        public FilterOptions(IReadOnlyList<FilterDescriptor> filters)
        {
            Filters = filters;
        }
    }
}
