
using Massini.Bindings.Common;
using Massini.Core.Runtime;

namespace Massini.Bindings.Vulkan.Loader
{
    public sealed class VulkanSolver : LibrarySolver
    {
        public override IReadOnlyList<string> LibraryName { get; init; } = ["Vulkan", "vulkan"];
        
        public override IReadOnlyList<string> GetNames(OS i_os, Architecture i_architecture)
        {
            return (i_os, i_architecture) switch
            {
                (OS.Windows, Architecture.X64) => ["vulkan-1.dll"],
                (OS.Linux, Architecture.X64) => ["libvulkan.so", "libvulkan.so.1"],
                _ => throw new Exception($"Unsupported operating system architecture {i_os} {i_architecture}")
            };
        }

        public override IReadOnlyList<string> GetDirectories(OS i_os, Architecture i_architecture)
        {
            return [];
        }
    }   
}