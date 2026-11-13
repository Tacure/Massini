using Massini.Bindings.Common;
using Massini.Core.Runtime;

namespace Massini.Bindings.Wgpu.Loader
{
    public class WgpuSolver : LibrarySolver
    {
        public override IReadOnlyList<string> LibraryName { get; init; } = ["Wgpu", "wgpu"];
        
        public override IReadOnlyList<string> GetNames(OS i_os, Architecture i_architecture)
        {
            return (i_os, i_architecture) switch
            {
                (OS.Windows, Architecture.X64) => ["wgpu_native.dll"],
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