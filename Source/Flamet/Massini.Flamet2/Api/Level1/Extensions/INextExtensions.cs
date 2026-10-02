using System.Diagnostics.CodeAnalysis;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Extensions
{
    public static class INextExtensions
    {
        /// <summary>
        /// Tries to get the next chained struct.
        /// </summary>
        public static bool TryGetNext<T>(this INext? i_current, [NotNullWhen(true)] out T o_next)
            where T : struct, INext
        {
            INext? root = i_current;
            while (root != null)
            {
                if (root is T found)
                {
                    o_next = found;
                    return true;
                }

                root = root.Next;
            }
            o_next = default;
            return false;
        }
    }
}
