using Massini.IO.InputRouting.State;

namespace Massini.IO.InputRouting.Emitters
{
    /// <summary>
    /// An OR block combines the logic of two input blocks.
    /// </summary>
    /// <remarks>
    /// Returns "new input" if either block returns "new input".
    /// </remarks>
    public class OrBlock : IEvalBlock
    {
        public required IEvalBlock BlockA { get; set; }
        public required IEvalBlock BlockB { get; set; }

        public BlockResult Evaluate((Mouse Mice, Keyboard Keyboards, Gamepad Gamepads) i_inputs)
        {
            BlockResult blockResultA = BlockA.Evaluate(i_inputs);
            BlockResult blockResultB = BlockB.Evaluate(i_inputs);

            double state = blockResultA.State + blockResultB.State;
            return new BlockResult
            {
                State = state,
                Triggers = state != 0.0 ? blockResultA.Triggers | blockResultB.Triggers : Enums.InputTrigger.None,
            };
        }
    }
}
