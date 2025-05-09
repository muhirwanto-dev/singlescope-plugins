using SingleScope.Common.Attributes;

namespace SingleScope.Sample.Common
{
    [EnumStringMap]
    public enum TestEnumType
    {
        [EnumStringName("TestingA")]
        A,
        B,
    }
}
