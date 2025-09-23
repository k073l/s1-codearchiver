using System.ComponentModel.DataAnnotations;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace AssemblyDecompiler;

class AssemblyDecompilerProgram
{
    public static int Main(string[] args) => CommandLineApplication.Execute<AssemblyDecompilerProgram>(args);

    [Option(ShortName = "a", LongName = "assembly", Description = "Path to assembly to be decompiled")]
    [Required]
    public string AssemblyName { get; set; }

    [Option(ShortName = "o", LongName = "output", Description = "Path to stubs output directory")]
    [Required]
    public string OutputDirectory { get; set; }

    [Option(ShortName = "m", LongName = "metadata", Description = "Path to globalgamemanagers")]
    public string MetadataPath { get; set; }

    [Option(ShortName = "f", LongName = "full-project-dir",
        Description = "Path to full project directory, generated via decompiler")]
    public string FullProjectDirectory { get; private set; } = "temp";

    private void OnExecute()
    {
        if (string.IsNullOrEmpty(AssemblyName))
        {
            Console.Error.WriteLine("Please specify a valid assembly name.");
            return;
        }

        if (string.IsNullOrEmpty(OutputDirectory))
        {
            Console.Error.WriteLine("Please specify a valid output directory.");
            return;
        }

        var decompiler = new Decompiler(AssemblyName, FullProjectDirectory);
        decompiler.Decompile();

        var stubGenerator = new StubGenerator(FullProjectDirectory, OutputDirectory);
        stubGenerator.Generate();

        SaveVersion();
    }

    public static string GetBundleVersion(string globalManagersPath)
    {
        if (string.IsNullOrEmpty(globalManagersPath) || !File.Exists(globalManagersPath))
            return "UNKNOWN";
        try
        {
            var bytes = File.ReadAllBytes(globalManagersPath);
            var anchorBytes = Encoding.ASCII.GetBytes("public.app-category.games");
            var anchorIdx = IndexOfSequence(bytes, anchorBytes);

            if (anchorIdx < 0)
                return "UNKNOWN";

            // Look for length-prefixed strings in the area after the anchor
            var searchStart = anchorIdx + anchorBytes.Length;

            for (var i = searchStart; i < Math.Min(bytes.Length - 4, searchStart + 200); i++)
            {
                var possibleLength = BitConverter.ToInt32(bytes, i);

                if (possibleLength <= 5 || possibleLength >= 50 || i + 4 + possibleLength >= bytes.Length) continue;
                try
                {
                    var candidate = Encoding.UTF8.GetString(bytes, i + 4, possibleLength);

                    if (IsGameVersion(candidate))
                    {
                        return candidate;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return "UNKNOWN";
        }
        catch
        {
            return "UNKNOWN";
        }
    }

    private static bool IsGameVersion(string version)
    {
        if (string.IsNullOrWhiteSpace(version))
            return false;
        if (!char.IsDigit(version[0]) || !version.Contains('.'))
            return false;
        if (version.StartsWith("20")) // not unity
            return false;
        if (version == "1.0") // some random versions
            return false;
        return true;
    }

    private static int IndexOfSequence(byte[] buffer, byte[] pattern)
    {
        for (var i = 0; i <= buffer.Length - pattern.Length; i++)
        {
            var found = !pattern.Where((t, j) => buffer[i + j] != t).Any();
            if (found) return i;
        }
        return -1;
    }

    private void SaveVersion()
    {
        if (string.IsNullOrEmpty(MetadataPath) || !File.Exists(MetadataPath))
            return;

        var version = GetBundleVersion(MetadataPath);

        File.WriteAllText(Path.Combine(OutputDirectory, "version.txt"), version);
        File.WriteAllText(Path.Combine(FullProjectDirectory, "version.txt"), version);

        Console.WriteLine(
            $"Game Version (bundleVersion): {version}. Saved version file to {OutputDirectory} and {FullProjectDirectory}");
    }
}