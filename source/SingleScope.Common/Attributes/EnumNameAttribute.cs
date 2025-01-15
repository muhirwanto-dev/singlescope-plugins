namespace SingleScope.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public sealed class EnumNameAttribute : Attribute
    {
        public string Name { get; }

        public EnumNameAttribute(string name)
        {
            Name = name;
        }
    }
}
