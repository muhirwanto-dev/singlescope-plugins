using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SingleScope.Maui.SourceGenerator.Generators
{
    [Generator(LanguageNames.CSharp)]
    public class ViewModelOwnerAttributeGenerator : IIncrementalGenerator
    {
        private const string AttributeNamespace = "SingleScope.Maui.Mvvm.Attributes.ViewModelOwnerAttribute";

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Look for classes with the ViewModelOwnerAttribute attribute
            var classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => IsClassWithAttribute(node),
                    transform: (syntaxContext, _) => GetSemanticTargetForGeneration(syntaxContext))
                .Where(classSymbol => classSymbol != null);

            // Register the source generator
            context.RegisterSourceOutput(classDeclarations, (productionContext, classSymbol) =>
            {
                var sourceCode = GenerateSourceCode(classSymbol);

                productionContext.AddSource($"{classSymbol.Name}_ViewModelOwner.g.cs", sourceCode);
            });
        }

        private static bool IsClassWithAttribute(SyntaxNode node)
        {
            // Ensure the node is a class with attributes
            return node is ClassDeclarationSyntax syntax && syntax.AttributeLists.Count > 0;
        }

        private static INamedTypeSymbol GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
        {
            var classDeclaration = (ClassDeclarationSyntax)context.Node;

            // Check if the class has the ViewModelOwnerAttribute attribute
            foreach (var attributeList in classDeclaration.AttributeLists)
            {
                foreach (var attribute in attributeList.Attributes)
                {
                    var symbol = context.SemanticModel.GetSymbolInfo(attribute).Symbol?.ContainingType;
                    if (symbol?.ToDisplayString() == AttributeNamespace)
                    {
                        return context.SemanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
                    }
                }
            }

            return null;
        }

        private static string GenerateSourceCode(INamedTypeSymbol classSymbol)
        {
            // Retrieve the class name and attribute argument (ViewModel type)
            var className = classSymbol.Name;

            // Retrieve attribute class data
            var attributeData = classSymbol.GetAttributes()
                .First(attr => attr.AttributeClass?.ToDisplayString() == AttributeNamespace);

            // Full name with namespace
            var viewModelSymbol = attributeData.ConstructorArguments[0].Value as INamedTypeSymbol;
            var viewModelName = viewModelSymbol?.ToDisplayString();

            // Retrieve the IsDefaultConstructor from the named arguments
            // Extract information from the attribute data
            var attributeProperties = attributeData.NamedArguments.ToDictionary(
                arg => arg.Key,
                arg => arg.Value.Value?.ToString() ?? "null"
            );

            // Check for specific properties in the attribute data
            var isDefaultConstructor = true;
            if (attributeProperties.ContainsKey("IsDefaultConstructor"))
            {
                isDefaultConstructor = bool.Parse(attributeProperties["IsDefaultConstructor"]);
            }

            // Class namespace
            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            if (isDefaultConstructor)
            {
                return CreateClassWithDefaultConstructor(namespaceName, className, viewModelName);
            }
            else
            {
                return CreateClass(namespaceName, className, viewModelName);
            }
        }

        private static bool GetBoolPropertyValue(IPropertySymbol propertySymbol)
        {
            // Find the initializer expression
            var classDeclaration = propertySymbol.DeclaringSyntaxReferences
                .FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;

            var initializer = classDeclaration?.Initializer?.Value as LiteralExpressionSyntax;
            if (initializer != null)
            {
                return bool.TryParse(initializer.Token.ValueText, out bool bres) ? bres : false;
            }

            return false;
        }

        private static string CreateClass(string namespaceStr, string className, string viewModelTypeName)
        {
            return
$@"using SingleScope.Maui;
using SingleScope.Maui.Mvvm.Interface;

namespace {namespaceStr}
{{
    public partial class {className} : IViewModelOwner<{viewModelTypeName}>
    {{
        public {viewModelTypeName} ViewModel {{ get; private set; }} = default!;

        private void PreInitializeComponent()
        {{
            ViewModel = SingleScopeServiceProvider.Current.GetRequiredService<{viewModelTypeName}>();
        }}

        private void PostInitializeComponent()
        {{
            BindingContext = ViewModel;
        }}
    }}
}}";
        }

        private static string CreateClassWithDefaultConstructor(string namespaceStr, string className, string viewModelTypeName)
        {
            return
$@"using SingleScope.Maui;
using SingleScope.Maui.Mvvm.Interface;

namespace {namespaceStr}
{{
    public partial class {className} : IViewModelOwner<{viewModelTypeName}>
    {{
        public {viewModelTypeName} ViewModel {{ get; }}

        public {className}()
        {{
            ViewModel = SingleScopeServiceProvider.Current.GetRequiredService<{viewModelTypeName}>();

            InitializeComponent();

            BindingContext = ViewModel;
        }}
    }}
}}";
        }
    }
}
