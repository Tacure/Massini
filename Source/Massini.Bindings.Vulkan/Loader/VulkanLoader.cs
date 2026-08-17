
using System.Reflection;
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vulkan.Loader
{
    public static class VulkanLoader
    {
        /// <summary>
        /// Setup the Vulkan loader.
        /// </summary>
        public static void Setup()
        {
            NativeLibrary.SetDllImportResolver(typeof(VulkanLoader).Assembly, ResolveVulkanLibrary);
        }

        private static IntPtr ResolveVulkanLibrary(string i_libraryName, Assembly i_assembly, DllImportSearchPath? i_searchPath)
        {
            if (i_libraryName != "vulkan")
                return IntPtr.Zero;

            if (m_vulkanLibHandle != IntPtr.Zero)
                return m_vulkanLibHandle;

            string[] candidates = GetPlatformVulkanNames();

            foreach (var name in candidates)
            {
                if (NativeLibrary.TryLoad(name, i_assembly, i_searchPath, out var handle))
                {
                    m_vulkanLibHandle = handle;
                    return handle;
                }
            }

            throw new DllNotFoundException("Could not locate Vulkan native library.");
        }

        private static string[] GetPlatformVulkanNames()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ["vulkan-1.dll"];
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ["libvulkan.so.1", "libvulkan.so"];
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ["libvulkan.1.dylib", "libvulkan.dylib"];
            return [];
        }

        private static IntPtr m_vulkanLibHandle;
    }
}
