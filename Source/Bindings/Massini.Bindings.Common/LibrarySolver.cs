
using System.Reflection;
using Massini.Core.Runtime;
using NativeLibrary = System.Runtime.InteropServices.NativeLibrary;
using DllImportSearchPath = System.Runtime.InteropServices.DllImportSearchPath;

namespace Massini.Bindings.Common
{
    public abstract class LibrarySolver
    {
        public abstract IReadOnlyList<string> LibraryName { get; init; }
        
        public void Setup()
        {
            NativeLibrary.SetDllImportResolver(GetType().Assembly, ResolveLibrary);
        }

        /// <summary>
        /// Returns a list with all the possible names of the library for each os and architecture.
        /// </summary>
        public abstract IReadOnlyList<string> GetNames(OS i_os, Architecture i_architecture);
        
        /// <summary>
        /// Returns a list where the solver will search for the library.
        /// </summary>
        public abstract IReadOnlyList<string> GetDirectories(OS i_os, Architecture i_architecture);
        
        private IntPtr ResolveLibrary(string i_libraryName, Assembly i_assembly, DllImportSearchPath? i_searchPath)
        {
            if (!LibraryName.Contains(i_libraryName)) return IntPtr.Zero;
            if (m_libHandle != IntPtr.Zero) return m_libHandle;

            OS os = OSInfo.Get().OS;
            if (os == OS.Unknown)
            {
                throw new PlatformNotSupportedException();
            }

            Architecture architecture = ProcessInfo.Get().Architecture;
            if (architecture == Architecture.Unknown)
            {
                throw new Exception("Unsupported architecture.");
            }
            
            IReadOnlyList<string> names = GetNames(os, architecture);
            IReadOnlyList<string> directories = GetDirectories(os, architecture);
            
            foreach (var name in names)
            {
                foreach (var directory in directories)
                {
                    if (NativeLibrary.TryLoad(Path.Combine(directory, name), i_assembly, i_searchPath, out var handle))
                    {
                        m_libHandle = handle;
                        return handle;
                    }
                }
            }
            
            return m_libHandle;
        }
        
        private IntPtr m_libHandle;
    }   
}