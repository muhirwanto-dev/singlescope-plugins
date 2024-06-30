namespace SingleScope.Plugin.Enums
{
    public enum LoadingExceptionType : uint
    {
        /// <summary>
        /// Failed to show loading with specific scope
        /// </summary>
        ScopeAlreadyExist,

        /// <summary>
        /// Failed to hide loading with specific scope
        /// </summary>
        ScopeNotMatched,

        /// <summary>
        /// Failed to show loading while another one still exist
        /// </summary>
        MultipleDialog,
    }
}
