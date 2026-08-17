

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Massini.Graphics.VkAL.Sugar.Structs.Internal
{
    internal struct SetFingerprint : IEquatable<SetFingerprint>
    {
        /// <summary>
        /// Used as a bool. 1 if used, 0 if not.
        /// </summary>
        public ushort p_used;
        public ushort p_bindingCount;
        public BindingLocationArray p_bindingLocations;
        public BindingArray p_bindings;

        public readonly bool Equals(SetFingerprint i_other)
        {
            if (p_used != i_other.p_used)
            {
                return false;
            }

            if (p_bindingCount != i_other.p_bindingCount)
            {
                return false;
            }

            for (int i = 0; i < p_bindingCount; i++)
            {
                if (p_bindingLocations[i] != i_other.p_bindingLocations[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < p_bindingCount; i++)
            {
                // Could be more efficient if we just iterate used bindings.

                int location = p_bindingLocations[i];
                if (p_bindings[location].p_bufferOffset != i_other.p_bindings[location].p_bufferOffset ||
                    p_bindings[location].p_bufferRange != i_other.p_bindings[location].p_bufferRange ||
                    p_bindings[location].p_resourceHash != i_other.p_bindings[location].p_resourceHash)
                {
                    return false;
                }
            }

            return true;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is SetFingerprint other && Equals(other);
        }

        public override int GetHashCode()
        {
            HashCode hc = new();

            hc.Add(p_bindingCount);

            for (int i = 0; i < p_bindingCount; i++)
            {
                int location = p_bindingLocations[i];

                ref var b = ref p_bindings[location];

                hc.Add(location);
                hc.Add(b.p_bufferOffset);
                hc.Add(b.p_bufferRange);
                hc.Add(b.p_resourceHash);
            }

            return hc.ToHashCode();
        }

        [InlineArray(ApiGlobalLimits.MAX_BINDINGS_PER_SET)]
        internal struct BindingArray
        {
            private SetBindingFingerprint _element0;
        }

        [InlineArray(ApiGlobalLimits.MAX_BINDINGS_PER_SET)]
        internal struct BindingLocationArray
        {
            private int _element0;
        }
    }
}