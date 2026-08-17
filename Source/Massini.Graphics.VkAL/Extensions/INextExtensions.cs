using Massini.Graphics.VkAL.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Massini.Graphics.VkAL.Extensions
{
    public static class INextExtensions
    {
        /// <summary>
        /// Tries to get the next chained struct.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i_current"></param>
        /// <param name="o_next"></param>
        /// <returns></returns>
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
