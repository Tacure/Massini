
namespace Massini.Core.Runtime
{
    public class OSInfo
    {
        public static OSInfo Get()
        {
            m_info ??= new OSInfo();
            return m_info;
        }

        public OS OS { get; private init; }
        public Architecture Architecture { get; private init; }
        
        private static OSInfo? m_info = null;

        private OSInfo()
        {
            // Query operating system.
            if (OperatingSystem.IsWindows())
            {
                OS = OS.Windows;
            }
            else if (OperatingSystem.IsLinux())
            {
                OS = OS.Linux;
            }
            else if (OperatingSystem.IsMacOS())
            {
                OS = OS.MacOS;
            }
            else if (OperatingSystem.IsAndroid())
            {
                OS = OS.Android;
            }
            else if (OperatingSystem.IsIOS())
            {
                OS = OS.IOS;
            }
            else if (OperatingSystem.IsFreeBSD())
            {
                OS = OS.FreeBSD;
            }
            else
            {
                OS = OS.Unknown;
            }
            
            // Query OS architecture.
            Architecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture switch
            {
                System.Runtime.InteropServices.Architecture.X64 => Architecture.X64,
                System.Runtime.InteropServices.Architecture.Arm64 => Architecture.ARM64,
                _ => Architecture.Unknown,
            };
        }
    }   
}