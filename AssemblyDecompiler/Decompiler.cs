using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.ProjectDecompiler;
using ICSharpCode.Decompiler.DebugInfo;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.Solution;

namespace AssemblyDecompiler;

/// <summary>
/// Project decompiler
/// <remarks>Fragments adapted from https://github.com/icsharpcode/ILSpy/blob/master/ICSharpCode.ILSpyCmd/IlspyCmdProgram.cs</remarks>
/// </summary>
public class Decompiler
{
    public string AssemblyName { get; set; }
    public string OutputDirectory { get; set; }

    private string _outputProjectName;

    public Decompiler(string assemblyName, string outputDirectory)
    {
        AssemblyName = assemblyName;
        OutputDirectory = outputDirectory;

        if (!Path.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);
        _outputProjectName = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(assemblyName)}.csproj");
    }

    public void Decompile()
    {
        var module = new PEFile(AssemblyName);
        var resolver = new UniversalAssemblyResolver(AssemblyName, false, module.Metadata.DetectTargetFrameworkId());
        var decompiler = new WholeProjectDecompiler(GetSettings(module), resolver, null, resolver, null);

        ProjectId projectId;
        using (var projectFileWriter = new StreamWriter(File.OpenWrite(_outputProjectName)))
            projectId = decompiler.DecompileProject(module, OutputDirectory, projectFileWriter);
        Console.WriteLine($"GUID of decompiled project is: {projectId.Guid}");
    }

    DecompilerSettings GetSettings(PEFile module)
    {
        return new DecompilerSettings(LanguageVersion.Latest)
        {
            ThrowOnAssemblyResolveErrors = false,
            RemoveDeadCode = false,
            RemoveDeadStores = false,
            UseSdkStyleProjectFormat = WholeProjectDecompiler.CanUseSdkStyleProjectFormat(module),
            UseNestedDirectoriesForNamespaces = true
        };
    }
}