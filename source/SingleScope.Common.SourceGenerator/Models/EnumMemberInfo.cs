namespace SingleScope.Common.SourceGenerator.Models
{
    internal class EnumMemberInfo
    {
        public string EnumField { get; }

        public string EnumValue { get; }

        public EnumMemberInfo(string enumField, string enumValue)
        {
            EnumField = enumField;
            EnumValue = enumValue;
        }
    }
}
