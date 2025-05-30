﻿using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using SingleScope.Common.SourceGenerator.Models;

namespace SingleScope.Common.SourceGenerator.Generators
{
    [Generator(LanguageNames.CSharp)]
    public class EnumNameSourceGenerator : IIncrementalGenerator
    {
        private const string EnumStringNameAttributeName = "EnumStringNameAttribute";
        private const string EnumStringMapAttributeName = "EnumStringMapAttribute";

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Collect all enums with the [EnumStringMap] attribute
            var enumDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: IsEnumWithAttribute,    // Filter nodes to enums with attributes
                    transform: GetEnumInfo             // Transform to enum information
                )
                .Where(enumInfo => enumInfo != null);

            // Register the source output
            context.RegisterSourceOutput(enumDeclarations, (ctx, enumInfo) =>
            {
                if (enumInfo is EnumInfo info)
                {
                    var generatedCode = GenerateEnumStringMapClass(info);
                    var filenamePrefix = $"{info.NameSpace}.{info.EnumName}";

                    ctx.AddSource($"{filenamePrefix}StringMap.g.cs", SourceText.From(generatedCode, Encoding.UTF8));
                }
            });
        }

        private static bool IsEnumWithAttribute(SyntaxNode node, CancellationToken ct)
        {
            // Check if the node is an enum declaration with at least one attribute
            return node is EnumDeclarationSyntax enumDecl && enumDecl.AttributeLists.Count > 0;
        }

        private static EnumInfo GetEnumInfo(GeneratorSyntaxContext context, CancellationToken ct)
        {
            var enumDeclaration = (EnumDeclarationSyntax)context.Node;

            // Get the symbol for the enum
            var enumSymbol = context.SemanticModel.GetDeclaredSymbol(enumDeclaration) as INamedTypeSymbol;
            if (enumSymbol == null || !HasEnumStringMapAttribute(enumSymbol))
                return null;

            // Collect enum members and their names (using the EnumName attribute if present)
            var members = enumSymbol.GetMembers()
                .OfType<IFieldSymbol>()
                .Where(f => f.IsConst)
                .Select(f =>
                {
                    var attr = f.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == EnumStringNameAttributeName);
                    var name = attr != null && attr.ConstructorArguments.Length > 0
                        ? attr.ConstructorArguments[0].Value?.ToString()
                        : f.Name;

                    return new EnumMemberInfo(f.Name, name);
                })
                .ToList();

            return new EnumInfo(enumSymbol.ContainingNamespace.ToDisplayString(), enumSymbol.Name, members);
        }

        private static bool HasEnumStringMapAttribute(INamedTypeSymbol enumSymbol)
        {
            return enumSymbol.GetAttributes().Any(attr => attr.AttributeClass?.Name == EnumStringMapAttributeName);
        }

        private static string GenerateEnumStringMapClass(EnumInfo enumInfo)
        {
            string className = $"{enumInfo.EnumName}StringMap";
            var sb = new StringBuilder();

            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace {enumInfo.NameSpace}");
            sb.AppendLine($"{{");
            sb.AppendLine($"    public static class {className}");
            sb.AppendLine($"    {{");

            // Generate constant fields
            foreach (var member in enumInfo.Members)
            {
                sb.AppendLine($"        public const string {member.EnumField} = \"{member.EnumValue}\";");
                sb.AppendLine();
            }

            // Generate Values array
            sb.AppendLine($"        public static readonly string[] Values = new[]");
            sb.AppendLine($"        {{");
            foreach (var member in enumInfo.Members)
            {
                sb.AppendLine($"            {className}.{member.EnumField},");
            }
            sb.AppendLine($"        }};");
            sb.AppendLine();

            sb.AppendLine($"        public static readonly IDictionary<{enumInfo.NameSpace}.{enumInfo.EnumName}, string> Map = new Dictionary<{enumInfo.NameSpace}.{enumInfo.EnumName}, string>");
            sb.AppendLine($"        {{");
            foreach (var member in enumInfo.Members)
            {
                sb.AppendLine($"            {{ {enumInfo.NameSpace}.{enumInfo.EnumName}.{member.EnumField}, {className}.{member.EnumField} }},");
            }
            sb.AppendLine($"        }};");

            sb.AppendLine($"    }}");
            sb.AppendLine($"}}");

            return sb.ToString();
        }
    }
}
