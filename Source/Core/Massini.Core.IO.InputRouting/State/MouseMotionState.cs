
using Massini.Core.IO.InputRouting.Enums;

namespace Massini.Core.IO.InputRouting.State
{
    public sealed class MouseMotionState : InputState
    {
        public MouseMotion MouseMotion { get; set; }
        public MouseId MouseId { get; set; }

        public void SetMotionValue(double i_state, TimeSpan i_timestamp) 
        {
            SetState(i_state, i_timestamp);
        }
    }
}
