
using Massini.Bindings.Common;
using Massini.Core.Runtime;

namespace Massini.Bindings.Vma.Loader
{
    public class VmaSolver : LibrarySolver
    {
        public override IReadOnlyList<string> LibraryName { get; init; } = ["Vma", "vma"];
        
        public override IReadOnlyList<string> GetNames(OS i_os, Architecture i_architecture)
        {
            return (i_os, i_architecture) switch
            {
                (OS.Windows, Architecture.X64) => ["VmaExporter.dll"],
                (OS.Linux, Architecture.X64) => ["libVmaExporter.so"],
                _ => throw new Exception($"Unsupported operating system architecture {i_os} {i_architecture}")
            };
        }

        public override IReadOnlyList<string> GetDirectories(OS i_os, Architecture i_architecture)
        {
            return (i_os, i_architecture) switch
            {
                (OS.Windows, Architecture.X64) => 
                    [
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes/win-x64/native/")
                    ],
                (OS.Linux, Architecture.X64) => 
                    [
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes/linux-x64/native/")
                    ],
                _ => throw new Exception($"Unsupported operating system architecture {i_os} {i_architecture}")
            };
        }
    }   
}