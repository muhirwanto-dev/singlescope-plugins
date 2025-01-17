namespace SingleScope.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public sealed class EnumNameAttribute : Attribute
    {
        public string Name { get; }

        public EnumNameAttribute(string name)
        {
            Name = name;
        }
    }
}
