using System;
using System.Collections.Generic;

namespace SingleScope.Querying.Sorting
{
    public sealed class SortOptions
    {
        public IReadOnlyList<SortDescriptor> Sorts { get; }
            = Array.Empty<SortDescriptor>();

        public static SortOptions By(string field, SortDirection direction = SortDirection.Asc)
            => new SortOptions(new[]
            {
                new SortDescriptor(field, direction),
            });

        public SortOptions()
        {
        }

        public SortOptions(IReadOnlyList<SortDescriptor> sorts)
        {
            Sorts = sorts;
        }
    }
}
