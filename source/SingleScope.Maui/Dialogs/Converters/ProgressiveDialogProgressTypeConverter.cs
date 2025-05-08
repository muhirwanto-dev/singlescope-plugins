using System.Globalization;
using CommunityToolkit.Maui.Converters;
using SingleScope.Maui.Dialogs.Enums;

namespace SingleScope.Maui.Dialogs.Converters
{
    [AcceptEmptyServiceProvider]
    public class ProgressiveDialogProgressTypeConverter : BaseConverterOneWay<ProgressiveLoadingProgressType, bool, ProgressiveLoadingProgressType>
    {
        public override bool DefaultConvertReturnValue { get; set; } = false;

        public override bool ConvertFrom(ProgressiveLoadingProgressType value, ProgressiveLoadingProgressType parameter, CultureInfo? culture = null)
        {
            return value == parameter;
        }
    }
}
