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
                    predicate: (node, _) => IsClassWithMyAttribute(node),
                    transform: (syntaxContext, _) => GetSemanticTargetForGeneration(syntaxContext))
                .Where(classSymbol => classSymbol != null);

            // Register the source generator
            context.RegisterSourceOutput(classDeclarations, (productionContext, classSymbol) =>
            {
                var sourceCode = GenerateSourceCode(classSymbol);

                productionContext.AddSource($"{classSymbol.Name}_ViewModelOwner.g.cs", sourceCode);
            });
        }

        private static bool IsClassWithMyAttribute(SyntaxNode node)
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
            var viewModelType = classSymbol.GetAttributes()
                .First(attr => attr.AttributeClass?.ToDisplayString() == AttributeNamespace)
                .ConstructorArguments[0].Value as INamedTypeSymbol;

            // Full name with namespace
            var viewModelTypeName = viewModelType?.ToDisplayString();

            // Generate the source code for the partial class
            return
$@"using SingleScope.Maui;
using SingleScope.Maui.Mvvm.Interface;

namespace {classSymbol.ContainingNamespace.ToDisplayString()}
{{
    public partial class {className} : IViewModelOwner<{viewModelTypeName}>
    {{
        public {viewModelTypeName} ViewModel {{ get; }}

        public {className}()
        {{
            ViewModel = SingleScopeServiceProvider.Current.GetRequiredService<{viewModelTypeName}>();
            BindingContext = ViewModel;
        }}
    }}
}}";
        }
    }
}
