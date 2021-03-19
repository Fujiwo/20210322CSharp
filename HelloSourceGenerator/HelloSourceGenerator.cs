// [C#9] ソースコード ジェネレーター

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace HelloSourceGenerator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource("generated.cs", SourceText.From(text: @"
namespace HelloSourceGeneratorSample
{
    public class Sample
    {
        public const int Id = 1;
    }

    partial class PartialClass
    {
        private partial string GetMessage() => ""Hello source generator!"";
    }
}
", encoding: Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        { }
    }
}
