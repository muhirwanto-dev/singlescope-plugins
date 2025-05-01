namespace SingleScope.Maui.Mvvm.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ViewModelOwnerAttribute : Attribute
    {
        public Type ViewModelType { get; }

        public bool IsDefaultConstructor { get; init; } = false;

        public ViewModelOwnerAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ViewModelOwnerAttribute<TViewModel> : ViewModelOwnerAttribute
    {
        public ViewModelOwnerAttribute()
            : base(typeof(TViewModel))
        {
        }
    }
}
