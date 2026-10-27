global using static Massini.Flamet2.Impl.Constants;

namespace Massini.Flamet2.Impl
{
    public static class Constants
    {
        public const int ONE = 1;
        public const int ZERO = 0;
        /// <summary>
        /// The maximum number of mip levels a texture can have.
        /// This limitation is because we use an ulong as a bitfield to select mip levels in certain internal operations.
        /// </summary>
        public const int MAX_MIP_LEVELS = 64;
    }   
}