namespace SingleScope.Navigations.Maui.Models
{
    public sealed record ShellNavigationParams : MauiNavigationParams
    {
        public const string Relative = "";
        public const string RelativeTo = "/";
        public const string Absolute = "//";
        public const string AbsoluteClearStack = "///";

        public static readonly ShellNavigationParams Empty = new();

        public NavigationQuery Query { get; init; } = [];

        public string ShellRoute { get; set; } = Relative;

        public string CombinePath(string path)
            => $"{ShellRoute}{path}";
    }
}
