using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AssemblyDecompiler;

public class StubGenerator
{
    public string InputDirectory { get; set; }
    public string OutputDirectory { get; set; }

    public StubGenerator(string inputDirectory, string outputDirectory)
    {
        InputDirectory = inputDirectory;
        OutputDirectory = outputDirectory;
    }

    public void Generate()
    {
        if (!Directory.Exists(InputDirectory))
        {
            Console.Error.WriteLine("Input directory does not exist.");
            return;
        }

        if (!Directory.Exists(OutputDirectory))
            Directory.CreateDirectory(OutputDirectory);

        var csFiles = Directory.GetFiles(InputDirectory, "*.cs", SearchOption.AllDirectories);
        Console.WriteLine($"Found {csFiles.Length} csFiles.");

        var stripper = new SignatureStripper();

        foreach (var csFile in csFiles)
        {
            var rel = Path.GetRelativePath(InputDirectory, csFile);
            var outPath = Path.Combine(OutputDirectory, rel);
            Directory.CreateDirectory(Path.GetDirectoryName(outPath)!);

            var source = File.ReadAllText(csFile);
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = tree.GetRoot();

            var newRoot = stripper.Visit(root);

            var formatted = newRoot.NormalizeWhitespace().ToFullString();

            File.WriteAllText(outPath, formatted);
        }

        Console.WriteLine("Stub generation complete.");
    }
}