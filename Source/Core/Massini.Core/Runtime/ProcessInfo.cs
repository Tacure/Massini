
namespace Massini.Core.Runtime
{
    public class ProcessInfo
    {
        public static ProcessInfo Get()
        {
            m_info ??= new ProcessInfo();
            return m_info;
        }

        public Architecture Architecture { get; private init; }
        
        private static ProcessInfo? m_info = null;

        private ProcessInfo()
        {
            // Query process architecture.
            Architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture switch
            {
                System.Runtime.InteropServices.Architecture.X64 => Architecture.X64,
                System.Runtime.InteropServices.Architecture.Arm64 => Architecture.ARM64,
                _ => Architecture.Unknown,
            };
        }
    }    
}
