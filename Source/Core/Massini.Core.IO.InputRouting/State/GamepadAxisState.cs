
using Massini.Core.IO.InputRouting.Enums;

namespace Massini.Core.IO.InputRouting.State
{
    public sealed class GamepadAxisState : InputState
    {
        public GamepadAxis GamepadAxis { get; set; }
        public GamepadId GamepadId { get; set; }

        public void SetAxisValue(double i_state, TimeSpan i_timestamp)
        {
            SetState(i_state, i_timestamp);
        }
    }
}
