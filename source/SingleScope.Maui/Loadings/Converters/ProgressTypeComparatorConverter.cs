using System.Globalization;
using CommunityToolkit.Maui.Converters;
using SingleScope.Maui.Loadings.Core;

namespace SingleScope.Maui.Loadings.Converters
{
    [AcceptEmptyServiceProvider]
    public class ProgressTypeComparatorConverter : BaseConverterOneWay<ProgressiveType, bool, ProgressiveType>
    {
        public override bool DefaultConvertReturnValue { get; set; } = false;

        public override bool ConvertFrom(ProgressiveType value, ProgressiveType parameter, CultureInfo? culture = null)
        {
            return value == parameter;
        }
    }
}
