internal class FileHelper
{
    public static string LoadEmbeddedFile(string fileName)
    {
        var assembly = typeof(FileHelper).Assembly;

        var manifestFiles = assembly.GetManifestResourceNames();

        var manifestFile = manifestFiles.FirstOrDefault(f => f.EndsWith(fileName));

        if (manifestFile is null)
        {
            throw new FileNotFoundException($"No embedded resource found with name {fileName}");
        }

        using var fileStream = assembly.GetManifestResourceStream(manifestFile);

        if (fileStream is null)
        {
            throw new InvalidOperationException($"Could not load file stream for {manifestFile}");
        }

        using var streamReader = new StreamReader(fileStream);

        return streamReader.ReadToEnd();
    }
}
