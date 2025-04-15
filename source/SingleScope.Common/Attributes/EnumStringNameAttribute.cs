namespace SingleScope.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public sealed class EnumStringNameAttribute : Attribute
    {
        public string Name { get; }

        public EnumStringNameAttribute(string name)
        {
            Name = name;
        }
    }
}
