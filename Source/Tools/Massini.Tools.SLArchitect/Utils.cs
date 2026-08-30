
using Spectre.Console;

namespace Massini.Tools.SLArchitect
{
    internal static class Utils
    {
        public const string SLAPROJ_EXTENSION = ".slaproj";
        public const string SLANG_EXTENSION = ".slang";
        public const string SPIRV_EXTENSION = ".spv";
        public const string SLANG_COMPILER = "slangc";

        public static void PrintError(string i_message)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] {i_message}");
        }

        public static void PrintInfo(string i_message)
        {
            AnsiConsole.MarkupLine($"[bold cyan]Info:[/] {i_message}");
        }

        public static void PrintBuildCompleted(string i_message) 
        {
            AnsiConsole.MarkupLine($"[bold green]✓ Build completed successfully:[/] {i_message}");
        }

        public static void PrintBuildFailed(string i_message)
        {
            AnsiConsole.MarkupLine($"[bold red]✗ Build failed:[/] {i_message}");
        }

        public static bool IsSLAProjFile(string i_path)
        {
            return Path.GetExtension(i_path) == SLAPROJ_EXTENSION;
        }
    }
}
