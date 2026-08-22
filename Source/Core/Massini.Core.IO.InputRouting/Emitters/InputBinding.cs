
using Massini.Core.IO.InputRouting.Enums;

namespace Massini.Core.IO.InputRouting.Emitters
{
    public sealed class InputBinding
    {
        /// <summary>
        /// X, Y, Z or W component of the output vector.
        /// </summary>
        public BindingTarget Target { get; set; } = BindingTarget.X;
        public required IEvalBlock Block { get; set; }
        public IFilter? InputFilter { get; set; } = null;
        /// <summary>
        /// Inverts the input (multiplies by -1).
        /// </summary>
        public bool Invert { get; set; } = false;
    }
}
