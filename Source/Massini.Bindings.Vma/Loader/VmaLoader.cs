
using System.Reflection;
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vma.Loader
{
    public static class VmaLoader
    {
        /// <summary>
        /// Setup the Vma loader.
        /// </summary>
        public static void Setup()
        {
            NativeLibrary.SetDllImportResolver(typeof(VmaLoader).Assembly, ResolveVmaLibrary);
        }

        private static nint ResolveVmaLibrary(string i_libraryName, Assembly i_assembly, DllImportSearchPath? i_searchPath)
        {
            if (i_libraryName != "vma")
                return nint.Zero;

            if (m_vmaLibHandle != nint.Zero)
                return m_vmaLibHandle;

            string runtimesFolder = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                runtimesFolder = "./runtimes/win-x64/native/";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                runtimesFolder = "./runtimes/linux-x64/native/";
            }
            
            string[] candidates = GetPlatformVulkanNames();
            foreach (var name in candidates)
            {
                if (NativeLibrary.TryLoad(Path.GetFullPath(Path.Combine(runtimesFolder, name)), i_assembly, i_searchPath, out var handle))
                {
                    m_vmaLibHandle = handle;
                    return handle;
                }
            }

            throw new DllNotFoundException("Could not locate Vma native library.");
        }

        private static string[] GetPlatformVulkanNames()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ["VmaExporter.dll"];
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ["libVmaExporter.so"];
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                throw new PlatformNotSupportedException();
            return [];
        }

        private static nint m_vmaLibHandle;
    }
}
