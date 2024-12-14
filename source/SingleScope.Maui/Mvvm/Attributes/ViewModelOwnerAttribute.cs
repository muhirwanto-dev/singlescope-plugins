namespace SingleScope.Maui.Mvvm.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ViewModelOwnerAttribute : Attribute
    {
        public Type ViewModelType { get; }

        public bool IsDefaultConstructor { get; init; } = true;

        public ViewModelOwnerAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
