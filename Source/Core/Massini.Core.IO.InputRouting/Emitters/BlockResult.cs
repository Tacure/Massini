
using Massini.IO.InputRouting.Enums;

namespace Massini.IO.InputRouting.Emitters
{
    public struct BlockResult
    {
        /// <summary>
        /// The state of the block.
        /// </summary>
        public required double State { get; set; }
        /// <summary>
        /// The inputs that triggered the block.
        /// </summary>
        public required InputTrigger Triggers { get; set; }
    }
}
