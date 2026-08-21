
using Massini.IO.InputRouting.Enums;
using Massini.IO.InputRouting.State;

namespace Massini.IO.InputRouting.Emitters
{
    /// <summary>
    /// Process the input in a specific order.
    /// </summary>
    /// <remarks>
    /// Used for creating shortcuts.
    /// </remarks>
    public class OrderAndBlock : IEvalBlock
    {
        /// <summary>
        /// Blocks are evaluated in order.
        /// </summary>
        public IEvalBlock[] Blocks { get; set; } = [];

        public BlockResult Evaluate((Mouse Mice, Keyboard Keyboards, Gamepad Gamepads) i_inputs)
        {
            if (m_isOrderBroken)
            {
                bool allNotPassed = true;
                foreach (var block in Blocks)
                {
                    BlockResult blockResult = block.Evaluate(i_inputs);
                    if (blockResult.State != 0.0)
                    {
                        allNotPassed = false;
                        break;
                    }
                }
                if (allNotPassed)
                {
                    m_isOrderBroken = false; // Reset condition met
                }
            }
            else
            {
                InputTrigger triggers = InputTrigger.None;
                double totalValue = 0.0;
                bool notPassedFound = false;
                bool passedAll = true;

                for (int i = 0; i < Blocks.Length; ++i)
                {
                    BlockResult blockResult = Blocks[i].Evaluate(i_inputs);
                    totalValue += blockResult.State;

                    if (notPassedFound && blockResult.State != 0.0)
                    {
                        m_isOrderBroken = true; // Order broken
                        break;
                    }

                    notPassedFound = blockResult.State == 0.0;
                    passedAll = passedAll && blockResult.State != 0.0;
                    triggers |= blockResult.Triggers;
                }

                if (passedAll)
                {
                    // If loop completes without breaking order
                    return new BlockResult
                    {
                        State = totalValue,
                        Triggers = triggers
                    };
                }
            }

            return new BlockResult
            {
                State = 0.0,
                Triggers = InputTrigger.None,
            };
        }

        private bool m_isOrderBroken = false;
    }
}
