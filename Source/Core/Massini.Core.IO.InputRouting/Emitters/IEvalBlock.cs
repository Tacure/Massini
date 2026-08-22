
using Massini.Core.IO.InputRouting.State;

namespace Massini.Core.IO.InputRouting.Emitters
{
    /// <summary>
    /// Represents a logic step used for input handling.
    /// </summary>
    public interface IEvalBlock
    {
        /// <summary>
        /// Evaluates the block and returns a <see cref="BlockResult"/>.
        /// </summary>
        /// <param name="i_inputTable"></param>
        /// <returns></returns>
        public BlockResult Evaluate((Mouse Mice, Keyboard Keyboards, Gamepad Gamepads) i_inputs);
    }
}
