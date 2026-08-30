
using Massini.Tools.SLArchitect;
using CliWrap;
using CliWrap.Buffered;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Text.Json;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddCommand<BuildCommand>("build");
});
return app.Run(args);

internal class BuildCommand : Command<BuildCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<project>")]
        [Description("The project to build")]
        public string Project { get; init; } = "";
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        FileInfo projectFileInfo = new(Path.GetFullPath(settings.Project));

        if (!projectFileInfo.Exists)
        {
            Utils.PrintError($"Could not find project file!: {Path.GetFullPath(settings.Project)}");
            return 1;
        }

        if (!Utils.IsSLAProjFile(projectFileInfo.FullName))
        {
            Utils.PrintError($"Invalid project file extension: {projectFileInfo.Extension}");
            return 1;
        }

        if (projectFileInfo.DirectoryName == null)
        {
            Utils.PrintError("Could not find project directory!");
            return 1;
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        string projectJson = File.ReadAllText(projectFileInfo.FullName);
        ProjectModel? project = JsonSerializer.Deserialize<ProjectModel>(projectJson, options);

        if (project == null)
        {
            Utils.PrintError($"Could not parse project file! '{projectFileInfo.FullName}'");
            return 1;
        }

        Utils.PrintInfo($"Building project: {projectFileInfo.Name}");

        // Create output directory.
        string outputDirectory = Path.GetFullPath(Path.Combine(projectFileInfo.DirectoryName, "output"));
        Utils.PrintInfo($"Creating output directory: '{outputDirectory}'");
        try
        {
            DirectoryInfo outputDirectoryInfo = Directory.CreateDirectory(outputDirectory);
        }
        catch (Exception ex)
        {
            Utils.PrintError($"Could not create output directory: '{outputDirectory}'. Failed with error: {ex.Message}");
            return 1;
        }

        Utils.PrintInfo($"Found {project.Files.Count} files to build. Starting build...");

        // Build files.
        foreach (FileModel file in project.Files)
        {
            string srcFilePath = Path.GetFullPath(Path.Combine(projectFileInfo.DirectoryName, file.Name + Utils.SLANG_EXTENSION));
            string dstFilePath = Path.GetFullPath(Path.Combine(outputDirectory, file.Name + Utils.SPIRV_EXTENSION));

            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots12)
                .Start($"Building file: '{file.Name}'", ctx =>
                {
                    var result = Cli.Wrap(Utils.SLANG_COMPILER)
                        .WithArguments([srcFilePath, "-target", "spirv", "-profile", "spirv_1_3", "-o", dstFilePath])
                        .WithWorkingDirectory(projectFileInfo.DirectoryName)
                        .ExecuteBufferedAsync(CancellationToken.None);

                    result.Task.Wait();
                    BufferedCommandResult cmdResult = result.Task.Result;

                    if (cmdResult.ExitCode != 0)
                    {
                        Utils.PrintBuildFailed($"-> '{dstFilePath}'");
                        return 1;
                    }

                    Utils.PrintBuildCompleted($"-> '{dstFilePath}'");

                    return 1;
                });
        }

        return 0;
    }
}