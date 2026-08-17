

namespace Massini.Graphics.VkAL.Sugar.Structs.Internal
{
    internal struct SetBindingFingerprint
    {
        /// <summary>
        /// Used as a bool. 1 if used, 0 if not.
        /// </summary>
        public ushort p_used;
        public int p_bindingNumber;
        public int p_resourceHash;
        public ulong p_bufferOffset;
        public ulong p_bufferRange;

        // Only used for set creation. Doesn't affect fingerprint comparison.
        public int p_resourceIndex;
    }
}