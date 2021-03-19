// [C#9] ソースコード ジェネレーター
// Introducing C# Source Generators | .NET Blog https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
// roslyn-sdk/samples/CSharp/SourceGenerators | GitHub https://github.com/dotnet/roslyn-sdk/tree/main/samples/CSharp/SourceGenerators

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloSourceGenerator
{
    [Generator]
    public class SourceTreeSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            AddSourceTree(context);
        }

        public void Initialize(GeneratorInitializationContext context)
        { }

        void AddSourceTree(GeneratorExecutionContext context)
        {
            var sourceTree = GenerateSourceTree(context);
            context.AddSource("generatedSourceTree.cs", SourceText.From(text: sourceTree, encoding: Encoding.UTF8));
        }

        string GenerateSourceTree(GeneratorExecutionContext context)
        {
            var sourceBuilder = new StringBuilder(@"
using System;
namespace SourceTreeGenerated
{
    public static class SourceTree
    {
        public static void Show() 
        {
            Console.WriteLine(""This is generated code!"");
            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
");

            // using the context, get a list of syntax trees in the users compilation
            IEnumerable<SyntaxTree> syntaxTrees = context.Compilation.SyntaxTrees;

            // add the filepath of each tree to the class we're building
            foreach (SyntaxTree tree in syntaxTrees)
                sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {Path.GetFileName(tree.FilePath)}"");");

            // finish creating the source to inject
            sourceBuilder.Append(@"
        }
    }
}");
            return sourceBuilder.ToString();
        }
    }
}
