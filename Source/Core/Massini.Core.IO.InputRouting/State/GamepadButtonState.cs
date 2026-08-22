using Massini.Core.IO.InputRouting.Enums;

namespace Massini.Core.IO.InputRouting.State
{
    public sealed class GamepadButtonState : InputState
    {
        public GamepadButton GamepadButton { get; set; }
        public bool Begin { get; set; }
        public bool End { get; set; }
        public GamepadId GamepadId { get; set; }

        public void SetPressed(TimeSpan i_timestamp)
        {
            Begin = true;
            End = false;

            if (State == 1.0)
            {
                Begin = false;
                End = false;
            }

            SetState(1.0, i_timestamp);
        }

        public void SetReleased(TimeSpan i_timestamp)
        {
            Begin = false;
            End = true;

            if (State == 0.0)
            {
                Begin = false;
                End = false;
            }

            SetState(0.0, i_timestamp);
        }
    }
}
