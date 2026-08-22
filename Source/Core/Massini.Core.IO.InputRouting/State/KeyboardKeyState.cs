
using Massini.IO.InputRouting.Enums;

namespace Massini.IO.InputRouting.State
{
    public sealed class KeyboardKeyState : InputState
    {
        public KeyboardKey Key { get; set; }
        public Scancode Scancode { get; set; }
        public bool Begin { get; set; }
        public bool End { get; set; }
        public KeyboardId KeyboardId { get; set; }

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
